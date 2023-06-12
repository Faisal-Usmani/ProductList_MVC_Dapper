using ProductDemo.Data.DataAccess;
using ProductDemo.Data.Models;

namespace ProductDemo.Data.Repository
{
    public class ProductRepository:IProductRepository

    {
        private readonly ISqlDataAccess _db;
        public ProductRepository(ISqlDataAccess db)
        {
            _db = db;

        }
        public async Task<bool> AddAsync(Product product)
        {
            try
            {
                await _db.SaveData("CreatePruduct", new { product.Name, product.Price });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                await _db.SaveData("UpdateProduct", product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("DeleteProduct", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Product> GetIdAsync(int id)
        {
            IEnumerable<Product> result = await _db.GetData<Product, dynamic>("GetProductById", new { Id = id });
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<Product>> GetAllAsync(int id)
        {

            string query = "GetProduct";
            return await _db.GetData<Product, dynamic>(query, new { });

        }
    }
}
