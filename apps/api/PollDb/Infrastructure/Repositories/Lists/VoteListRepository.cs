using PollDb.Application.Repositories;
using PollDb.Domain.Entities;

namespace PollDb.Infrastructure.Repositories.Lists;

public sealed class VoteListRepository : IVoteRepository
{
    private readonly IList<Vote> _votes = [];

    public Task<IList<Vote>> GetAll()
    {
        return Task.FromResult(_votes);
    }

    public Task<Vote> Create(Vote entity)
    {
        _votes.Add(entity);

        return Task.FromResult(entity);
    }
}
