using Sistema.Bancario.Dominio.Classes;

namespace Sistema.Bancario.Dominio.Helpers
{
    public class ContaDataProvider : BaseDataProvider
    {
        public static ContaCorrente Conta(int id, double saldo, bool ativa)
            => new ContaCorrente(id, saldo, ativa);

        public static List<ContaCorrente> InstanciarListaVaizaContaCorrente()
            => new List<ContaCorrente>();

        public static List<ContaCorrente> InstanciarListaComContaCorrente(int quantidade)
        {
            var contas = new List<ContaCorrente>();

            for (int i = 0; i < quantidade; i++)
            {
                contas.Add(Conta());
            }

            return contas;
        }

        public static ContaCorrente Conta(bool ativa = true)
        {
            var saldo = decimal.ToDouble(Faker.Finance.Amount());

            return Conta(Randomizer.Number(1, 999), saldo, ativa);
        }

        public static ContaCorrente Conta(double saldo, bool ativa = true)
        {
            return Conta(Randomizer.Number(1, 999), saldo, ativa);
        }

        public static List<ContaCorrente> AtribuirContaNaListaCriada(ContaCorrente conta, List<ContaCorrente> listaClienteConta)
        {
            listaClienteConta.Add(conta);
            return listaClienteConta;
        }

        public static double CalcularTransferencia(double saldo, double valorTransferencia, bool ehDebito)
        {
            if (ehDebito)
                return Math.Truncate((saldo - valorTransferencia) * 100) / 100;
            return Math.Truncate((saldo + valorTransferencia) * 100) / 100;
        }
    }
}
