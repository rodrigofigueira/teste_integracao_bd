namespace DBDockerIntegrationTests;

[Collection(nameof(DBCollectionFixture))]
public class DBTestBase(DbFixture fixture) : IAsyncLifetime
{
    protected readonly DbFixture _fixture = fixture;

    public async Task DisposeAsync()
    {
        await new PessoaDal(_fixture.ConnectionString).Truncate();
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}
