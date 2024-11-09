namespace PollDb.Application.Dtos;

public sealed class CreateNewPollDto
{
    public required string Name { get; init; }

    public required IList<CreateNewOptionDto> Options { get; init; }
}
