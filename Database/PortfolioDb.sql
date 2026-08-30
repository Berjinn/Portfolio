/* Run this script in SQL Server Management Studio (SSMS). */
IF DB_ID(N'PortfolioDb') IS NULL
    CREATE DATABASE PortfolioDb;
GO

USE PortfolioDb;
GO

CREATE TABLE dbo.Profile (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Headline NVARCHAR(250) NOT NULL,
    Location NVARCHAR(250) NOT NULL,
    Summary NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(320) NOT NULL,
    LinkedInUrl NVARCHAR(500) NULL,
    GitHubUrl NVARCHAR(500) NULL,
    WebsiteUrl NVARCHAR(500) NULL
);

CREATE TABLE dbo.Skill (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Category NVARCHAR(100) NOT NULL,
    Item NVARCHAR(150) NOT NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.Experience (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Role NVARCHAR(150) NOT NULL,
    Company NVARCHAR(250) NOT NULL,
    Location NVARCHAR(250) NOT NULL,
    Period NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.ExperienceHighlight (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ExperienceId INT NOT NULL FOREIGN KEY REFERENCES dbo.Experience(Id),
    Item NVARCHAR(MAX) NOT NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.ExperienceTechnology (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ExperienceId INT NOT NULL FOREIGN KEY REFERENCES dbo.Experience(Id),
    Item NVARCHAR(150) NOT NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.Project (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(250) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    RepositoryUrl NVARCHAR(500) NULL,
    LiveUrl NVARCHAR(500) NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.ProjectHighlight (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProjectId INT NOT NULL FOREIGN KEY REFERENCES dbo.Project(Id),
    Item NVARCHAR(MAX) NOT NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.ProjectTechnology (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProjectId INT NOT NULL FOREIGN KEY REFERENCES dbo.Project(Id),
    Item NVARCHAR(150) NOT NULL,
    DisplayOrder INT NOT NULL
);

CREATE TABLE dbo.Education (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Institution NVARCHAR(250) NOT NULL,
    Qualification NVARCHAR(200) NOT NULL,
    Period NVARCHAR(100) NOT NULL,
    Notes NVARCHAR(500) NULL,
    DisplayOrder INT NOT NULL
);
GO

INSERT dbo.Profile (Name, Headline, Location, Summary, Email, LinkedInUrl, GitHubUrl)
VALUES (N'Berjin John Benadict', N'Full-Stack .NET Developer | Building scalable web solutions',
N'Kanyakumari, Tamil Nadu, India · 629003',
N'Full-stack .NET developer with 2+ years of experience building web applications with ASP.NET Core MVC, Blazor, Web API, and SQL Server. I create reliable user experiences, scalable APIs, and maintainable database solutions across banking and enterprise domains.',
N'berjinberjin90@gmail.com', N'https://www.linkedin.com/in/berjin-john-benadict-560219225', N'https://github.com/Berjinn/Berjin-Portfolio');

INSERT dbo.Skill (Category, Item, DisplayOrder) VALUES
(N'Microsoft', N'.NET Framework', 1), (N'Microsoft', N'.NET Core', 2), (N'Microsoft', N'ASP.NET Core MVC', 3), (N'Microsoft', N'Blazor', 4), (N'Microsoft', N'ASP.NET Web API', 5),
(N'Frontend', N'HTML5', 10), (N'Frontend', N'CSS3', 11), (N'Frontend', N'JavaScript', 12), (N'Frontend', N'jQuery', 13), (N'Frontend', N'TypeScript', 14), (N'Frontend', N'Blazor', 15), (N'Frontend', N'Angular 12+', 16),
(N'Backend', N'C#', 20), (N'Backend', N'RESTful APIs', 21), (N'Backend', N'API Integration', 22), (N'Backend', N'Dependency Injection', 23), (N'Backend', N'ADO.NET', 24),
(N'Database', N'SQL Server', 30), (N'Database', N'SSMS', 31), (N'Database', N'Entity Framework', 32), (N'Database', N'LINQ', 33), (N'Database', N'Stored Procedures', 34),
(N'Tools & Practice', N'Git', 40), (N'Tools & Practice', N'Azure DevOps', 41), (N'Tools & Practice', N'TFS', 42), (N'Tools & Practice', N'IIS', 43), (N'Tools & Practice', N'Agile/Scrum', 44), (N'Tools & Practice', N'Debugging', 45);

INSERT dbo.Experience (Role, Company, Location, Period, Description, DisplayOrder) VALUES
(N'Software Developer', N'Gemini Software Solutions Pvt Ltd. - GEMCARDS', N'Technopark Trivandrum in Kerala', N'Feb 2025 – Present', N'Developing backend modules for a card-management platform covering card lifecycle, transaction processing, fraud detection, clearing and settlement, and loyalty management.', 1),
(N'Junior Software Developer', N'CKS Solutions · Cloud Kitchen Management System', N'Tamil Nadu, India', N'Jun 2023 – Jun 2024', N'Worked as a full-stack developer on a scalable web application for food ordering, kitchen operations, delivery workflows, and real-time tracking.', 2),
(N'Software Developer', N'CKS Solutions · WeTeams', N'Tamil Nadu, India', N'Jun 2023 – Jun 2024', N'Contributed to an internal workforce-management application for employee activity, daily footprints, AMS swipe details, and performance tracking.', 3);

INSERT dbo.ExperienceHighlight (ExperienceId, Item, DisplayOrder) VALUES
(1, N'Developed CMS, FMS, CASS, and LMS modules with ASP.NET Core MVC, ADO.NET, and SQL Server.', 1), (1, N'Designed and optimized 20+ stored procedures, reducing query execution time by 30%.', 2), (1, N'Built validation, exception handling, approval workflows, and queue-based processing for reliable banking operations.', 3), (1, N'Resolved production issues through root-cause analysis, helping maintain stable, high-performance systems.', 4),
(2, N'Built responsive Angular components for order management and customer interaction.', 1), (2, N'Developed ASP.NET Core REST APIs and integrated them with frontend services.', 2), (2, N'Implemented order tracking, customer management, and vendor-coordination features.', 3), (2, N'Deployed applications to IIS and contributed to testing, documentation, and Agile delivery.', 4),
(3, N'Resolved defects and improved stability across existing application modules.', 1), (3, N'Supported employee-activity and daily-footprint features in .NET and Angular.', 2), (3, N'Delivered UI fixes with Angular, Bootstrap, and SCSS while using Azure DevOps for collaboration.', 3);

INSERT dbo.ExperienceTechnology (ExperienceId, Item, DisplayOrder) VALUES
(1, N'C#', 1), (1, N'ASP.NET Core MVC', 2), (1, N'ADO.NET', 3), (1, N'SQL Server', 4), (1, N'Razor', 5),
(2, N'Angular', 1), (2, N'ASP.NET Core', 2), (2, N'Entity Framework', 3), (2, N'LINQ', 4), (2, N'SQL Server', 5), (2, N'IIS', 6),
(3, N'.NET', 1), (3, N'Angular', 2), (3, N'Bootstrap', 3), (3, N'SCSS', 4), (3, N'Azure DevOps', 5);

INSERT dbo.Project (Name, Description, RepositoryUrl, LiveUrl, DisplayOrder) VALUES
(N'GEMCARDS – Card Management System', N'Enterprise banking application for managing the card lifecycle, transaction processing, fraud detection, clearing and settlement, and loyalty programmes.', NULL, NULL, 1),
(N'Cloud Kitchen Management System', N'Web-based platform that manages food ordering, kitchen operations, delivery workflows, and real-time operational tracking.', NULL, NULL, 2),
(N'WeTeams', N'Internal workforce-management platform for monitoring employee activity, project footprints, AMS swipe details, and performance.', NULL, NULL, 3);

INSERT dbo.ProjectHighlight (ProjectId, Item, DisplayOrder) VALUES
(1, N'Optimized stored procedures and SQL queries to reduce average response time by 30%.', 1), (1, N'Implemented business logic, validation, and queue-based approval workflows.', 2),
(2, N'Delivered responsive order-management interfaces and REST API integrations.', 1), (2, N'Built features for orders, customers, vendors, and delivery coordination.', 2),
(3, N'Supported application stability, workflow understanding, and UI enhancements.', 1), (3, N'Improved employee tracking and project-head reporting workflows.', 2);

INSERT dbo.ProjectTechnology (ProjectId, Item, DisplayOrder) VALUES
(1, N'ASP.NET Core MVC', 1), (1, N'C#', 2), (1, N'ADO.NET', 3), (1, N'SQL Server', 4), (1, N'Razor', 5),
(2, N'Angular', 1), (2, N'ASP.NET Core', 2), (2, N'Entity Framework', 3), (2, N'LINQ', 4), (2, N'SQL Server', 5), (2, N'IIS', 6),
(3, N'.NET', 1), (3, N'Angular', 2), (3, N'Bootstrap', 3), (3, N'SCSS', 4), (3, N'Azure DevOps', 5);

INSERT dbo.Education (Institution, Qualification, Period, Notes, DisplayOrder) VALUES
(N'Ponjesly College of Engineering, Anna University', N'Bachelor of Engineering', N'2018 – 2022', N'CGPA: 7.63', 1),
(N'JSpiders, Rajajinagar', N'Java Full Stack Developer Course', N'2022 – 2023', N'Certification', 2);
GO
