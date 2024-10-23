namespace LMS.Models.Users;

public class Member
{
    public string Name { get; set; }
    public string Email { get; set; }
    private string _passwordHash { get; set; }
    public string PhoneNumber { get; set; }
    public int pID { get; set; }

    public void borrowCopy(int copyId)
    {
        
    }
}