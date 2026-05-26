using FluentAssertions;
using Moq;
using NSubstitute;
using UnderstandingDependencies.Api.Model;
using UnderstandingDependencies.Api.Repositories;
using UnderstandingDependencies.Api.Services;

namespace UnderstandingDependencies.Api.Tests.Unit;

public class UserServiceTests
{
    private readonly UserService _sut;
    // private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>(); //Substitute kullanımı
    private readonly Mock<IUserRepository> _userRepository = new(); //moq kullanımı

    public UserServiceTests()
    {
        //_sut = new(_userRepository); //Substitute kullanımı
        _sut = new(_userRepository.Object); //moq kullanımı
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExist()
    {
        //arrange --> yukarıda tamamladık
        //_userRepository.GetAllAsync().Returns(Array.Empty<User>()); //Substitute kullanımı
        _userRepository.Setup(s =>
            s.GetAllAsync())
            .ReturnsAsync(Array.Empty<User>());//moq kullanımı


        //act
        var result = await _sut.GetAllAsync();

        //assert
        result.Should().BeEmpty();

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAListOfUsers_WhenUsersExist()
    {
        //arrange
        var expectedUsers = new[]
        {
            new User ()
            {
                Id=1,
                FullName = "Baran Daşdemir",
                Age = 24,
                DateOfBirthDate = new(2001, 08, 11)
            }
        };
        //_userRepository.GetAllAsync().Returns(expectedUsers); //Substitute kullanımı
        _userRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(expectedUsers);//moq kullanımı

        //act
        var users = await _sut.GetAllAsync();

        //assert
        users.Should().ContainSingle(x => x.FullName == "Baran Daşdemir");
    }

}
//mantıklı olan her zaman nsubtite kullanımıdır moq daha karmaşık TEST veritabanıyla bağ kurmamalı