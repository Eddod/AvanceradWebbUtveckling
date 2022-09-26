using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string BookDescription { get; set; }
        public string Author { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int AmountOfBooks { get; set; }
        public bool IsAvailable { get; set; }
    }
}
