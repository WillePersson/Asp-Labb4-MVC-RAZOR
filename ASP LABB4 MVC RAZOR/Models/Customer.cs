using ASP_LABB4_MVC_RAZOR.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_LABB4_MVC_RAZOR.Models
{
    public class Customer : User
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}

