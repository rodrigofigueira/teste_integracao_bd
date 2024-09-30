namespace DAL;

public class CreateDatabase(string connectionString, string databaseName)
{
    private readonly string _connectionString = connectionString;
    private readonly string databaseName = databaseName;

    public async Task Execute()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = $"CREATE DATABASE {databaseName}";
        await connection.ExecuteAsync(query);
    }
}
