using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Microservice.Services
{
    public interface ICustomerService
    {
        public Task<List<Models.Customer>> GetAllAsync();
        public Task<Models.Customer> GetById(int id);   
        public Task<Models.Customer> CreateAsync(Models.Customer customer) ;
        public Task<Models.Customer> UpdateAsync(int id, Models.Customer customerData); 
        public Task DeleteAsync(int id);

    }
}
