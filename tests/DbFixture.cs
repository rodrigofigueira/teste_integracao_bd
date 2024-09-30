namespace DBDockerIntegrationTests;

public class DbFixture : IAsyncLifetime
{
    public string ConnectionString { get; private set; } = default!;
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
                    .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                    .Build();

    public async Task InitializeAsync()
    {
        await _msSqlContainer.StartAsync();
        ConnectionString = _msSqlContainer.GetConnectionString();
        await new CreateDatabase(ConnectionString, "DBTeste").Execute();
        await new CreateTablePessoa(ConnectionString).Execute();
    }

    public async Task DisposeAsync()
    {
        await _msSqlContainer.StopAsync();
    }
}
