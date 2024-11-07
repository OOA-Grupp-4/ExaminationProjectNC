using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService(UserFactory userFactory, IPasswordHasher passwordHasher) : IUserService
{
    private readonly List<User> _users = [];
    private readonly UserFactory _userFactory = userFactory;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public bool RegisterUser(string email, string password, string address, int age)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !email.Contains('@'))
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