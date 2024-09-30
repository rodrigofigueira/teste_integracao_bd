namespace DAL;

public class CreateTablePessoa(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public async Task Execute()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"CREATE table Pessoa(
            id int primary key identity(1,1),
            nome varchar(200) not null unique
        )";
        await connection.ExecuteAsync(query);
    }

}
