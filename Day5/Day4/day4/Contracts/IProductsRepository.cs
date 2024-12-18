using day4.Models;

namespace day4.Contracts
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> GetById(int id);
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
