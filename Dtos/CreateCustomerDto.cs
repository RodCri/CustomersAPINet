using System.ComponentModel.DataAnnotations;

namespace Customers.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage = "The name is required for the register")]
        private string FirstName { set; get; }
        [Required]
        private string LastName { set; get; }
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "This Email is not vallid")]
        private string Email { set; get; }
        private string Phone { set; get; }
        private string Address { set; get; }

    }
}
