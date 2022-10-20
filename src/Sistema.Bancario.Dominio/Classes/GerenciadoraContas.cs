namespace Sistema.Bancario.Dominio.Classes
{
    public class GerenciadoraContas
    {
        private IList<ContaCorrente> _contasDoBanco;

        public GerenciadoraContas(IList<ContaCorrente> contasDoBanco)
        {
            _contasDoBanco = contasDoBanco;
        }

        /// <summary>
        /// Retorna uma lista com todas as contas do banco. </summary>
        /// <returns> lista com todas as contas do banco </returns>
        public IList<ContaCorrente> ContasDoBanco()
            => _contasDoBanco;

        /// <summary>
        /// Pesquisa por uma conta a partir do seu ID. </summary>
        /// <param name="idConta"> id da conta a ser pesquisada </param>
        /// <returns> a conta pesquisada ou null, caso não seja encontrada </returns>
        public ContaCorrente? PesquisaConta(int idConta)
            => _contasDoBanco.FirstOrDefault(c => c.Id == idConta);

        /// <summary>
        /// Adiciona uma nova conta à lista de contas do banco. </summary>
        /// <param name="novaConta"> nova conta a ser adicionada </param>
        public void AdicionaConta(ContaCorrente novaConta)
            => _contasDoBanco.Add(novaConta);

        /// <summary>
        /// Remove conta da lista de contas do banco. </summary>
        /// <param name="idConta"> ID da conta a ser removida </param>
        /// <returns> true se a conta foi removida. False, caso contrário. </returns>
        public bool RemoveConta(int idConta)
        {
            var conta = PesquisaConta(idConta);

            if (conta == null)
                return false;

            return _contasDoBanco.Remove(conta);
        }

        /// <summary>
        /// Informa se uma determinada conta está ativa ou não. </summary>
        /// <param name="idConta"> ID da conta cujo status será verificado </param>
        /// <returns> true se a conta está ativa. False, caso contrário.  </returns>
        public bool ContaAtiva(int idConta)
        {
            var conta = PesquisaConta(idConta);

            if (conta == null)
                throw new ArgumentNullException("Conta não encontrada");

            return conta.EstaAtiva();
        }

        /// <summary>
        /// Transfere um determinado valor de uma conta Origem para uma conta Destino.
        /// Caso não haja saldo suficiente, o valor não será transferido.
        /// </summary>
        /// <param name="idContaOrigem"> conta que terá o valor deduzido </param>
        /// <param name="valor"> valor a ser transferido </param>
        /// <param name="idContaDestino"> conta que terá o valor acrescido </param>
        /// <returns> true, se a transferência foi realizada com sucesso. </returns>
        public void TransfereValor(int idContaOrigem, double valor, int idContaDestino)
        {
            ContaCorrente? contaOrigem = PesquisaConta(idContaOrigem);
            ContaCorrente? contaDestino = PesquisaConta(idContaDestino);

            if (contaOrigem == null || contaDestino == null)
                throw new InvalidOperationException("Operação inválida");

            contaDestino.Creditar(valor);
            contaOrigem.Debitar(valor); //se a origem não conter o valor desejado?
        }
    }
}
