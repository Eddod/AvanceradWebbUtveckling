using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(25, ErrorMessage = "Maximum 25 characters")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Lastname { get; set; }


        [Required(ErrorMessage ="This field is required")]
        public string Email { get; set; }
    }
}
