using Bogus;
using Sistema.Bancario.Dominio.Classes;
using Sistema.Bancario.Dominio.Helpers;

namespace Sistema.Bancario.Dominio.Testes
{
    public class GerenciadoraClientesTestes
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void GerenciadoraClientes_Criacao_DeveInstanceiarCorretamente(int quantidade)
        {
            //Arrange
            var clientesCriados = ClienteDataProvider.InstanciarListaComClientes(quantidade);

            var gerenciadoraCliente = new GerenciadoraClientes(clientesCriados);

            //Act
            var clientes = gerenciadoraCliente.ClientesDoBanco();

            //Assert
            Assert.NotEmpty(clientes);
            Assert.Equal(quantidade, clientes.Count());
        }

        [Fact]
        public void GerenciadoraClientes_Pesquisar_DeveEncontrar()
        {
            //Arrange
            var clientesCriados = ClienteDataProvider.InstanciarListaComClientes(3);

            var clienteRef = clientesCriados.First();

            var gerenciadoraCliente = new GerenciadoraClientes(clientesCriados);

            //Act
            var cliente = gerenciadoraCliente.PesquisaCliente(clienteRef.Id);

            //Assert
            Assert.NotNull(cliente);
            Assert.Equal(clienteRef.Id, cliente.Id);
        }

        [Fact]
        public void GerenciadoraClientes_Adicionar_DeveAdicionar()
        {
            //Arrage
            var clientes = ClienteDataProvider.InstanciarListaVaziaCliente();

            var gerenciadoraCliente = new GerenciadoraClientes(clientes);

            var clienteCriado = ClienteDataProvider.Cliente();

            gerenciadoraCliente.AdicionaCliente(clienteCriado);

            //Act
            var cliente = gerenciadoraCliente.PesquisaCliente(clienteCriado.Id);

            //Assert
            Assert.NotNull(cliente);
            Assert.Equal(clienteCriado.Id, cliente.Id);
        }

        [Fact]
        public void GerenciadoraClientes_Remover_DeveRemover()
        {
            //Arrange
            var clientesCriados = ClienteDataProvider.InstanciarListaComClientes(5);

            var clienteRef = clientesCriados.First();

            var gerenciadoraCliente = new GerenciadoraClientes(clientesCriados);

            //Act
            var removido = gerenciadoraCliente.RemoveCliente(clienteRef.Id);

            //Assert
            Assert.True(removido);
            Assert.Null(gerenciadoraCliente.PesquisaCliente(clienteRef.Id));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GerenciadoraClientes_EstaAtivo_SimNao(bool ativo)
        {
            //Arrange  
            var cliente = ClienteDataProvider.Cliente(ativo);

            var clientes = ClienteDataProvider.InstanciarListaVaziaCliente();

            ClienteDataProvider.AtribuirClienteNaListaCriada(cliente, clientes);

            var gerenciadoraCliente = new GerenciadoraClientes(clientes);

            //Act
            var resultado = gerenciadoraCliente.ClienteAtivo(cliente.Id);

            //Assert
            Assert.Equal(ativo, resultado);
        }

        [Fact]
        public void GerenciadoraClientes_EstaAtivo_DeveOcorrerArgumentNullExceptionQuandoClienteNaoEncontrado()
        {
            //Arrange
            var listaVaziaClientes = ClienteDataProvider.InstanciarListaVaziaCliente();

            var gerenciadoraCliente = new GerenciadoraClientes(listaVaziaClientes);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => gerenciadoraCliente.ClienteAtivo(99));
        }

        [Fact]
        public void GerenciadoraClientes_Limpa_DeveLimpar()
        {
            //Arrange
            var clientes = ClienteDataProvider.InstanciarListaComClientes(150);

            var gerenciadoraCliente = new GerenciadoraClientes(clientes);

            //Act
            gerenciadoraCliente.Limpa();

            //Assert
            Assert.False(gerenciadoraCliente.ClientesDoBanco().Any());
        }

        [Theory]
        [InlineData(18)]
        [InlineData(25)]
        [InlineData(35)]
        [InlineData(45)]
        [InlineData(55)]
        [InlineData(60)]
        [InlineData(65)]
        public void GerenciadoraClientes_ValidaIdade_IdadeValida(int idade)
        {
            //Arrange
            var listaVaziaClientes = ClienteDataProvider.InstanciarListaVaziaCliente();

            var gerenciadoraCliente = new GerenciadoraClientes(listaVaziaClientes);

            //Act
            var resultado = gerenciadoraCliente.ValidaIdade(idade);

            //Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(17)]
        [InlineData(66)]
        [InlineData(70)]
        [InlineData(85)]
        [InlineData(100)]
        public void GerenciadoraClientes_ValidaIdade_IdadeNaoPermitidaException(int idade)
        {
            //Arrange
            var listaVaziaClientes = ClienteDataProvider.InstanciarListaVaziaCliente();

            var gerenciadoraCliente = new GerenciadoraClientes(listaVaziaClientes);

            //Act && Assert
            Assert.Throws<IdadeNaoPermitidaException>(() => gerenciadoraCliente.ValidaIdade(idade));
        }
    }
}
