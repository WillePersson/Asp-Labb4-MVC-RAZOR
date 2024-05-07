using System.ComponentModel.DataAnnotations;

namespace ASP_LABB4_MVC_RAZOR.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace YourNamespace.Models
    {
        public class Admin : User
        {
            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }
        }
    }

}
