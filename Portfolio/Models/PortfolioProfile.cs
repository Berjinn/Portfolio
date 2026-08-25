namespace Portfolio.Models;

/// <summary>
/// The information displayed in a developer portfolio.
/// Update the placeholder content in <c>PortfolioData</c> with your own resume details.
/// </summary>
public sealed record PortfolioProfile(
    string Name,
    string Headline,
    string Location,
    string Summary,
    ContactDetails Contact,
    IReadOnlyList<SkillGroup> Skills,
    IReadOnlyList<Experience> Experience,
    IReadOnlyList<Project> Projects,
    IReadOnlyList<Education> Education);

public sealed record ContactDetails(
    string Email,
    string? LinkedInUrl,
    string? GitHubUrl,
    string? WebsiteUrl);

public sealed record SkillGroup(string Category, IReadOnlyList<string> Items);

public sealed record Experience(
    string Role,
    string Company,
    string Location,
    string Period,
    string Description,
    IReadOnlyList<string> Highlights,
    IReadOnlyList<string> Technologies);

public sealed record Project(
    string Name,
    string Description,
    IReadOnlyList<string> Technologies,
    string? RepositoryUrl,
    string? LiveUrl,
    IReadOnlyList<string> Highlights);

public sealed record Education(
    string Institution,
    string Qualification,
    string Period,
    string? Notes);
