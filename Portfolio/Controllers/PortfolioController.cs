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

    /// <summary>
    /// Returns the full portfolio profile, including skills, work experience, projects, and education.
    /// </summary>
    [HttpGet]
    [ProducesResponseType<PortfolioProfile>(StatusCodes.Status200OK)]
    public ActionResult<PortfolioProfile> Get() => Ok(_portfolioService.GetProfile());

    /// <summary>
    /// Returns the portfolio projects for project-focused pages or widgets.
    /// </summary>
    [HttpGet("projects")]
    [ProducesResponseType<IReadOnlyList<Project>>(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<Project>> GetProjects() => Ok(_portfolioService.GetProfile().Projects);
}
