using PollDb.Domain.Entities;

namespace PollDb.Application.Repositories;

public interface IOptionRepository : IRepository<Option>
{
    async Task<string> CreateList(IList<Option> options)
    {
        foreach (Option option in options)
        {
            await Create(option);
        }

        return "Options Created Successfully";
    }

    async Task<IDictionary<Guid, List<Option>>> GroupOptionsByPoll()
    {
        IList<Option> options = await GetAll();

        IDictionary<Guid, List<Option>> groups =
            options.GroupBy(o => o.PollId).ToDictionary(g => g.Key, g => g.ToList());

        return groups;
    }
}
