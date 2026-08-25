using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Services;

/// <summary>Central portfolio-content service. It can later use a database without changing the UI or API.</summary>
public sealed class PortfolioService : IPortfolioService
{
    public PortfolioProfile GetProfile() => PortfolioData.Profile;
}
