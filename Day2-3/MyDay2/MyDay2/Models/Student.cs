using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDay2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public virtual Adress Adress { get; set; }
    }
}
