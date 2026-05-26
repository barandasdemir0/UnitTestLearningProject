using Microsoft.EntityFrameworkCore;
using UnderstandingDependencies.Api.Model;

namespace UnderstandingDependencies.Api.Context;

public class ApplicationDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=BARANPC\\SQLEXPRESS;Database=UnitTestDb;integrated security=True; TrustServerCertificate=True;");
    }
    public DbSet<User> Users { get; set; }
}
