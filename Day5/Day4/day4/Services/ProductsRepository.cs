using day4.Contracts;
using day4.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace day4.Services
{
    public class ProductsRepository : IProductsRepository
    {
        Day4Context _context;
        public async Task<bool> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(b => b.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(b => b.Equals(id));
        }

        public async Task<bool> Update(Product product)
        {
            var p = _context.Products.FirstOrDefault(b => b.Id == product.Id);
            if (product != null)
            {
                _context.Products.Update(product);
                return true;
            }

            return false;
        }
    }
}
