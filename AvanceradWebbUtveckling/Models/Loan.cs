using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int BookID { get; set; }
        public List<Book> Books { get; set; }
        public List<Customer> Customer { get; set; }
        public bool IsReturned { get; set; }


        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
