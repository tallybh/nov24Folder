using MyDay2.Contracts;

namespace MyDay2.Services
{
    public class ProductsMock: IProductMock
    {
        private List<Product> products;

        public ProductsMock()
        {
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Bread", Price=10});
            products.Add(new Product { Id = 2, Name = "Milk", Price = 3 });
        }

        public Task<bool> Add(Product product)
        {
            int newId = products.Max(p => p.Id)+1;
            product.Id = newId;
            products.Add(product);
            return Task.FromResult(true);
        }
        
        public Task<bool> Delete(int id)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return Task.FromResult(false);
            }
            
            products.Remove(p);
            return Task.FromResult(true);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(products);
        }

        public Task<Product> GetById(int id)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(p);
        }

        public Task<bool> Update(Product product)
        {
            var p = products.FirstOrDefault(p=>p.Id == product.Id);
            if (p == null)
                { return Task.FromResult(false); }
            products.Remove(p);
            products.Add(product);
            return Task.FromResult(true);

        }
    }
}
