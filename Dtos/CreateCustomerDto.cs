using System.ComponentModel.DataAnnotations;

namespace Customers.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage = "The name is required for the register")]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "This Email is not vallid")]
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }

    }
}
