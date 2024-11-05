using Business.Models;
using Business.Interfaces;

namespace Business.Factories;

public class UserFactory
{
    private readonly IPasswordHasher _passwordHasher;

    public UserFactory(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public User CreateUser(string email, string password, string address, int age)
    {
        return new User
        {
            Email = email,
            PasswordHash = _passwordHasher.HashPassword(password),
            Address = address,
            Age = age
        };
    }
}
