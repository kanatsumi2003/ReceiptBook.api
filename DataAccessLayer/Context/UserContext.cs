using System.Collections.Immutable;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public class UserContext : Microsoft.EntityFrameworkCore.DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.ID);
    }
    
}