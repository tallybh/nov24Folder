namespace MyDay2.Contracts
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();

        Task<Blog> GetById(int id);
        Task Add(Blog blog);

        Task<bool> Update(Blog product);
        Task<bool> Delete(int id);
    }
}
