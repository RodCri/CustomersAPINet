using Customers.Dtos;
using Customers.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public CustomerController(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }

        //api/customer
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        public async Task<IActionResult> GetCustomers()
        {
            var result = _customerDatabaseContext.Customer
                .Select(c=>c.ToDto()).ToList();
            return new OkObjectResult(result);
        }

        //api/customer/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(long id)
        {
            CustomerEntity result = await _customerDatabaseContext.Get(id);
            return new OkObjectResult(result.ToDto());

        }

        //api/customer/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var result = await _customerDatabaseContext.Delete(id);
            return new OkObjectResult(result);
        }

        //api/customer/{customer}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            CustomerEntity result = await _customerDatabaseContext.Add(customer);
            return new CreatedResult($"http://localhost:7030/api/customer/{result.Id}",null);
        }

        //api/customer/{id}
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
