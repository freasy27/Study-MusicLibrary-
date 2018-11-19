using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Music.Data.Interfaces;

namespace Music.Controllers
{
    public class ReturnController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMusicRepository _musicRepository;
        public ReturnController(IMusicRepository musicRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _musicRepository = musicRepository;
        }
        [Route("Return")]
        public IActionResult List()
        {
            // load all borrowed musics
            var borrowedMusics = _musicRepository.FindWithAuthorAndBorrower(x => x.BorrowerID != 0 );
            // check the musics collection
            if(borrowedMusics == null || borrowedMusics.ToList().Count() == 0) // borrowedMusics == null || 
            {
                return View("Empty");
            }
            return View(borrowedMusics);
        }

        public IActionResult ReturnMusic (int musicID)
        {
            // load the current music
            var music = _musicRepository.GetByID(musicID);
            // remove borrower
            music.Borrower = null;

            music.BorrowerID = 0;
            // update database
            _musicRepository.Update(music);
            // redirect to list method
            return RedirectToAction("List");
        }
    }
}