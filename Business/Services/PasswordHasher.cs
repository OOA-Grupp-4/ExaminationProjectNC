using Business.Interfaces;

namespace Business.Services;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) => password; 
    public bool VerifyPassword(string password, string hash) => password == hash; 
}
