using Microsoft.AspNetCore.Mvc;
using Music.Data.Interfaces;
using Music.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Controllers
{
    public class LendController : Controller
    {
        private readonly IMusicRepository _musicRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IMusicRepository musicRepository, ICustomerRepository customerRepository)
        {
            _musicRepository = musicRepository;
            _customerRepository = customerRepository;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            //load all available musics
            var availableMusics = _musicRepository.FindWithAuthor(x => x.BorrowerID == 0);
            // check collection
            if (availableMusics.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableMusics);
            }
        }
        public IActionResult LendMusic(int musicID)
        {
            // load current music and all customers
            var lendVM = new LendViewModel()
            {
                Music = _musicRepository.GetByID(musicID),
                Customers = _customerRepository.GetAll()
            };
            // Send data to the Lend view
            return View(lendVM);
        }
        
        [HttpPost]
        public IActionResult LendMusic(LendViewModel lendViewModel)
        {
            // update the database
            var music = _musicRepository.GetByID(lendViewModel.Music.MusicID);

            var customer = _customerRepository.GetByID(lendViewModel.Music.BorrowerID);

            music.Borrower = customer;
            _musicRepository.Update(music);

            // redirect to the list view
            return RedirectToAction("List");
        }

            
    }
}
