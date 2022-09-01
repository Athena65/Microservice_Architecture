using Microsoft.EntityFrameworkCore;
using Product.Microservice.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Product> CreateAsync(Models.Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChanges();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChanges();

        }

        public async Task<List<Models.Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();


        }

        public async Task<Models.Product> GetById(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            
        }

        public async Task<Models.Product> UpdateAsync(int id, Models.Product productData)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();

            product.Name = productData.Name;
            product.Rate = productData.Rate;


            await _context.SaveChanges();
            return product;
        }
    }
}
