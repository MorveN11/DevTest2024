using Microsoft.EntityFrameworkCore;
using PollDb.Application.Persistent;
using PollDb.Domain.Entities;

namespace PollDb.Infrastructure.Persistent;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IDbContext
{
    public DbSet<Option> Options { get; init; }
    public DbSet<Poll> Polls { get; init; }
    public DbSet<Vote> Votes { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
