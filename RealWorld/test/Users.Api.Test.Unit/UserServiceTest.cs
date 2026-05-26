using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Users.Api.Logging;
using Users.Api.Models;
using Users.Api.Repositories;
using Users.Api.Services;

namespace Users.Api.Test.Unit;

public class UserServiceTest
{
    private readonly UserService _sut;
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly ILoggerAdapter<UserService> _logger = Substitute.For<ILoggerAdapter<UserService>>();


    public UserServiceTest()
    {
        _sut = new(_userRepository, _logger);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExist()
    {
        //arrange
        _userRepository.GetAllAsync().Returns(Enumerable.Empty<User>().ToList());
        //act
        var result = await _sut.GetAllAsync();

        //assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnsUsers_WhenSomeUsersExist()
    {
        //arrange
        var baranUser = new User
        {
            Id = Guid.CreateVersion7(),
            FullName = "Baran Daşdemir"
        };
        var expectedUser = new List<User>
        {
            baranUser
        };
        _userRepository.GetAllAsync().Returns(expectedUser);
        //act
        var result = await _sut.GetAllAsync();
        //assert
        result.Should().BeEquivalentTo(expectedUser);

    }

    [Fact]
    public async Task GetAllAsync_ShouldLogMessages_WhenInvoked()
    {
        //arrange
        _userRepository.GetAllAsync().Returns(Enumerable.Empty<User>().ToList());

        //act
       await _sut.GetAllAsync();

        //assert
        _logger.Received(1).LogInformation(Arg.Is("retrieving all user"));
        _logger.Received(1).LogInformation(Arg.Is("all user retrieved in {0}ms"), Arg.Any<long>());
    }

    [Fact]
    public async Task GetAllAsync_ShouldLogMessageAndException_WhenExceptionIsThrown()
    {
        //arrange
        var exception = new ArgumentException("Something went wrong while retrieving all user");
        _userRepository.GetAllAsync().Throws(exception);
        //act
        var requestAction = async() =>  await _sut.GetAllAsync();

        //assert
        await requestAction.Should()
            .ThrowAsync<ArgumentException>();

        _logger.Received(1).LogError(Arg.Is(exception),Arg.Is("Something went wrong while retrieving all user"));
    }


}
