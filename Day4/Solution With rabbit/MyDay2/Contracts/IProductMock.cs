
namespace MyDay2.Contracts;

public interface IProductMock
{
    Task<List<Product>> GetAllProducts();

    Task<Product> GetById(int id);
    Task<bool> Add(Product product);

    Task<bool> Update(Product product);
    Task<bool> Delete(int id);

}
