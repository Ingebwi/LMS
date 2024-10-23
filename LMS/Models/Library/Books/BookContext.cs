using LMS.Models.Library.Books;
using Microsoft.EntityFrameworkCore;

namespace LMS.Models;

public class BookContext : DbContext
{
    private DbSet<Book> _books = null!;

    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    public DbSet<Book> Books
    {
        get => _books;
        set => _books = value;
    }
    
}