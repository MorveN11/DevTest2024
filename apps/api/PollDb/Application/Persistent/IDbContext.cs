using Microsoft.EntityFrameworkCore;
using PollDb.Domain.Entities;

namespace PollDb.Application.Persistent;

public interface IDbContext
{
    DbSet<Option> Options { get; }
    DbSet<Poll> Polls { get; }
    DbSet<Vote> Votes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
