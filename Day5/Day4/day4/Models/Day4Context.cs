using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace day4.Models;

public partial class Day4Context : DbContext
{
    public Day4Context()
    {
    }

    public Day4Context(DbContextOptions<Day4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
