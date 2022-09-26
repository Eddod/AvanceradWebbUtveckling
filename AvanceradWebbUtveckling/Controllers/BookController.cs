using AvanceradWebbUtveckling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        public BookController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var book = _bookRepository.GetAll().ToList();


            return View(book);
        }

        public IActionResult Details(int id)
        {
            Book book = _bookRepository.GetSingle(id);
            return View(book);
        }



        public IActionResult Create() => View();

        //post /customer/create
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Add(book);
                await _bookRepository.SaveAsync();
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View(book);
            }


            TempData["Success"] = "The book was successfully added!";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Book book = _bookRepository.GetSingle(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.Update(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }
            return View(book);
        }

        public ActionResult Delete(int id)
        {

            Book book = _bookRepository.GetSingle(id);

            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _bookRepository.Delete(id);
            _bookRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
