using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class LoanViewModel
    {
        public int LoanID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BookName { get; set; }
        public Loan Loan { get; set; }
        public List<Book> Books { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
