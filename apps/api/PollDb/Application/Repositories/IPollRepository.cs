using PollDb.Domain.Entities;

namespace PollDb.Application.Repositories;

public interface IPollRepository : IRepository<Poll>
{
    async Task<int> EmailAlreadyExists(Guid pollId, string email)
    {
        IList<Poll> polls = await GetAll();

        Poll? poll = polls.FirstOrDefault(p => p.Id == pollId);

        if (poll is null)
        {
            return -1;
        }

        foreach (Option option in poll.Options)
        {
            bool emailExists = option.Votes.Any(v => v.Email == email);

            if (emailExists)
            {
                return -2;
            }
        }

        return 0;
    }
}
