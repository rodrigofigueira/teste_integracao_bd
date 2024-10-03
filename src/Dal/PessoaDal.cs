namespace DAL;

public class PessoaDal(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public async Task<Pessoa> Create(string nome)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
                INSERT INTO Pessoa (Nome)
                VALUES (@nome);
                SELECT CAST(SCOPE_IDENTITY() as int);";

        int id = await connection.QuerySingleAsync<int>(query, new { nome });

        return new(id, nome);
    }

    public async Task<Pessoa?> SelectById(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
                SELECT Id, Nome
                FROM Pessoa
                WHERE Id = @id";

        return await connection.QueryFirstOrDefaultAsync<Pessoa>(query, new { id });
    }

    public async Task<int> Count()
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
                SELECT count(*) as total
                FROM Pessoa";

        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<bool> Truncate()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"truncate table Pessoa";
        await connection.ExecuteAsync(query);
        return true;
    }


}
