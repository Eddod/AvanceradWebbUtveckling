using AvanceradWebbUtveckling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepo;
        public CustomerController(IRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public IActionResult Index()
        {
            var customers = _customerRepo.GetAll().ToList();
            return View(customers);
        }

        //Create view
        public IActionResult Create() => View();

        //Create action
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Add(customer);
                await _customerRepo.SaveAsync();
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View(customer);
            }

            TempData["Success"] = "The customer was successfully added!";
            return RedirectToAction("Index");
            
        }

        public IActionResult Details(int id)
        {
            var customer = _customerRepo.GetSingle(id);

            return View(customer);
        }

        //Delete View
        public ActionResult Delete(int id)
        {

            Customer customer = _customerRepo.GetSingle(id);

            return View(customer);
        }

        //Delete Action
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _customerRepo.Delete(id);
            _customerRepo.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Customer customer = _customerRepo.GetSingle(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepo.Update(customer);
                    _customerRepo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }
            return View(customer);
        }
    }
}
