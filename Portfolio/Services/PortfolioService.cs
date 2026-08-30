using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Services;

public sealed class PortfolioService : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioService(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public Task<PortfolioProfile> GetProfileAsync(
        CancellationToken cancellationToken = default)
    {
        return _portfolioRepository.GetProfileAsync(cancellationToken);
    }
}