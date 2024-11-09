using PollDb.Domain.Entities;

namespace PollDb.Application.Repositories;

public interface IVoteRepository : IRepository<Vote>
{
    async Task<IDictionary<Guid, List<Vote>>> GroupVotesByOption()
    {
        IList<Vote> votes = await GetAll();

        IDictionary<Guid, List<Vote>> groups = votes.GroupBy(v => v.OptionId).ToDictionary(g => g.Key, g => g.ToList());

        return groups;
    }
}
