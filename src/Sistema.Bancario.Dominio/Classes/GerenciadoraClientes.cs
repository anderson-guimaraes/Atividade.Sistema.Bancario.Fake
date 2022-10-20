namespace Sistema.Bancario.Dominio.Classes
{
    using System.Collections.Generic;

    public class GerenciadoraClientes
    {
        private IList<Cliente> _clientesDoBanco;

        public GerenciadoraClientes(IList<Cliente> clientesDoBanco)
        {
            _clientesDoBanco = clientesDoBanco;
        }

        /// <summary>
        /// Retorna uma lista com todos os clientes do banco. </summary>
        /// <returns> lista com todos os clientes do banco </returns>
        public IList<Cliente> ClientesDoBanco()
            => _clientesDoBanco;

        /// <summary>
        /// Pesquisa por um cliente a partir do seu ID. </summary>
        /// <param name="idCliente"> id do cliente a ser pesquisado </param>
        /// <returns> o cliente pesquisado ou null, caso não seja encontrado </returns>
        public Cliente? PesquisaCliente(int idCliente)
            => _clientesDoBanco.FirstOrDefault(c => c.Id == idCliente);

        /// <summary>
        /// Adiciona um novo cliente à lista de clientes do banco. </summary>
        /// <param name="novoCliente"> novo cliente a ser adicionado </param>
        public void AdicionaCliente(Cliente novoCliente)
            => _clientesDoBanco.Add(novoCliente);

        /// <summary>
        /// Remove cliente da lista de clientes do banco. </summary>
        /// <param name="idCliente"> ID do cliente a ser removido </param>
        /// <returns> true se o cliente foi removido. False, caso contrário. </returns>
        public bool RemoveCliente(int idCliente)
        {
            var cliente = PesquisaCliente(idCliente);

            if (cliente == null)
                return false;

            return _clientesDoBanco.Remove(cliente);
        }

        /// <summary>
        /// Informa se um determinado cliente está ativo ou não. </summary>
        /// <param name="idCliente"> ID do cliente cujo status será verificado </param>
        /// <returns> true se o cliente está ativo. False, caso contrário.  </returns>
        public bool ClienteAtivo(int idCliente)
        {
            var cliente = PesquisaCliente(idCliente);

            if (cliente == null)
                throw new ArgumentNullException("Cliente não encontrado");

            return cliente.EstaAtivo();
        }

        /// <summary>
        /// Limpa a lista de clientes, ou seja, remove todos eles. 
        /// </summary>
        public void Limpa()
            => _clientesDoBanco.Clear();

        /// <summary>
        /// Valida se a idade do cliente está dentro do intervalo permitido (18 - 65). </summary>
        /// <param name="idade"> a idade do possível novo cliente </param>
        public bool ValidaIdade(int idade)
        {
            if (idade < 18 || idade > 65)
                throw new IdadeNaoPermitidaException(IdadeNaoPermitidaException.MSG_IDADE_INVALIDA);

            return true;
        }
    }
}
