using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ProductsWithRabbit.Models;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //To work with sqlite
        optionsBuilder.UseSqlite("Filename=Products.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //    modelBuilder
        //.Entity<UserModel>(builder =>
        //{
        //    builder.HasNoKey();
        //    builder.ToTable("UserModel");
        //});

    }

}
