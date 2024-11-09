using FluentValidation;
using PollDb.Application.Dtos;

namespace PollDb.Application.Validators;

public class CreateNewVoteValidator : AbstractValidator<CreateNewVoteDto>
{
    public CreateNewVoteValidator()
    {
        RuleFor(v => v.VoterEmail).NotEmpty().WithMessage("VoterEmail  must not be empty").EmailAddress()
            .WithMessage("VoterEmail must be a valid email address");
    }
}
