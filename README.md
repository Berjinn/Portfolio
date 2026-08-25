# Resume Portfolio API

A C#/.NET Web API designed to back a personal portfolio or resume website. It exposes professional profile information, skills, experience, projects, and education as JSON.

## Run it

From the `Portfolio` folder:

```powershell
dotnet run
```

Then request:

- `GET /api/portfolio` for the complete profile
- `GET /api/portfolio/projects` for projects only

During development, the OpenAPI document is available at `/openapi/v1.json`.

## Customize your resume

Your resume details are maintained in `Portfolio/Data/PortfolioData.cs`. Add your LinkedIn and GitHub URLs there when available; the website will automatically show the links.

## Project structure

- `Controllers/` — public Web API endpoints
- `Data/` — current resume-data source
- `Models/` — typed portfolio records
- `Services/` — shared service used by the API and Razor pages
- `Pages/` — Razor Page entry points
- `Pages/Shared/` — layout and reusable section partials
- `wwwroot/` — CSS, images, and browser assets
