using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFornecedores;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloPacientes;
using ControleDeMedicamentos.WebApp.ModuloRequisicoes;

namespace ControleDeMedicamentos.WebApp.Compartilhado;

public class TelaPrincipal
{
    private readonly TelaFornecedor telaFornecedor;
    private readonly TelaPaciente telaPaciente;
    private readonly TelaFuncionario telaFuncionario;
    private readonly TelaMedicamento telaMedicamento;
    private readonly TelaRequisicaoEntrada telaRequisicaoEntrada;
    private readonly TelaRequisicaoSaida telaRequisicaoSaida;

    public TelaPrincipal(ContextoJson contexto)
    {
        RepositorioFornecedorEmArquivo repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        RepositorioPacienteEmArquivo repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
        RepositorioFuncionarioEmArquivo repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
        RepositorioMedicamentoEmArquivo repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        RepositorioRequisicaoEntradaEmArquivo repositorioRequisicao = new RepositorioRequisicaoEntradaEmArquivo(contexto);
        RepositorioRequisicaoSaidaEmArquivo repositorioRequisicaoSaida = new RepositorioRequisicaoSaidaEmArquivo(contexto);

        telaFornecedor = new TelaFornecedor(repositorioFornecedor);
        telaPaciente = new TelaPaciente(repositorioPaciente);
        telaFuncionario = new TelaFuncionario(repositorioFuncionario);
        telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);
        telaRequisicaoEntrada = new TelaRequisicaoEntrada(repositorioRequisicao, repositorioMedicamento, repositorioFuncionario);
        telaRequisicaoSaida = new TelaRequisicaoSaida(repositorioRequisicaoSaida, repositorioPaciente, repositorioMedicamento);
    }

    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle de Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gestão de Fornecedores");
        Console.WriteLine("2 - Gestão de Pacientes");
        Console.WriteLine("3 - Gestão de Medicamentos");
        Console.WriteLine("4 - Gestão de Funcionários");
        Console.WriteLine("5 - Gestão de Requisições de Entrada");
        Console.WriteLine("6 - Gestão de Requisições de Saída");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return telaFornecedor;

        if (opcaoMenuPrincipal == "2")
            return telaPaciente;

        if (opcaoMenuPrincipal == "3")
            return telaMedicamento;

        if (opcaoMenuPrincipal == "4")
            return telaFuncionario;

        if (opcaoMenuPrincipal == "5")
            return telaRequisicaoEntrada;

        if (opcaoMenuPrincipal == "6")
            return telaRequisicaoSaida;

        return null;
    }
}
