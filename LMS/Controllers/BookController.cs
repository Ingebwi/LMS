using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models;
using LMS.Models.Library.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly BookContext _context;

        public BookController(ILogger<BookController> logger, BookContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/Books/{isbn}
        [HttpGet("{isbn}")]
        public async Task<ActionResult<Book>> GetBook(string isbn)
        {
            var book = await _context.Books.FindAsync(isbn);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!Book.isValidISBN(book.ISBN))
            {
                _logger.LogWarning("Invalid ISBN: {ISBN}", book.ISBN);
                return BadRequest("Invalid ISBN.");
            }

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Book added: {ISBN}", book.ISBN);

                return CreatedAtAction(nameof(GetBook), new { isbn = book.ISBN }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding book: {ISBN}", book.ISBN);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}