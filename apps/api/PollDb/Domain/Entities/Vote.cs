namespace PollDb.Domain.Entities;

public sealed class Vote : IEntity
{
    public required string Email { get; init; }
    public required Guid OptionId { get; init; }
    public Option Option { get; init; } = default!;

    public Guid Id { get; init; } = Guid.NewGuid();
}
