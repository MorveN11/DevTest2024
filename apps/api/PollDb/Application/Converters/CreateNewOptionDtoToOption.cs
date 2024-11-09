using PollDb.Application.Dtos;
using PollDb.Domain.Entities;

namespace PollDb.Application.Converters;

public sealed class CreateNewOptionDtoToOption(Guid pollId) : IConverter<CreateNewOptionDto, Option>
{
    public Option Convert(CreateNewOptionDto toConvert)
    {
        return new Option
        {
            Name = toConvert.Name,
            PollId = pollId
        };
    }
}
