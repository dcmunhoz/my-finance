﻿using System.Reflection;
using Finance.Domain.Aggregates;
using Finance.Infra.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Persistence;

public class FinanceDbContext : DbContext
{
    public DbSet<Category> Categories { get; init; }
    
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) 
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        base.OnModelCreating(modelBuilder);
    }
}