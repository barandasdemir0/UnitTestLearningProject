using FluentValidation;
using System.Diagnostics;
using Users.Api.Dtos;
using Users.Api.Models;
using Users.Api.Repositories;
using Users.Api.Validator;

namespace Users.Api.Services;

public sealed class UserService(IUserRepository userRepository, ILogger<User> logger) : IUserService
{
    public async Task<bool> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellation = default)
    {
        CreateUserValidator validationRules = new();
        var result = validationRules.Validate(createUserDto);
        if (!result.IsValid)
        {
            throw new ValidationException(string.Join(", ", result.Errors.Select(s => s.ErrorMessage)));
        }

        var nameisExist = await userRepository.NameIsExistAsync(createUserDto.FullName, cancellation);
        if (nameisExist)
        {
            throw new ArgumentException("Name already exist");
        }

        User user = new()
        {
            Id = Guid.CreateVersion7(),
            FullName = createUserDto.FullName
        };
        logger.LogInformation("creating user with id : {0} and name : {1}", user.Id, user.FullName);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await userRepository.CreateAsync(user, cancellation);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong while creating a user");
            throw;
        }
        finally
        {
            stopWatch.Stop();
            logger.LogInformation("user with id : {0} created in {1}ms", user.Id, stopWatch.ElapsedMilliseconds);
        }
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        User? user = await userRepository.GetByIdAsync(id, cancellation);
        if (user is null)
        {
            throw new ArgumentException("user not fount");
        }
        logger.LogInformation("Deleting user with id : {0}", user.Id);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await userRepository.DeleteAsync(user, cancellation);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong while deleting a user");
            throw;
        }
        finally
        {
            stopWatch.Stop();
            logger.LogInformation("user with id : {0} deleted in {1}ms", user.Id, stopWatch.ElapsedMilliseconds);
        }
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellation = default)
    {
        logger.LogInformation("retrieving all user");
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await userRepository.GetAllAsync( cancellation);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong while retrieving a user");
            throw;
        }
        finally
        {
            stopWatch.Stop();
            logger.LogInformation("all user retrieved in {0}ms", stopWatch.ElapsedMilliseconds);
        }
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        logger.LogInformation("retrieving user with id:{0}",id);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await userRepository.GetByIdAsync(id,cancellation);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong while retrieving user with id:{0}",id);
            throw;
        }
        finally
        {
            stopWatch.Stop();
            logger.LogInformation("user with id:{0} retrieved in {1}ms",id, stopWatch.ElapsedMilliseconds);
        }
    }
}