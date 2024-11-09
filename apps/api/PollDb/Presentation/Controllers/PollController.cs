using Microsoft.AspNetCore.Mvc;
using PollDb.Application.Repositories;

namespace PollDb.Presentation.Controllers;

[ApiController]
[Route("api/v1/polls")]
public class PollController(
    IOptionRepository optionRepository,
    IPollRepository pollRepository,
    IVoteRepository voteRepository)
{
    [HttpGet]
    public Task<IResult> GetAllPolls()
    {
        return null;
    }

    [HttpPost]
    public Task<IResult> PostPoll()
    {
        return null;
    }

    [HttpPost("{optionId:guid}/votes")]
    public Task<IResult> PostVote([FromRoute] Guid optionId)
    {
        return null;
    }
}
