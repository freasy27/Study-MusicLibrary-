using Microsoft.AspNetCore.Mvc;
using Music.Data.Interfaces;
using Music.Data.Model;
using Music.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Music.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMusicRepository _musicRepository;

        public CustomerController(ICustomerRepository customerRepository, IMusicRepository musicRepository)
        {
            _customerRepository = customerRepository;
            _musicRepository = musicRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();

            var customers = _customerRepository.GetAll();

            if(customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach(var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    MusicCount = _musicRepository.Count(x => x.BorrowerID == customer.CustomerID)
                });
            }
            return View(customerVM);
        }
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetByID(id);
            _customerRepository.Delete(customer);
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetByID(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }
                _customerRepository.Create(customer);

            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _customerRepository.Update(customer);

            return RedirectToAction("List");
        }
    }
}
