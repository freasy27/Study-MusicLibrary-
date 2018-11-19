using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Data.Interfaces;
using Music.ViewModel;

namespace Music.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMusicRepository _musicRepository;
        private readonly ICustomerRepository _customerRepository;
        public HomeController(IAuthorRepository authorRepository, ICustomerRepository customerRepository, IMusicRepository musicRepository)
        {
            _authorRepository = authorRepository;
            _musicRepository = musicRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            // create home view model
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                MusicCount = _musicRepository.Count(x => true),
                LendMusicCount = _musicRepository.Count(x => x.Borrower != null)
            };
            // call view
            return View(homeVM);
        }
    }
}
