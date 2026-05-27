using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Users.Api.Controllers;
using Users.Api.Dtos;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Test.Unit;

public class UserControllerTests
{

    private readonly UsersController _sut;
    private readonly IUserService _userService = Substitute.For<IUserService>();
    public UserControllerTests()
    {
        _sut = new(_userService);
    }


    [Fact]
    public async Task GetAll_ShouldReturnUsers()
    {
        //arrange
        _userService.GetAllAsync().Returns(Enumerable.Empty<User>().ToList());

        //act
        var result = (OkObjectResult)await _sut.GetAll(default);


        //assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_ShouldReturnUser()
    {
        //arrange
        var userId = Guid.CreateVersion7();
        User user = new()
        {
            Id = userId,
            FullName = "Baran Daşdemir"
        };

        _userService.GetByIdAsync(userId).Returns(user);


        //act
        var result = (OkObjectResult)await _sut.GetById(userId, default);


        //assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Create_ShouldReturnTrue()
    {
        CreateUserDto request = new("Baran Daşdemir");
        _userService.CreateAsync(request).Returns(true);

        var result = (OkObjectResult)await _sut.Create(request, default);

        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Delete_ShouldReturnTrue()
    {
        var userId = Guid.CreateVersion7();
        _userService.DeleteByIdAsync(userId).Returns(true);

        var result = (OkObjectResult)await _sut.Delete(userId, default);

        result.StatusCode.Should().Be(200);
    }



}
