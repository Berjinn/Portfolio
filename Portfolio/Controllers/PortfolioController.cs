using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/portfolio")]
public sealed class PortfolioController : ControllerBase
{
    private readonly IPortfolioService _portfolioService;

    public PortfolioController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    [HttpGet]
    [ProducesResponseType<PortfolioProfile>(StatusCodes.Status200OK)]
    public async Task<ActionResult<PortfolioProfile>> Get(
       CancellationToken cancellationToken)
    {
        var profile =
            await _portfolioService.GetProfileAsync(cancellationToken);

        return Ok(profile);
    }
}



/// <summary>
/// Returns the full portfolio profile, including skills, work experience, projects, and education.
/// </summary>
//[HttpGet]
//[ProducesResponseType<PortfolioProfile>(StatusCodes.Status200OK)]
//public async Task<ActionResult<PortfolioProfile>> Get(CancellationToken cancellationToken) =>
//    Ok(await _portfolioService.GetProfileAsync(cancellationToken));

/// <summary>
/// Returns the portfolio projects for project-focused pages or widgets.
/// </summary>
//[HttpGet("projects")]
//[ProducesResponseType<IReadOnlyList<Project>>(StatusCodes.Status200OK)]
//public async Task<ActionResult<IReadOnlyList<Project>>> GetProjects(CancellationToken cancellationToken) =>
//    Ok((await _portfolioService.GetProfileAsync(cancellationToken)).Projects);
//}
