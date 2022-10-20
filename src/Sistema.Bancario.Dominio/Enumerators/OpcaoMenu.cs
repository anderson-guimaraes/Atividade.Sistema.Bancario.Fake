using System.ComponentModel;

namespace Sistema.Bancario.Dominio.Enumerators
{
    public enum OpcaoMenu
    {
        [Description("- Consultar por um cliente")]
        ConsularCliente,

        [Description("- Consultar por uma conta corrente")]
        ConsultarContaCorrente,

        [Description("- Ativar um cliente")]
        AtivarCliente,

        [Description("- Desativar um cliente")]
        DesativarCliente,

        [Description("- Sair")]
        Sair
    }
}
