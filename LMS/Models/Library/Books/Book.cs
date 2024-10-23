using LMS.Models.Library.Creators;

namespace LMS.Models.Library.Books;
public class Book : Item
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Authors { get; set; } 
    public int Year { get; set; }
    public string Publisher { get; set; }
    public string Language { get; set; } //Should this be a Language enum? probably
    public string ImageLink { get; set; }   
    public int AvailableCopies { get; set; }
    
    //public string Genre { get; set; } //Should this be a Genre enum? probably
    
    
    public Book(string isbn, string title, Array<string> author, int year, string publisher, string language, string imageLink)
    {
        this.ISBN = isbn;
        this.Title = title;
        this.Authors = author;
        this.Year = year;
        this.Publisher = publisher;
        this.Language = language;
        this.ImageLink = imageLink;
    }
    public void addCopy()
    {
        AvailableCopies++;
    }
    
    public void removeCopy()
    {
        AvailableCopies--;
    }
    
    
    public static bool isValidISBN(string isbn)
    {
        if (String.IsNullOrEmpty(isbn) ||
            isbn.Contains("-") ||
            isbn.Contains(" ") ||
            isbn.Length < 13)
            return false;

        if (isbn.Substring(0, 3) != "978")
            return false;

        int[] sequence = isbn.Select(c => Convert.ToInt32(c.ToString())).ToArray();

        var sum = sequence[0] * 1 + sequence[1] * 3 + sequence[2] * 1 +
                  sequence[3] * 3 + sequence[4] * 1 + sequence[5] * 3 +
                  sequence[6] * 1 + sequence[7] * 3 + sequence[8] * 1 +
                  sequence[9] * 3 + sequence[10] * 1 + sequence[11] * 3;

        int remainder = sum % 10;

        int checkdigit = 10 - remainder;

        if (sequence[12] == checkdigit)
            return true;


        return false;
    }
    
    
}