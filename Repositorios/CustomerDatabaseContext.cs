using Customers.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Customers.Repositorios
{
    public class CustomerDatabaseContext : DbContext
    {
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) : base(options)
        {

        }
        public DbSet<CustomerEntity> Customer { get; set; }

        public async Task<CustomerEntity> Get(long id)
        {
            return await Customer.FirstAsync(x => x.Id == id);
        }
        public async Task<bool> Delete(long id)
        {
            CustomerEntity entity = await Get(id);
            Customer.Remove(entity);
            SaveChanges();
            return true;
        }
        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Id = null,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address
            };
            EntityEntry<CustomerEntity> response = await Customer.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id ?? throw new Exception("no se ha podido guardar"));
        }
    }

    public class CustomerEntity
    {
        public long? Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }

        public CustomerDto ToDto()
        {
            return new CustomerDto()
            {
                Id = Id ?? throw new Exception("El Id no puede ser null"),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Address = Address,
            };

        }
    }
}