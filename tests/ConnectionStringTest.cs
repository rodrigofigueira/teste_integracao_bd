namespace DBDockerIntegrationTests;

public class ConnectionStringTest(DbFixture fixture) : DBTestBase(fixture)
{
    [Fact]
    public void GetConnectionStringRetornaValor()
    {
        //arrange

        //act
        string connectionString = _fixture.ConnectionString;

        //assert
        Assert.NotNull(connectionString);
    }
}