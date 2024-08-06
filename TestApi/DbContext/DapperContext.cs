using System.Data;
using Microsoft.Data.SqlClient;

namespace TestApi.Config;

public class DapperContext
{
    private readonly string _connectionString;
    
    public DapperContext(IConfiguration configuration)
    {
        var connectionModel = configuration.GetSection("Connections:dbetica").Get<ConnectionModel>();
        _connectionString = connectionModel.ConnectionString;
    }
    
    public IDbConnection CreateConnection() =>
        new SqlConnection(_connectionString);
}