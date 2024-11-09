using PollDb.Application.Dtos;
using PollDb.Domain.Entities;

namespace PollDb.Application.Converters;

public sealed class CreateNewVoteDtoToVote : IConverter<CreateNewVoteDto, Vote>
{
    public Vote Convert(CreateNewVoteDto toConvert)
    {
        return new Vote
        {
            Email = toConvert.VoterEmail,
            OptionId = toConvert.OptionId
        };
    }
}
