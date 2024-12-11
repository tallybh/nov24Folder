using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDay2.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public double Price { get; set; }
}
