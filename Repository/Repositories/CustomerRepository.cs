using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAll();
        public Task<Customer> GetByID(int id);
        public Task<Customer> CreateCustomer(Customer obj);
        public Task<int> UpdateCustomer(Customer obj);
        public Task<int> DeleteCustomer(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly TestDbContext _context;
        public CustomerRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByID(int id)
        {
            return await _context.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
        }

        public async Task<Customer> CreateCustomer(Customer obj)
        {
            var rnd = new Random();
            obj.CreatedBy = rnd.Next(1, 1000);
            obj.CreatedAt = DateTime.Now;
            var result = _context.Customers.Add(obj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateCustomer(Customer obj)
        {
            try
            {
                obj.ModifiedBy = obj.CreatedBy;
                obj.ModifiedAt = DateTime.Now;
                _context.Customers.Update(obj);
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteCustomer(int Id)
        {
            var filteredData = _context.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();
            if (filteredData != null)
            {
                _context.Customers.Remove(filteredData);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
            
        }
    }
}
