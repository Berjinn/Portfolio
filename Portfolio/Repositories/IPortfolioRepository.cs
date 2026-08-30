using Portfolio.Models;

namespace Portfolio.Repositories;

public interface IPortfolioRepository
{
    Task<PortfolioProfile> GetProfileAsync(
        CancellationToken cancellationToken = default);
}