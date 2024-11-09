namespace PollDb.Domain.Errors;

public sealed class ValidationError
{
    public required string Message { get; init; }
    public required string[] Details { get; init; }
}
