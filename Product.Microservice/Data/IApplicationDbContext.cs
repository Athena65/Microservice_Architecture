using Microsoft.EntityFrameworkCore;
using Product.Microservice.Models;
using System.Threading.Tasks;

namespace Product.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Models.Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}