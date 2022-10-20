namespace Sistema.Bancario.Dominio.Classes
{
    public class ContaCorrente
    {
        public int Id { get; private set; }
        public double Saldo { get; private set; }
        public bool Ativa { get; private set; }

        public ContaCorrente(int id, double saldo, bool ativa)
        {
            Id = id;
            Saldo = saldo;
            Ativa = ativa;
        }

        public bool EstaAtiva()
            => Ativa;

        public void Debitar(double valor)
        {
            Saldo = Math.Truncate((Saldo - valor) * 100) / 100;
        }

        public void Creditar(double valor)
        {
            Saldo = Math.Truncate((Saldo + valor) * 100) / 100;
        }

        /// <summary>
        /// Método que retorna a representação textual de uma conta corrente. </summary>
        /// <returns> representação textual da conta corrente </returns>
        public override string ToString()
        {
            return "=========================\n" + "Id: " + Id + "\n" + "Saldo: " + Saldo + "\n" + "Status: " + (Ativa ? "Ativa" : "Inativa") + "\n" + "=========================";
        }

    }
}
