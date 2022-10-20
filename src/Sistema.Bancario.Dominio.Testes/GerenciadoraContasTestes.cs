using Sistema.Bancario.Dominio.Classes;
using Sistema.Bancario.Dominio.Helpers;

namespace Sistema.Bancario.Dominio.Testes
{
    public class GerenciadoraContasTestes
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void GerenciadoraContas_Criacao_DeveInstanciarCorretamente(int quantidade)
        {
            //Arrange
            var contasCriadas = ContaDataProvider.InstanciarListaComContaCorrente(quantidade);

            var gerenciadoraContas = new GerenciadoraContas(contasCriadas);

            //Act
            var contas = gerenciadoraContas.ContasDoBanco();

            //Assert
            Assert.NotEmpty(contas);
            Assert.Equal(quantidade, contas.Count());
        }

        [Fact]
        public void GerenciadoraContas_Pesquisar_DeveEncontrar()
        {
            //Arrange
            var contasCriadas = ContaDataProvider.InstanciarListaComContaCorrente(3);

            var contaRef = contasCriadas.First();

            var gerenciadoraContas = new GerenciadoraContas(contasCriadas);

            //Act
            var conta = gerenciadoraContas.PesquisaConta(contaRef.Id);

            //Assert
            Assert.NotNull(conta);
            Assert.Equal(contaRef.Id, conta.Id);
        }

        [Fact]
        public void GerenciadoraContas_Adicionar_DeveAdicionar()
        {
            //Arrage
            var contasCriadas = ContaDataProvider.InstanciarListaVaizaContaCorrente();

            var gerenciadoraContas = new GerenciadoraContas(contasCriadas);

            var contaCriada = ContaDataProvider.Conta();

            gerenciadoraContas.AdicionaConta(contaCriada);

            //Act
            var conta = gerenciadoraContas.PesquisaConta(contaCriada.Id);

            //Assert
            Assert.NotNull(conta);
            Assert.Equal(contaCriada.Id, conta.Id);
        }

        [Fact]
        public void GerenciadoraContas_Remover_DeveRemover()
        {
            //Arrange
            var contasCriadas = ContaDataProvider.InstanciarListaComContaCorrente(5);

            var contaRef = contasCriadas.First();

            var gerenciadoraContas = new GerenciadoraContas(contasCriadas);

            //Act
            var removido = gerenciadoraContas.RemoveConta(contaRef.Id);

            //Assert
            Assert.True(removido);
            Assert.Null(gerenciadoraContas.PesquisaConta(contaRef.Id));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GerenciadoraContas_EstaAtivo_SimNao(bool ativo)
        {
            //Arrange  
            var conta = ContaDataProvider.Conta(ativo);

            var contas = ContaDataProvider.InstanciarListaVaizaContaCorrente();

            ContaDataProvider.AtribuirContaNaListaCriada(conta, contas);

            var gerenciadoraContas = new GerenciadoraContas(contas);

            //Act
            var resultado = gerenciadoraContas.ContaAtiva(conta.Id);

            //Assert
            Assert.Equal(ativo, resultado);
        }

        [Fact]
        public void GerenciadoraContas_EstaAtivo_DeveOcorrerArgumentNullExceptionQuandoContaNaoEncontrado()
        {
            //Arrange
            var listaVaziaContas = ContaDataProvider.InstanciarListaVaizaContaCorrente();

            var gerenciadoraContas = new GerenciadoraContas(listaVaziaContas);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => gerenciadoraContas.ContaAtiva(99));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(150)]
        [InlineData(300)]
        [InlineData(500)]
        public void GerenciadoraContas_TransfereValor_DeveTranferir(double valorTransferencia)
        {
            //Arrange
            var contaOrigem = ContaDataProvider.Conta();
            var contaDestino = ContaDataProvider.Conta();

            var expectativaSaldoOrigem = ContaDataProvider.CalcularTransferencia(contaOrigem.Saldo, valorTransferencia, ehDebito: true);
            var expectativaSaldoDestino = ContaDataProvider.CalcularTransferencia(contaDestino.Saldo, valorTransferencia, ehDebito: false);

            var contasCriadas = ContaDataProvider.InstanciarListaVaizaContaCorrente();

            ContaDataProvider.AtribuirContaNaListaCriada(contaOrigem, contasCriadas);
            ContaDataProvider.AtribuirContaNaListaCriada(contaDestino, contasCriadas);

            var gerenciadoraContas = new GerenciadoraContas(contasCriadas);

            //Act
            gerenciadoraContas.TransfereValor(contaOrigem.Id, valorTransferencia, contaDestino.Id);

            //Assert
            Assert.Equal(expectativaSaldoOrigem, contaOrigem.Saldo);
            Assert.Equal(expectativaSaldoDestino, contaDestino.Saldo);
        }

        [Fact]
        public void GerenciadoraContas_TransfereValor_DeveOcorrerInvalidOperationExceptionQuandoNaoEncontrarContaOrigemDestino()
        {
            //Arrange
            var contasCriadas = ContaDataProvider.InstanciarListaVaizaContaCorrente();

            var gerenciadoraContas = new GerenciadoraContas(contasCriadas);

            //Act && Assert
            Assert.Throws<InvalidOperationException>(() => gerenciadoraContas.TransfereValor(1, 1, 1));
        }
    }
}
