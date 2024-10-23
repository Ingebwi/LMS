using LMS.Models.Books;

namespace LMS.Models.Users;

public class Librarian
{
    public string Name { get; set; }
    public int EmployeeID { get; set; }
    private string _passwordHash { get; set; }
    
    
    public void addBook(Book book)
    {
     //TODO: Fill inn logic
     
    }
    public void removeBook(Book book)
    {
    }
    
    
}