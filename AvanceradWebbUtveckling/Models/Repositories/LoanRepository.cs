using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Loan> GetCustomersLoans()
        {
            return _appDbContext.Loans.ToList();
        }

        public Loan GetSingle(int loanId)
        {
            Loan loan = _appDbContext.Loans
                .Include("Customer")
                .Include("Books")
                .FirstOrDefault(l => l.LoanID == loanId);

            return loan;
        }

        public void RegisterLoan(int customerId, int bookId)
        {
            var customer = _appDbContext.Customers.FirstOrDefault(c => c.Id == customerId);
            var book = _appDbContext.Books.FirstOrDefault(b => b.BookID == bookId);
            if (book.IsAvailable == true)
            {
                var loanToAdd = new Loan()
                {
                    CustomerID = customer.Id,
                    BookID = book.BookID,
                    Date = DateTime.Today

                };


                if (book.AmountOfBooks > 0)
                {
                    book.AmountOfBooks--;
                    _appDbContext.Add(loanToAdd);


                }
                else
                {
                    book.IsAvailable = false;
                }
            }

        }

        public void ReturnLoan(int loanId)
        {
            var loan = _appDbContext.Loans.FirstOrDefault(l => l.LoanID == loanId);
            if (loan != null)
            {
                _appDbContext.Remove(loan);

            }
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void SaveAsync()
        {
            _appDbContext.SaveChangesAsync();
        }
    }
}
