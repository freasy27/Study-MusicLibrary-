using Microsoft.EntityFrameworkCore;
using Music.Data.Model;

namespace Music.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Model.Music> Musics { get; set; }
    }
}
