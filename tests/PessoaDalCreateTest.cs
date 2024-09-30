namespace DBDockerIntegrationTests;

public class PessoaDalCreateTest(DbFixture _fixture) : DBTestBase(_fixture)
{
    [Fact]
    public async Task RetornaObjetoComIdMaiorQueZeroEComMesmoNomeDoObjetoPassado()
    {
        //arrange
        string NOME = "Rodrigo";
        PessoaDal pessoaDal = new(_fixture.ConnectionString);

        //act
        var retorno = await pessoaDal.Create(NOME);

        //assert
        Assert.True(retorno.Id > 0);
        Assert.Equal(NOME, retorno.Nome);
    }

    [Fact]
    public async Task RetornaSqlExceptionAoTentarInserirDoisRegistrosComMesmoNome()
    {
        //arrange
        string NOME = $"Registro criado em {DateTime.Now:fffffff}";
        PessoaDal pessoaDal = new(_fixture.ConnectionString);
        await pessoaDal.Create(NOME);

        //act & assert
        var sqlException = Assert.ThrowsAsync<SqlException>(async () => await pessoaDal.Create(NOME));
    }

    [Fact]
    public async Task RetornaSqlExceptionAoTentarInserirComNomeNull()
    {
        //arrange
        string NOME = null!;
        PessoaDal pessoaDal = new(_fixture.ConnectionString);

        //act & assert
        var sqlException = await Assert.ThrowsAsync<SqlException>(async () => await pessoaDal.Create(NOME));
    }
}
