using Sistema.Bancario.Dominio.Classes;
using Sistema.Bancario.Dominio.Enumerators;

namespace Sistema.Bancario.Dominio
{
    public class ExibicaoMenu
    {
        private static GerenciadoraClientes _gerenciadoraClientes;
        private static GerenciadoraContas _gerenciadoraContas;
        private static List<OpcaoMenu> opcoesMenuBase;

        public ExibicaoMenu(List<OpcaoMenu> opcoesMenu)
        {
            opcoesMenuBase = opcoesMenu;
            InicializaSistemaBancario();
        }

        public void Exibir()
        {
            var menu = new Menu();

            menu.ReescreverOpcoes(opcoesMenuBase);

            var aguardar = true;

            while (aguardar)
            {
                var opcaoEscolhida = menu.Escrever(menu.Opcoes);

                switch (opcaoEscolhida)
                {
                    case OpcaoMenu.ConsularCliente:
                        ConsultarCliente();
                        break;
                    case OpcaoMenu.ConsultarContaCorrente:
                        ConsultarConta();
                        break;
                    case OpcaoMenu.AtivarCliente:
                        AtivarOuDesativarCiente(true);
                        break;
                    case OpcaoMenu.DesativarCliente:
                        AtivarOuDesativarCiente(false);
                        break;
                    case OpcaoMenu.Sair:
                        aguardar = false;
                        break;
                }
            }

            Environment.Exit(0);
        }


        private void ConsultarCliente()
        {
            Console.Write("Digite o ID do cliente: ");

            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.Clear();
                ConsultarCliente();
            }

            var cliente = _gerenciadoraClientes.PesquisaCliente(num);

            if (cliente != null)
            {
                Console.WriteLine(cliente.ToString());
            }
            else
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Cliente não encontrado!");
            }

            Voltar();
        }

        public void ConsultarConta()
        {
            Console.Write("Digite o ID da conta: ");

            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.Clear();
                ConsultarConta();
            }

            var conta = _gerenciadoraContas.PesquisaConta(num);

            if (conta != null)
            {
                Console.Write(conta.ToString());
            }
            else
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Conta não encontrado!");
            }

            Voltar();
        }

        public void AtivarOuDesativarCiente(bool ativar)
        {
            Console.Write("Digite o ID do cliente: ");

            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.Clear();
                ConsultarConta();
            }

            var cliente = _gerenciadoraClientes.PesquisaCliente(num);

            if (cliente != null)
            {
                cliente.MudarStatus(ativar);

                var status = ativar ? "ativado" : "desativado";

                Console.WriteLine($"Cliente {status} com sucesso!");
            }
            else
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Cliente não encontrado!");
            }

            Voltar();
        }

        private void Voltar()
        {
            Console.WriteLine(string.Empty);

            Console.WriteLine("Backspace para voltar ao Menu.");

            var aguardar = true;

            while (aguardar)
            {
                var ckey = Console.ReadKey();

                if (ckey.Key == ConsoleKey.Backspace)
                {
                    aguardar = false;
                }
            }

            Exibir();
        }


        private void InicializaSistemaBancario()
        {
            var clientes = new List<Cliente>();
            var contaCorrentes = new List<ContaCorrente>();

            // criando e inserindo duas contas na lista de contas correntes do banco
            var conta01 = new ContaCorrente(1, 0, true);
            var conta02 = new ContaCorrente(2, 0, true);
            contaCorrentes.Add(conta01);
            contaCorrentes.Add(conta02);

            // criando dois clientes e associando as contas criadas acima a eles
            var cliente01 = new Cliente(1, "Gustavo Farias", 31, "gugafarias@gmail.com", conta01.Id, true);
            var cliente02 = new Cliente(2, "Felipe Augusto", 34, "felipeaugusto@gmail.com", conta02.Id, true);
            // inserindo os clientes criados na lista de clientes do banco
            clientes.Add(cliente01);
            clientes.Add(cliente02);

            _gerenciadoraClientes = new GerenciadoraClientes(clientes);
            _gerenciadoraContas = new GerenciadoraContas(contaCorrentes);
        }
    }
}
