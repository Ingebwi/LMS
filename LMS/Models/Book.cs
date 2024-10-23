namespace LMS.Models;

public class Book
{
    public long ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }
    public string Language { get; set; } //Should this be a Language enum? probably
    public int AvailableCopies { get; set; }

    public Book(long isbn)
    {
        this.ISBN = isbn;
    }
}