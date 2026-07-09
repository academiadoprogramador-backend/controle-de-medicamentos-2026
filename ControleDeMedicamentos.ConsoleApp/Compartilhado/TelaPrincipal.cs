using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    public TelaPrincipal(ContextoJson contexto)
    {
    }

    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle de Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gestão de Pacientes");
        Console.WriteLine("2 - Gestão de Funcionários");
        Console.WriteLine("3 - Gestão de Fornecedores");
        Console.WriteLine("4 - Gestão de Medicamentos");
        Console.WriteLine("5 - Gestão de Estoque");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return null;

        if (opcaoMenuPrincipal == "2")
            return null;

        if (opcaoMenuPrincipal == "3")
            return null;

        if (opcaoMenuPrincipal == "4")
            return null;

        if (opcaoMenuPrincipal == "5")
            return null;

        return null;
    }
}
