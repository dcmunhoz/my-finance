using Identity.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Data.Context;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}