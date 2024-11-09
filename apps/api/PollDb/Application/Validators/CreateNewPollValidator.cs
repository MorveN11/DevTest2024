using FluentValidation;
using PollDb.Application.Dtos;

namespace PollDb.Application.Validators;

public class CreateNewPollValidator : AbstractValidator<CreateNewPollDto>
{
    public CreateNewPollValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Poll name must not be empty").Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Poll name must only contain letters, numbers, and spaces");

        RuleForEach(p => p.Options)
            .ChildRules(option =>
                option.RuleFor(op => op.Name).NotEmpty().WithMessage("Poll option must not be empty"));
    }
}
