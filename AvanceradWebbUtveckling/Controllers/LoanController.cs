using AvanceradWebbUtveckling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Controllers
{
    public class LoanController : Controller
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly ILoanRepository _loanRepo;
        public LoanController(ILoanRepository loanrepo, IRepository<Customer> customerRepo, IRepository<Book> bookRepo)
        {
            _loanRepo = loanrepo;
            _customerRepo = customerRepo;
            _bookRepo = bookRepo;

        }

        public ActionResult<LoanViewModel> Index()
        {
            var loans = _loanRepo.GetCustomersLoans();
            var customers = _customerRepo.GetAll();
            var books = _bookRepo.GetAll();
            var loanView = from l in loans
                           join c in customers on l.CustomerID equals c.Id
                           join b in books on l.BookID equals b.BookID
                           select new LoanViewModel
                           {
                               Loan = l,
                               FirstName = c.FirstName,
                               LastName = c.Lastname,
                               BookName = b.BookName

                           };

            return View(loanView);
        }

        //Create Loan VIEW!!
        [HttpGet]
        public ActionResult<Loan> Create()
        {
            var books = _bookRepo.GetAll().Where(c => c.IsAvailable == true).ToList();
            var customers = _customerRepo.GetAll().ToList();

            var Loan = new Loan()
            {
                Books = books,
                Customer = customers,
            };
            return View(Loan);

        }
        //Create Loan ACTION!!!!
        [HttpPost]
        public ActionResult<Loan> Create(int customerId, int bookId)
        {
            if (ModelState.IsValid)
            {
                _loanRepo.RegisterLoan(customerId, bookId);
                _loanRepo.Save();

                TempData["Success"] = "The book was successfully added!";
                return RedirectToAction("Index");
            }
            else
            {

                ModelState.AddModelError("", "Error");
                return View();
            }
        }




        //Delete View



        public ActionResult Delete(int loanId)
        {

            Loan loan = _loanRepo.GetSingle(loanId);
            return View(loan);
        }

        //Delete Action
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int Id)
        {
            
            _loanRepo.ReturnLoan(Id);
            _loanRepo.Save();
            return RedirectToAction("Index");
        }

    }
}
