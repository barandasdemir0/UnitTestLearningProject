using Microsoft.EntityFrameworkCore;
using Users.Api.Context;
using Users.Api.Models;

namespace Users.Api.Repositories;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{

    public async Task<bool> CreateAsync(User user, CancellationToken cancellation = default)
    {
        await context.AddAsync(user, cancellation);
        var result = await context.SaveChangesAsync(cancellation);
        return result > 0 ? true : false;
    }

    public async Task<bool> DeleteAsync(User user, CancellationToken cancellation = default)
    {
        context.Remove(user);
        var result = await context.SaveChangesAsync(cancellation);
        return result > 0 ? true : false;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await context.Users.ToListAsync(cancellation);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        return await context.Users.FirstOrDefaultAsync(p => p.Id == id, cancellation);
    }

    public async Task<bool> NameIsExistAsync(string fullName, CancellationToken cancellation = default)
    {
        return await context.Users.AnyAsync(p => p.FullName == fullName, cancellation);
    }
}