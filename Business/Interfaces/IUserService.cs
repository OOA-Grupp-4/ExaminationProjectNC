using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    public bool RegisterUser(string email, string password, string address, int age);
    public bool LoginUser(string email, string password);
    public User GetUserProfile(string email);
}