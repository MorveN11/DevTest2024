using PollDb.Application.Repositories;
using PollDb.Domain.Entities;

namespace PollDb.Infrastructure.Repositories.Lists;

public sealed class PollListRepository(IOptionRepository optionRepository) : IPollRepository
{
    private readonly IList<Poll> _polls = [];

    public async Task<IList<Poll>> GetAll()
    {
        IDictionary<Guid, List<Option>> options = await optionRepository.GroupOptionsByPoll();

        foreach (Poll poll in _polls)
        {
            if (options.TryGetValue(poll.Id, out List<Option>? pollOptions))
            {
                poll.Options = pollOptions;
            }
        }

        return _polls;
    }

    public async Task<Poll> Create(Poll entity)
    {
        _polls.Add(entity);

        await optionRepository.CreateList(entity.Options);

        return entity;
    }
}
