using System.ComponentModel.DataAnnotations;

namespace MyDay2.Models
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }
    }
}
