namespace LMS.Models.Books;
public class Book
{
    
    public required long Isbn { get; set; }
    public string Title { get; set; }
    public string  Author { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public int availableCopies { get; set; }
}
