using Sistema.Bancario.Dominio.Classes;

namespace Sistema.Bancario.Dominio.Helpers
{
    public class ClienteDataProvider : BaseDataProvider
    {
        public static List<Cliente> InstanciarListaComClientes(int quantidade)
        {
            var clientes = new List<Cliente>();

            for (int i = 0; i < quantidade; i++)
            {
                var cliente = Cliente(
                      Randomizer.Number(1, 999),
                      Faker.Person.FullName,
                      Randomizer.Number(18, 70),
                      Faker.Person.Email,
                      Randomizer.Number(1, 999),
                      true);

                clientes.Add(cliente);
            }

            return clientes;
        }

        public static Cliente Cliente(bool ativo = true)
        {
            return Cliente(
                 Randomizer.Number(1, 999),
                 Faker.Person.FullName,
                 Randomizer.Number(18, 70),
                 Faker.Person.Email,
                 Randomizer.Number(1, 999),
                 ativo);
        }

        public static Cliente Cliente(int idade, bool ativo = true)
        {
            return Cliente(
                 Randomizer.Number(1, 999),
                 Faker.Person.FullName,
                 idade,
                 Faker.Person.Email,
                 Randomizer.Number(1, 999),
                 ativo);
        }

        public static Cliente Cliente(int id, string nome, int idade, string email, int idContaCorrente, bool ativo)
            => new Cliente(id, nome, idade, email, idContaCorrente, ativo);

        public static List<Cliente> InstanciarListaVaziaCliente()
            => new List<Cliente>();

        public static List<Cliente> AtribuirClienteNaListaCriada(Cliente cliente, List<Cliente> listaClienteCriada)
        {
            listaClienteCriada.Add(cliente);
            return listaClienteCriada;
        }
    }
}
