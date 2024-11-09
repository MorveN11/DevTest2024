using PollDb.Domain.Entities;

namespace PollDb.Application.Responses;

public sealed class GetOptionResponse
{
    public GetOptionResponse(Option option)
    {
        Id = option.Id;
        Name = option.Name;
        Votes = option.Votes.Count;
    }

    public Guid Id { get; }
    public string Name { get; }
    public int Votes { get; }
}

public sealed class GetPollResponse
{
    public GetPollResponse(Poll poll)
    {
        Id = poll.Id;
        Name = poll.Name;
        Options = poll.Options.Select(o => new GetOptionResponse(o)).ToList();
    }

    public Guid Id { get; }
    public string Name { get; }
    public IList<GetOptionResponse> Options { get; }
}
