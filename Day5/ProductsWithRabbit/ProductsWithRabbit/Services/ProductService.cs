using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductsWithRabbit.Contracts;
using ProductsWithRabbit.Models;

namespace ProductsWithRabbit.Services
{
    public class ProductService : IProductService
    {
        private AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddNewProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public Task<bool> Delete(int id)
        {
           var productToDelete =  _context.Products.ToList().Where(p => p.Id == id).FirstOrDefault();
            if(productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(_context.Products.ToList());
        }

        public Task<Product> GetProductById(int id)
        {
            return Task.FromResult(_context.Products.ToList().Where(p => p.Id == id).FirstOrDefault());
        }

        public Task Update(Product p)
        {
            _context.Products.Update(p);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            return Task.CompletedTask;
        }
    }
}
