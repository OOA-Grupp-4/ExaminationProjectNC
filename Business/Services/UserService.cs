using Business.Models;
using Business.Services;


public class UserService : IUserService
{
    private readonly List<User> _users = [];
    private readonly PasswordHasher _passwordHasher;

    public UserService(PasswordHasher passwordHasher) //ChatGPT för hur man kan säkra passwords.
    {
        _passwordHasher = passwordHasher;
    }

    public bool RegisterUser(string email, string password, string address, int age)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !email.Contains("@"))
            return false;

        if (_users.Any(u => u.Email == email))
            return false; 

        var user = new User
        {
            Email = email,
            PasswordHash = _passwordHasher.HashPassword(password),
            Address = address,
            Age = age
        };

        _users.Add(user);
        return true;
    }

    public bool LoginUser(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.Email == email);
        return user != null && _passwordHasher.VerifyPassword(password, user.PasswordHash!);
    }

    public User GetUserProfile(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email)!;
    }

}
