using Microsoft.EntityFrameworkCore;
using MyDay2.Contracts;


namespace MyDay2.Services
{
    public class BlogRepository : IBlogRepository
    {
        AppDbContext _context;
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }


        public async Task<List<Blog>> GetAllBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.Equals(id));
        }

        public async Task<bool> Update(Blog product)
        {
            //_context.Update(product);
            _context.Blogs.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
