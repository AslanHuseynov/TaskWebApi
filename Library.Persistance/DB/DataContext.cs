global using Microsoft.EntityFrameworkCore;
using Library.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Library.Persistance.DB
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyConnectionString"), b => b.MigrationsAssembly("Library.API"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Author2Book>().HasKey(x => x.Id);

            //modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.BookId, ab.AuthorId });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author2Book> AuthorBooks { get; set; }
    }
}
