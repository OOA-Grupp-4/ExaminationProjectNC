namespace Business.Models;

public class Review
{
    public string ProductName { get; set; } = null!;
    public int Rating { get; set; } 
    public string? Comment { get; set; }
}