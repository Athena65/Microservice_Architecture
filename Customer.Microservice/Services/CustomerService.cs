using Customer.Microservice.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Customer> CreateAsync(Models.Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChanges();
            return customer;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);   
            _context.Customers.Remove(customer);
            await _context.SaveChanges();
            
        }

        public async Task<List<Models.Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Models.Customer> GetById(int id)
        {
            return await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Models.Customer> UpdateAsync(int id, Models.Customer customerData)
        {
            var customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
           
            customer.Name= customerData.Name;
            customer.Contact=customerData.Contact;
            customer.City = customerData.City;
            customer.Email= customerData.Email;

            await _context.SaveChanges();
            return customer;
        }
    }
}
