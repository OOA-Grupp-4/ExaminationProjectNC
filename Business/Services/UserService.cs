using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;


public class UserService : IUserService
{
    private readonly List<User> _users = [];
    private readonly UserFactory _userFactory;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(UserFactory userFactory, IPasswordHasher passwordHasher)
    {
        _userFactory = userFactory;
        _passwordHasher = passwordHasher;
    }

    public bool RegisterUser(string email, string password, string address, int age)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !email.Contains("@"))
            return false;

        if (_users.Any(u => u.Email == email))
            return false; 

        var user = _userFactory.CreateUser(email, password, address, age);
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
