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
