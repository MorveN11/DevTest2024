namespace PollDb.Domain.Entities;

public sealed class Poll : IEntity
{
    public required string Name { get; init; }
    public IList<Option> Options { get; set; } = [];

    public Guid Id { get; init; } = Guid.NewGuid();
}
