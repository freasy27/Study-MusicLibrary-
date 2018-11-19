using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Data.Interfaces;
using Music.ViewModel;

namespace Music.Controllers.Book
{
    public class MusicController : Controller
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IAuthorRepository _authorRepository;

        public MusicController(IMusicRepository musicRepository, IAuthorRepository authorRepository)
        {
            _musicRepository = musicRepository;
            _authorRepository = authorRepository;
        }
        [Route("Music")]
        public IActionResult List(int? authorID, int? borrowerID)
        {
            if (authorID == null && borrowerID == null)
            {
                // show all music
                var musics = _musicRepository.GetAllWithAuthor();
                // check music

                // return CheckMusics(musics);
                if (musics.Count() == 0)
                {
                    return View("Empty");
                }
                else
                {
                    return View(musics);
                }
            }
            else if (authorID != null)
            {
                // filter by author id
                var author = _authorRepository.GetWithMusics((int)authorID);
                // check author musics
                if (author.Musics.Count() == 0)
                {
                    return View("AuthorEmpty", author);
                }
                else
                {
                    return View(author.Musics);
                }
            }
            else if (borrowerID != null)
            {
                // filter by borrower id
                var musics = _musicRepository.FindWithAuthorAndBorrower(music => music.BorrowerID == borrowerID);
                // check borrower musics

                // return CheckMusics(musics);
                if (musics.Count() == 0)
                {
                    return View("Empty");
                }
                else
                {
                    return View(musics);
                }
            }
            else
            {
                // throw exception
                throw new ArgumentException();
            }
        }
        //public IActionResult CheckMusics(IEnumerable<Music> musics)
        //{
        //    if (musics.Count() == 0)
        //    {
        //        return View("Empty");
        //    }
        //    else
        //    {
        //        return View(musics);
        //    }
        //}
        public IActionResult Create()
        {
            var musicVM = new MusicViewModel()
            {
                Authors = _authorRepository.GetAll()
            };
            return View(musicVM);
        }
        [HttpPost]
        public IActionResult Create(MusicViewModel musicViewModel)
        {
                if (!ModelState.IsValid)
                {
                    musicViewModel.Authors = _authorRepository.GetAll();
                    return View(musicViewModel);
                }
                _musicRepository.Create(musicViewModel.Music);
                return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            var musicVM = new MusicViewModel()
            {
                Music = _musicRepository.GetByID(id),
                Authors = _authorRepository.GetAll()
            };
            return View(musicVM);
        }
        [HttpPost]
        public IActionResult Update(MusicViewModel musicViewModel)
        {
            if (!ModelState.IsValid)
            {
                musicViewModel.Authors = _authorRepository.GetAll();
                return View(musicViewModel);
            }
            _musicRepository.Update(musicViewModel.Music);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var music = _musicRepository.GetByID(id);

            _musicRepository.Delete(music);
            return RedirectToAction("List");
        }
    }
}
