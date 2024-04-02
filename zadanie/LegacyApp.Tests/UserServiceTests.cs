namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        //Assert
        //Assert.Equal(false, result); - for older versions
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskikowalcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2010-01-01"),
            1
        );
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            2
        );
        
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            3
        );
        
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        //Arrange
        var userService = new UserService();

        //Act
        Action action = () => { userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            100
        ); };

        //Assert
        Assert.Throws<ArgumentException>(action);
    }
}