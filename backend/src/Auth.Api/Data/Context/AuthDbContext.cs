using Auth.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Api.Data.Context;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}