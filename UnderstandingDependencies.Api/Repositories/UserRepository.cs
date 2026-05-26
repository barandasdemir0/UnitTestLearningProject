using Microsoft.EntityFrameworkCore;
using UnderstandingDependencies.Api.Context;
using UnderstandingDependencies.Api.Model;

namespace UnderstandingDependencies.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository()
    {
        _context = new();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
