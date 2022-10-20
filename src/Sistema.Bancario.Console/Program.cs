using Sistema.Bancario.Dominio;
using Sistema.Bancario.Dominio.Enumerators;

var opcoes = Enum.GetValues(typeof(OpcaoMenu)).Cast<OpcaoMenu>().ToList();
var menu = new Menu(opcoes);
menu.Exibir();
