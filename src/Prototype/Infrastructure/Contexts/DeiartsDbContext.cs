﻿using Deiarts.Prototype.Infrastructure.Configurations;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Prototype.Infrastructure.Contexts;

public class DeiartsDbContext : DbContext
{
    public DeiartsDbContext(DbContextOptions<DeiartsDbContext> options) : base(options) { }

    public required DbSet<Feedstock> Feedstocks { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();
        modelBuilder.ApplyConfiguration(new FeedstockConfiguration());
    }
}