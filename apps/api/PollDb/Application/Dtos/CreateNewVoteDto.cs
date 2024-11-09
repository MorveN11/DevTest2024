namespace PollDb.Application.Dtos;

public sealed class CreateNewVoteDto
{
    public required Guid OptionId { get; init; }
    public required string VoterEmail { get; init; }
}
