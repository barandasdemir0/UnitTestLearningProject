using Users.Api.Dtos;
using Users.Api.Models;

namespace Users.Api.Services;

public interface IUserService
{
    Task<List<User>> GetAllAsync(CancellationToken cancellation = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<bool> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellation = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellation = default);
}
