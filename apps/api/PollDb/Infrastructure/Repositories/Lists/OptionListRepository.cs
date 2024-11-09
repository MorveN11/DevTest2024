using PollDb.Application.Repositories;
using PollDb.Domain.Entities;

namespace PollDb.Infrastructure.Repositories.Lists;

public sealed class OptionListRepository(IVoteRepository voteRepository) : IOptionRepository
{
    private readonly IList<Option> _options = [];

    public async Task<IList<Option>> GetAll()
    {
        IDictionary<Guid, List<Vote>> votes = await voteRepository.GroupVotesByOption();

        foreach (Option option in _options)
        {
            if (votes.TryGetValue(option.Id, out List<Vote> optionVotes))
            {
                option.Votes = optionVotes;
            }
        }

        return _options;
    }

    public Task<Option> Create(Option entity)
    {
        _options.Add(entity);

        return Task.FromResult(entity);
    }

    public Task<bool> Exists(Guid optionId)
    {
        return Task.FromResult(_options.Any(o => o.Id == optionId));
    }
}
