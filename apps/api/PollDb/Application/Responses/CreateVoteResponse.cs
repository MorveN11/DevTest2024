using PollDb.Domain.Entities;

namespace PollDb.Application.Responses;

public class CreateVoteResponse
{
    public CreateVoteResponse(Vote vote, Guid pollId)
    {
        Id = vote.Id;
        PollId = pollId;
        OptionId = vote.OptionId;
        VoterEmail = vote.Email;
    }

    public Guid Id { get; }
    public Guid PollId { get; }
    public Guid OptionId { get; }
    public string VoterEmail { get; }
}
