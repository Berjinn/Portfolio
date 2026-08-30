using Microsoft.Data.SqlClient;

namespace Portfolio.Data;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}