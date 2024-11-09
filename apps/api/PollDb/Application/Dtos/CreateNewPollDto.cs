namespace PollDb.Application.Dtos;

public sealed class CreateNewOptionDto
{
    public required string Name { get; init; }
}

public sealed class CreateNewPollDto
{
    public required string Name { get; init; }

    public required IList<CreateNewOptionDto> Options { get; init; }
}
