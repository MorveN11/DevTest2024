namespace PollDb.Domain.Errors;

public sealed class Error
{
    public required string Message { get; init; }
    public required string Details { get; init; }
}
