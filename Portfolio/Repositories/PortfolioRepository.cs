using Microsoft.Data.SqlClient;
using Portfolio.Data;
using Portfolio.Models;
using System.Data;

namespace Portfolio.Repositories;

public sealed class PortfolioRepository : IPortfolioRepository
{


    private readonly ISqlConnectionFactory _connectionFactory;

    public PortfolioRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<PortfolioProfile> GetProfileAsync(
        CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.CreateConnection();

        await using var command = new SqlCommand(
            "dbo.GetPortfolioProfile",
            connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync(cancellationToken);

        await using var reader =
            await command.ExecuteReaderAsync(cancellationToken);

        // 1. Profile
        var profile = await ReadProfileAsync(
            reader,
            cancellationToken);

        // 2. Skills
        await reader.NextResultAsync(cancellationToken);

        var skills = await ReadSkillsAsync(
            reader,
            cancellationToken);

        // 3. Experience
        await reader.NextResultAsync(cancellationToken);

        var experiences = await ReadExperienceRowsAsync(
            reader,
            cancellationToken);

        // 4. Experience Highlights
        await reader.NextResultAsync(cancellationToken);

        var experienceHighlights =
            await ReadChildItemsAsync(
                reader,
                "ExperienceId",
                cancellationToken);

        // 5. Experience Technologies
        await reader.NextResultAsync(cancellationToken);

        var experienceTechnologies =
            await ReadChildItemsAsync(
                reader,
                "ExperienceId",
                cancellationToken);

        // 6. Projects
        await reader.NextResultAsync(cancellationToken);

        var projects = await ReadProjectRowsAsync(
            reader,
            cancellationToken);

        // 7. Project Highlights
        await reader.NextResultAsync(cancellationToken);

        var projectHighlights =
            await ReadChildItemsAsync(
                reader,
                "ProjectId",
                cancellationToken);

        // 8. Project Technologies
        await reader.NextResultAsync(cancellationToken);

        var projectTechnologies =
            await ReadChildItemsAsync(
                reader,
                "ProjectId",
                cancellationToken);

        // 9. Education
        await reader.NextResultAsync(cancellationToken);

        var education = await ReadEducationAsync(
            reader,
            cancellationToken);

        var experienceModels =
            BuildExperiences(
                experiences,
                experienceHighlights,
                experienceTechnologies);

        var projectModels =
            BuildProjects(
                projects,
                projectHighlights,
                projectTechnologies);

        return new PortfolioProfile(
            profile.Name,
            profile.Headline,
            profile.Location,
            profile.Summary,
            new ContactDetails(
                profile.Email,
                profile.LinkedInUrl,
                profile.GitHubUrl,
                profile.WebsiteUrl),
            skills,
            experienceModels,
            projectModels,
            education);
    }

    private static async Task<ProfileRow> ReadProfileAsync(
        SqlDataReader reader,
        CancellationToken cancellationToken)
    {
        if (!await reader.ReadAsync(cancellationToken))
        {
            throw new InvalidOperationException(
                "No profile record was found.");
        }

        return new ProfileRow(
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetString(reader.GetOrdinal("Headline")),
            reader.GetString(reader.GetOrdinal("Location")),
            reader.GetString(reader.GetOrdinal("Summary")),
            reader.GetString(reader.GetOrdinal("Email")),
            GetNullableString(reader, "LinkedInUrl"),
            GetNullableString(reader, "GitHubUrl"),
            GetNullableString(reader, "WebsiteUrl"));
    }

    private static async Task<IReadOnlyList<SkillGroup>> ReadSkillsAsync(
        SqlDataReader reader,
        CancellationToken cancellationToken)
    {
        var items = new List<(string Category, string Item)>();

        while (await reader.ReadAsync(cancellationToken))
        {
            items.Add(
            (
                reader.GetString(reader.GetOrdinal("Category")),
                reader.GetString(reader.GetOrdinal("Item"))
            ));
        }

        return items
            .GroupBy(x => x.Category)
            .Select(group =>
                new SkillGroup(
                    group.Key,
                    group.Select(x => x.Item).ToList()))
            .ToList();
    }

    private static async Task<IReadOnlyList<ExperienceRow>>
        ReadExperienceRowsAsync(
            SqlDataReader reader,
            CancellationToken cancellationToken)
    {
        var rows = new List<ExperienceRow>();

        while (await reader.ReadAsync(cancellationToken))
        {
            rows.Add(
                new ExperienceRow(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Role")),
                    reader.GetString(reader.GetOrdinal("Company")),
                    reader.GetString(reader.GetOrdinal("Location")),
                    reader.GetString(reader.GetOrdinal("Period")),
                    reader.GetString(reader.GetOrdinal("Description"))));
        }

        return rows;
    }

    private static async Task<IReadOnlyList<ProjectRow>>
        ReadProjectRowsAsync(
            SqlDataReader reader,
            CancellationToken cancellationToken)
    {
        var rows = new List<ProjectRow>();

        while (await reader.ReadAsync(cancellationToken))
        {
            rows.Add(
                new ProjectRow(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetString(reader.GetOrdinal("Description")),
                    GetNullableString(reader, "RepositoryUrl"),
                    GetNullableString(reader, "LiveUrl")));
        }

        return rows;
    }

    private static async Task<IReadOnlyList<Education>>
        ReadEducationAsync(
            SqlDataReader reader,
            CancellationToken cancellationToken)
    {
        var items = new List<Education>();

        while (await reader.ReadAsync(cancellationToken))
        {
            items.Add(
                new Education(
                    reader.GetString(reader.GetOrdinal("Institution")),
                    reader.GetString(reader.GetOrdinal("Qualification")),
                    reader.GetString(reader.GetOrdinal("Period")),
                    GetNullableString(reader, "Notes")));
        }

        return items;
    }

    private static async Task<Dictionary<int, IReadOnlyList<string>>>
        ReadChildItemsAsync(
            SqlDataReader reader,
            string foreignKeyColumn,
            CancellationToken cancellationToken)
    {
        var result =
            new Dictionary<int, IReadOnlyList<string>>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var parentId =
                reader.GetInt32(
                    reader.GetOrdinal(foreignKeyColumn));

            var item =
                reader.GetString(
                    reader.GetOrdinal("Item"));

            if (!result.TryGetValue(parentId, out var existing))
            {
                existing = [];
            }

            var values = existing.ToList();
            values.Add(item);

            result[parentId] = values;
        }

        return result;
    }

    private static IReadOnlyList<Experience>
        BuildExperiences(
            IReadOnlyList<ExperienceRow> rows,
            Dictionary<int, IReadOnlyList<string>> highlights,
            Dictionary<int, IReadOnlyList<string>> technologies)
    {
        return rows
            .Select(x =>
                new Experience(
                    x.Role,
                    x.Company,
                    x.Location,
                    x.Period,
                    x.Description,
                    highlights.GetValueOrDefault(x.Id, []),
                    technologies.GetValueOrDefault(x.Id, [])))
            .ToList();
    }

    private static IReadOnlyList<Project>
        BuildProjects(
            IReadOnlyList<ProjectRow> rows,
            Dictionary<int, IReadOnlyList<string>> highlights,
            Dictionary<int, IReadOnlyList<string>> technologies)
    {
        return rows
            .Select(x =>
                new Project(
                    x.Name,
                    x.Description,
                    technologies.GetValueOrDefault(x.Id, []),
                    x.RepositoryUrl,
                    x.LiveUrl,
                    highlights.GetValueOrDefault(x.Id, [])))
            .ToList();
    }

    private static string? GetNullableString(
        SqlDataReader reader,
        string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);

        return reader.IsDBNull(ordinal)
            ? null
            : reader.GetString(ordinal);
    }

    private sealed record ProfileRow(
        string Name,
        string Headline,
        string Location,
        string Summary,
        string Email,
        string? LinkedInUrl,
        string? GitHubUrl,
        string? WebsiteUrl);

    private sealed record ExperienceRow(
        int Id,
        string Role,
        string Company,
        string Location,
        string Period,
        string Description);

    private sealed record ProjectRow(
        int Id,
        string Name,
        string Description,
        string? RepositoryUrl,
        string? LiveUrl);
}