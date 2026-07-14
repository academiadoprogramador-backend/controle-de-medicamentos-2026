using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class TelaRequisicaoSaida : TelaBase<RequisicaoSaida>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioPacienteEmArquivo repositorioPaciente;
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;

    public TelaRequisicaoSaida(
        RepositorioRequisicaoSaidaEmArquivo repositorioRequisicao,
        RepositorioPacienteEmArquivo repositorioPaciente,
        RepositorioMedicamentoEmArquivo repositorioMedicamento
    ) : base("Requisição de Saída", repositorioRequisicao)
    {
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Saída");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -10} | {4, -15}",
            "Id", "Paciente", "Medicamento", "Qtd", "Data"
        );

        List<RequisicaoSaida> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoSaida r in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -10} | {4, -15}",
                r.Id, r.Paciente.Nome, r.Medicamento.Nome, r.Quantidade, r.Data.ToShortDateString()
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoSaida ObterDadosCadastrais()
    {
        VisualizarPacientes();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do paciente: ");
        int idPaciente = Convert.ToInt32(Console.ReadLine());

        Paciente paciente = repositorioPaciente.SelecionarPorId(idPaciente)!;

        VisualizarMedicamentos();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do medicamento que deseja requisitar: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine());

        Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento)!;

        Console.Write("Digite a quantidade que deseja requisitar: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        return new RequisicaoSaida(paciente, medicamento, quantidade);
    }

    private void VisualizarPacientes()
    {
        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -14}",
            "Id", "Nome", "Telefone", "Cartão SUS", "CPF"
        );

        List<Paciente> registros = repositorioPaciente.SelecionarTodos();

        foreach (Paciente p in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -17} | {4, -14}",
                p.Id, p.Nome, p.Telefone, p.CartaoSUS, p.Cpf
            );
        }
    }

    private void VisualizarMedicamentos()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -10}",
            "Id", "Nome", "Fornecedor", "Descrição", "Estoque"
        );

        List<Medicamento> registros = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -10}",
                m.Id, m.Nome, m.Fornecedor.Nome, m.Descricao, m.QuantidadeEmEstoque
            );
        }
    }

    protected override bool ExistemDependenciasAtivasDoRegistro(int idRegistro)
    {
        return false;
    }
}
