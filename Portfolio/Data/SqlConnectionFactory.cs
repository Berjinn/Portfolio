using Microsoft.Data.SqlClient;

namespace Portfolio.Data;

public sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("PortfolioDatabase")
            ?? throw new InvalidOperationException(
                "The PortfolioDatabase connection string is not configured.");
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}