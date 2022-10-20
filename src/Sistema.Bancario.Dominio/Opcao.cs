
using Sistema.Bancario.Dominio.Enumerators;
using Sistema.Bancario.Dominio.Helpers;

namespace Sistema.Bancario.Dominio
{
    public class Opcao
    {
        public OpcaoMenu Escrever(List<OpcaoMenu> opcoes)
        {
            int index = 0;

            bool deveAguardarEscolha = true;

            while (deveAguardarEscolha)
            {
                Console.Clear();

                for (int i = 0; i < opcoes.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(EnumHelper.Description(opcoes[i]));
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();

                switch (ckey.Key)
                {
                    case ConsoleKey.Enter:
                        deveAguardarEscolha = false;
                        break;

                    case ConsoleKey.UpArrow:
                        if (index <= 0) index = opcoes.Count - 1;
                        else index--;

                        break;

                    case ConsoleKey.DownArrow:
                    default:
                        if (index == opcoes.Count - 1)
                            index = 0;
                        else
                            index++;

                        break;
                }
            }

            Console.Clear();

            return opcoes[index];
        }
    }
}