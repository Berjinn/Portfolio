using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages;

public sealed class IndexModel : PageModel
{
    private readonly IPortfolioService _portfolioService;

    public IndexModel(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    public PortfolioProfile Profile { get; private set; } = default!;

    public void OnGet()
    {
        Profile = _portfolioService.GetProfile();
    }
}
