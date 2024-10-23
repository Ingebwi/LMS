using LMS.Models.Books;
using Microsoft.EntityFrameworkCore;
namespace LMS.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; } = null!;
}