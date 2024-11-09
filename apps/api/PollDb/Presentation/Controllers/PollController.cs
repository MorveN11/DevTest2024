using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PollDb.Application.Converters;
using PollDb.Application.Dtos;
using PollDb.Application.Repositories;
using PollDb.Application.Responses;
using PollDb.Application.Validators;
using PollDb.Domain.Entities;
using PollDb.Domain.Errors;

namespace PollDb.Presentation.Controllers;

[ApiController]
[Route("api/v1/polls")]
public class PollController(
    IOptionRepository optionRepository,
    IPollRepository pollRepository,
    IVoteRepository voteRepository)
{
    [HttpGet]
    public async Task<IResult> GetAllPolls()
    {
        IList<Poll> polls = await pollRepository.GetAll();

        IList<GetPollResponse> response = polls.Select(p => new GetPollResponse(p)).ToList();

        return Results.Ok(response);
    }

    [HttpPost]
    public async Task<IResult> PostPoll([FromBody] CreateNewPollDto request)
    {
        ValidationResult validation = new CreateNewPollValidator().Validate(request);

        if (!validation.IsValid)
        {
            return Results.Json(
                new ValidationError
                {
                    Message = "Unable to create the poll",
                    Details = validation.Errors.Select(e => e.ErrorMessage).ToArray()
                }, statusCode: StatusCodes.Status400BadRequest, contentType: "application/problem+json");
        }

        Poll poll = new CreateNewPollDtoToPoll().Convert(request);

        if (!poll.IsOptionsValid)
        {
            return Results.Json(
                new Error
                {
                    Message = "Unable to create the poll",
                    Details = "Poll must have at least two options"
                }, statusCode: StatusCodes.Status400BadRequest, contentType: "application/problem+json");
        }

        Poll responsePoll = await pollRepository.Create(poll);

        GetPollResponse response = new(responsePoll);

        return Results.Ok(response);
    }

    [HttpPost("{pollId:guid}/votes")]
    public async Task<IResult> PostVote([FromRoute] Guid pollId, [FromBody] CreateNewVoteDto request)
    {
        ValidationResult validation = new CreateNewVoteValidator().Validate(request);

        if (!validation.IsValid)
        {
            return Results.Json(
                new ValidationError
                {
                    Message = "Unable to submit the vote",
                    Details = validation.Errors.Select(e => e.ErrorMessage).ToArray()
                }, statusCode: StatusCodes.Status400BadRequest, contentType: "application/problem+json");
        }

        bool optionExists = await optionRepository.Exists(request.OptionId);

        if (!optionExists)
        {
            return Results.Json(
                new Error
                {
                    Message = "Unable to submit the vote",
                    Details = "OptionId must exist."
                },
                statusCode: StatusCodes.Status404NotFound,
                contentType: "application/problem+json");
        }

        int emailResult = await pollRepository.EmailAlreadyExists(pollId, request.VoterEmail);

        if (emailResult == -1)
        {
            return Results.Json(
                new Error
                {
                    Message = "Unable to submit the vote",
                    Details = "Poll must exist."
                },
                statusCode: StatusCodes.Status404NotFound,
                contentType: "application/problem+json");
        }

        if (emailResult == -2)
        {
            return Results.Json(
                new Error
                {
                    Message = "Unable to submit the vote",
                    Details = "Each poll allows only one vote per email address."
                },
                statusCode: StatusCodes.Status409Conflict,
                contentType: "application/problem+json");
        }


        Vote vote = new CreateNewVoteDtoToVote().Convert(request);

        Vote responseVote = await voteRepository.Create(vote);

        CreateVoteResponse response = new(responseVote, pollId);

        return Results.Ok(response);
    }
}
