using PollDb.Application.Dtos;
using PollDb.Domain.Entities;

namespace PollDb.Application.Converters;

public sealed class CreateNewPollDtoToPoll : IConverter<CreateNewPollDto, Poll>
{
    public Poll Convert(CreateNewPollDto toConvert)
    {
        var pollId = Guid.NewGuid();

        CreateNewOptionDtoToOption optionConverter = new(pollId);

        return new Poll
        {
            Id = pollId,
            Name = toConvert.Name,
            Options = toConvert.Options.Select(o => optionConverter.Convert(o)).ToList()
        };
    }
}
