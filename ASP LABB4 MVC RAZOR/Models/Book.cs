using ASP_LABB4_MVC_RAZOR.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_LABB4_MVC_RAZOR.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100)]
        public string Author { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}

