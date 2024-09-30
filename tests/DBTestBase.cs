namespace DBDockerIntegrationTests;

[Collection(nameof(DBCollectionFixture))]
public class DBTestBase(DbFixture fixture)
{
    protected readonly DbFixture _fixture = fixture;
}
