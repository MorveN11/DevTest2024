using Microsoft.AspNetCore.Mvc;
using PollDb.Application.Converters;
using PollDb.Application.Dtos;
using PollDb.Application.Repositories;
using PollDb.Application.Responses;
using PollDb.Domain.Entities;

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
        Poll poll = new CreateNewPollDtoToPoll().Convert(request);

        Poll responsePoll = await pollRepository.Create(poll);

        GetPollResponse response = new(responsePoll);

        return Results.Ok(response);
    }

    [HttpPost("{pollId:guid}/votes")]
    public async Task<IResult> PostVote([FromRoute] Guid pollId, [FromBody] CreateNewVoteDto request)
    {
        Vote vote = new CreateNewVoteDtoToVote().Convert(request);

        Vote responseVote = await voteRepository.Create(vote);

        CreateVoteResponse response = new(responseVote, pollId);

        return Results.Ok(response);
    }
}
