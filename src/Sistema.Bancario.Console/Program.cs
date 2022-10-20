using Sistema.Bancario.Dominio;
using Sistema.Bancario.Dominio.Enumerators;

var op = Enum.GetValues(typeof(OpcaoMenu)).Cast<OpcaoMenu>().ToList();

var menu = new ExibicaoMenu(op);
menu.Exibir();
