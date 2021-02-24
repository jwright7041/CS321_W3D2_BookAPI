using System;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CS321_W3D2_BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        // TODO: implement a DbSet<Author> property

        // This method runs once when the DbContext is first used.
        public BookContext(DbContextOptions options) : base(options)
        {
            
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: configure some seed data in the authors table

            // TODO: configure some seed data in the books table

        }

    }
}

