namespace DBDockerIntegrationTests;

public class PessoalDalSelectByIdTests : DBTestBase
{
    public PessoalDalSelectByIdTests(DbFixture fixture) : base(fixture) { }

    [Fact]
    public async Task RetornaObjetoComValorNoCampoNomeDoObjetoInserido()
    {
        //arrange
        string NOME = "JOÃO DA SILVA";
        PessoaDal pessoaDal = new(_fixture.ConnectionString);
        var pessoaInserida = await pessoaDal.Create(NOME);

        //act
        var pessoaConsultada = await pessoaDal.SelectById(pessoaInserida.Id);

        //assert
        Assert.Equal(pessoaInserida.Nome, pessoaConsultada?.Nome);
        Assert.NotEqual("Outro Nome", pessoaConsultada?.Nome);
    }

}
