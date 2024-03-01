using Customers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        //api/customer
        [HttpGet()]
        public async Task<List<CustomerDto>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        //api/customer/{id}
        [HttpGet("{id}")]
        public async Task<CustomerDto> GetCustomer(long id)
        {
            throw new NotImplementedException();
        }

        //api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        //api/customer/{id}
        [HttpPost("{Customer}")]
        public async Task<bool> CreateCustomer(CustomerDto customer  )
        {
            throw new NotImplementedException();
        }
    }
}
