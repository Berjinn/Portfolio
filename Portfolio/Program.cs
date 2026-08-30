using Portfolio.Repositories;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddOpenApi();
builder.Services.AddScoped<Portfolio.Services.IPortfolioService, Portfolio.Services.PortfolioService>();

builder.Services.AddScoped<
    IPortfolioService,
    PortfolioService>();

builder.Services.AddScoped<
    IPortfolioRepository,
    PortfolioRepository>();

builder.Services.AddScoped<
    Portfolio.Data.ISqlConnectionFactory,
    Portfolio.Data.SqlConnectionFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.MapRazorPages();

app.Run();
