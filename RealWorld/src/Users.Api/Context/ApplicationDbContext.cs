using Microsoft.EntityFrameworkCore;
using Users.Api.Models;

namespace Users.Api.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
