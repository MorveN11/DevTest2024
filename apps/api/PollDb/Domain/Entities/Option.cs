namespace PollDb.Domain.Entities;

public sealed class Option : IEntity
{
    public required string Name { get; init; }
    public required Guid PollId { get; init; }

    public Poll Poll { get; init; } = default!;

    public IList<Vote> Votes { get; set; } = [];
    public Guid Id { get; init; } = Guid.NewGuid();

    public bool EmailAlreadyExists(string email)
    {
        return Votes.Any(v => v.Email == email);
    }
}
