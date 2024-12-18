using ProductsWithRabbit.Models;

namespace ProductsWithRabbit.Contracts;

public interface IProductService
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<Product> AddNewProduct(Product p);

    Task<bool> Delete(int id);

    Task Update(Product p);
}
