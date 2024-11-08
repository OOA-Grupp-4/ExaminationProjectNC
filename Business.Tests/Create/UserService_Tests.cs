using Business.Factories;
using Business.Services;

namespace Business.Tests.Create;

public class UserServiceTests
{
    private readonly UserService _userService;

    public UserServiceTests()
    {
        var passwordHasher = new PasswordHasher();
        var userFactory = new UserFactory(passwordHasher);
        _userService = new UserService(userFactory, passwordHasher);
    }
    #region Register Test
    [Fact]
    public void RegisterUser_ShouldReturnTrue_IfInformationIsFilledOutCorrectly()
    {
        // Arrange
        string email = "christoffer@domain.com";
        string password = "FriendsAmbassador123";
        string address = "Eckerö linjen 1";
        int age = 34;

        // Act
        bool result = _userService.RegisterUser(email, password, address, age);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region GetUser Test
    [Fact]
    public void GetUserProfile_ShouldReturnUser_WhenUserIsRegistered()
    {
        // Arrange
        string email = "nicklas@domain.com";
        string password = "Coolkille123";
        string address = "Hammervillage Seatown 1";
        int age = 38;
        _userService.RegisterUser(email, password, address, age);

        // Act
        var result = _userService.GetUserProfile(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(email, result.Email);
        Assert.Equal(address, result.Address);
        Assert.Equal(age, result.Age);
    }
    #endregion
}