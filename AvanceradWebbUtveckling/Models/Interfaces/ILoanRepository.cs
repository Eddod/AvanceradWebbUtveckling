using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public interface ILoanRepository
    {

        //[POST]
        public void RegisterLoan(int bookId, int customerId);
        //[GET ALL]
        public IEnumerable<Loan> GetCustomersLoans();

        public Loan GetSingle(int loanId);

        public void ReturnLoan(int loanId);
        public void Save();
        public void SaveAsync();

    }
}
