using ProductDemo.Data.Models;

namespace ProductDemo.Data.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);
        Task<Product> GetIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync(int id);
    }
}