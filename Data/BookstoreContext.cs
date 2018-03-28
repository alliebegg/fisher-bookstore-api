using Microsoft.EntityFrameworkCore;

namespace Fisher.Bookstore.Api.Data
{
    public class BookstoreContext : DbContext
    {
       public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
    {
    } 
    protected override void OnModelCreating(ModelBuilder builder) => base .OnModelCreating(builder);
    public DbSet<Models.Book> Books { get; set;}

    public DbSet<Models.Author> Authors { get; set;}
    
    }
}