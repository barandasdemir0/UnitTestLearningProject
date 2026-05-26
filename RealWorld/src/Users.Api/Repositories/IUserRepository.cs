using Users.Api.Dtos;
using Users.Api.Models;

namespace Users.Api.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync(CancellationToken cancellation = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<bool> CreateAsync(User user, CancellationToken cancellation = default);
    Task<bool> NameIsExistAsync(string fullName, CancellationToken cancellation = default);
    Task<bool> DeleteAsync(User user, CancellationToken cancellation = default);
}
