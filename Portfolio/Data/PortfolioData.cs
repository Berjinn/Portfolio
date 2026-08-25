using Portfolio.Models;

namespace Portfolio.Data;

/// <summary>
/// Resume data exposed by the API.
/// </summary>
public static class PortfolioData
{
    public static readonly PortfolioProfile Profile = new(
        Name: "Berjin John Benadict",
        Headline: "Software Developer | Building scalable .NET solutions",
        Location: "Kanyakumari, Tamil Nadu, India · 629003",
        Summary: "Software Developer with 2+ years of backend experience using ASP.NET Core, Web API, and SQL Server across banking and enterprise domains. Focused on scalable RESTful APIs, database performance, clean architecture, and reliable production systems.",
        Contact: new ContactDetails(
            Email: "berjinberjin90@gmail.com",
            LinkedInUrl: "https://www.linkedin.com/in/berjin-john-benadict-560219225",
            GitHubUrl: "https://github.com/Berjinn/Berjin-Portfolio",
            WebsiteUrl: null),
        Skills:
        [
            new SkillGroup("Microsoft", [".NET Framework", ".NET Core", "ASP.NET MVC", "ASP.NET Web API"]),
            new SkillGroup("Frontend", ["HTML5", "CSS3", "JavaScript", "jQuery", "TypeScript", "Angular 12+"]),
            new SkillGroup("Backend", ["C#", "RESTful APIs", "API Integration", "Dependency Injection", "ADO.NET"]),
            new SkillGroup("Database", ["SQL Server", "SSMS", "Entity Framework", "LINQ", "Stored Procedures"]),
            new SkillGroup("Tools & Practice", ["Git", "Azure DevOps", "TFS", "IIS", "Agile/Scrum", "Debugging"])
        ],
        Experience:
        [
            new Experience(
                Role: "Software Developer",
                Company: "Gemini Software Solutions Pvt Ltd. -  GEMCARDS",
                Location: "Technopark Trivandrum in Kerala",
                Period: "Feb 2025 – Present",
                Description: "Developing backend modules for a card-management platform covering card lifecycle, transaction processing, fraud detection, clearing and settlement, and loyalty management.",
                Highlights:
                [
                    "Developed CMS, FMS, CASS, and LMS modules with ASP.NET Core MVC, ADO.NET, and SQL Server.",
                    "Designed and optimized 20+ stored procedures, reducing query execution time by 30%.",
                    "Built validation, exception handling, approval workflows, and queue-based processing for reliable banking operations.",
                    "Resolved production issues through root-cause analysis, helping maintain stable, high-performance systems."
                ],
                Technologies: ["C#", "ASP.NET Core MVC", "ADO.NET", "SQL Server", "Razor"]),
            new Experience(
                Role: "Junior Software Developer",
                Company: "CKS Solutions · Cloud Kitchen Management System",
                Location: "Tamil Nadu, India",
                Period: "Jun 2023 – Jun 2024",
                Description: "Worked as a full-stack developer on a scalable web application for food ordering, kitchen operations, delivery workflows, and real-time tracking.",
                Highlights:
                [
                    "Built responsive Angular components for order management and customer interaction.",
                    "Developed ASP.NET Core REST APIs and integrated them with frontend services.",
                    "Implemented order tracking, customer management, and vendor-coordination features.",
                    "Deployed applications to IIS and contributed to testing, documentation, and Agile delivery."
                ],
                Technologies: ["Angular", "ASP.NET Core", "Entity Framework", "LINQ", "SQL Server", "IIS"]),
            new Experience(
                Role: "Software Developer",
                Company: "CKS Solutions · WeTeams",
                Location: "Tamil Nadu, India",
                Period: "Jun 2023 – Jun 2024",
                Description: "Contributed to an internal workforce-management application for employee activity, daily footprints, AMS swipe details, and performance tracking.",
                Highlights:
                [
                    "Resolved defects and improved stability across existing application modules.",
                    "Supported employee-activity and daily-footprint features in .NET and Angular.",
                    "Delivered UI fixes with Angular, Bootstrap, and SCSS while using Azure DevOps for collaboration."
                ],
                Technologies: [".NET", "Angular", "Bootstrap", "SCSS", "Azure DevOps"])
        ],
        Projects:
        [
            new Project(
                Name: "GEMCARDS – Card Management System",
                Description: "Enterprise banking application for managing the card lifecycle, transaction processing, fraud detection, clearing and settlement, and loyalty programmes.",
                Technologies: ["ASP.NET Core MVC", "C#", "ADO.NET", "SQL Server", "Razor"],
                RepositoryUrl: null,
                LiveUrl: null,
                Highlights:
                [
                    "Optimized stored procedures and SQL queries to reduce average response time by 30%.",
                    "Implemented business logic, validation, and queue-based approval workflows."
                ]),
            new Project(
                Name: "Cloud Kitchen Management System",
                Description: "Web-based platform that manages food ordering, kitchen operations, delivery workflows, and real-time operational tracking.",
                Technologies: ["Angular", "ASP.NET Core", "Entity Framework", "LINQ", "SQL Server", "IIS"],
                RepositoryUrl: null,
                LiveUrl: null,
                Highlights:
                [
                    "Delivered responsive order-management interfaces and REST API integrations.",
                    "Built features for orders, customers, vendors, and delivery coordination."
                ]),
            new Project(
                Name: "WeTeams",
                Description: "Internal workforce-management platform for monitoring employee activity, project footprints, AMS swipe details, and performance.",
                Technologies: [".NET", "Angular", "Bootstrap", "SCSS", "Azure DevOps"],
                RepositoryUrl: null,
                LiveUrl: null,
                Highlights:
                [
                    "Supported application stability, workflow understanding, and UI enhancements.",
                    "Improved employee tracking and project-head reporting workflows."
                ])
        ],
        Education:
        [
            new Education(
                Institution: "Ponjesly College of Engineering, Anna University",
                Qualification: "Bachelor of Engineering",
                Period: "2018 – 2022",
                Notes: "CGPA: 7.63"),
            new Education(
                Institution: "JSpiders, Rajajinagar",
                Qualification: "Java Full Stack Developer Course",
                Period: "2022 – 2023",
                Notes: "Certification")
        ]);
}
