using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Tests_xUnit.DAL;

public class DbMock : ApplicationDbContext
{
    public DbMock(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}