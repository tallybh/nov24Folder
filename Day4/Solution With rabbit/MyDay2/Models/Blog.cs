namespace MyDay2.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
