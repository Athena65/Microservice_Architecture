using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Microservice.Services
{
    public interface IProductService
    {
        public Task<Models.Product> CreateAsync(Models.Product product);
        public Task DeleteAsync(int id);
        public Task<List<Models.Product>> GetAllAsync();
        public Task<Models.Product> GetById(int id);
        public Task<Models.Product> UpdateAsync(int id, Models.Product productData);
    }
}