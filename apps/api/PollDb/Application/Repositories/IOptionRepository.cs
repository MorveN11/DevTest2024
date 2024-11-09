using PollDb.Domain.Entities;

namespace PollDb.Application.Repositories;

public interface IOptionRepository : IRepository<Option>
{
    Task<bool> Exists(Guid optionId);

    async Task CreateList(IList<Option> options)
    {
        foreach (Option option in options)
        {
            await Create(option);
        }
    }

    async Task<IDictionary<Guid, List<Option>>> GroupOptionsByPoll()
    {
        IList<Option> options = await GetAll();

        IDictionary<Guid, List<Option>> groups =
            options.GroupBy(o => o.PollId).ToDictionary(g => g.Key, g => g.ToList());

        return groups;
    }
}
