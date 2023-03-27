global using Microsoft.EntityFrameworkCore;
using Library.Domain.Models;

namespace Library.Persistance.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Author2Book>().HasKey(x => x.Id);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author2Book> AuthorBooks { get; set; }
    }
}
