namespace Business.Models;

public class User
{
    public string? Email { get; set; }
    public string? PasswordHash { get; set; } 
    public string? Address { get; set; }
    public int Age { get; set; }
}

