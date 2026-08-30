using sistema_de_gestao_de_faculdade.Entity;
using static System.Console;

Console.WriteLine("Hello, World!");
FaculdadeService faculdadeService = new FaculdadeService();

//case "9":
//    ConsultarCursos(faculdadeService);
//    break;

static void CadastrarCurso(FaculdadeService faculdadeService)
{
    WriteLine("===== CADASTRAR CURSO =====");

    Write("Código: ");
    string codigo = ReadLine();

    Write("Nome: ");
    string nome = ReadLine();

    WriteLine("Tipo do curso:");
    WriteLine("1 - Graduação");
    WriteLine("2 - Pós-graduação");

    Write("Escolha o tipo: ");
    string opcaoTipo = ReadLine();

    TipoCurso tipoCurso;

    if (opcaoTipo == "1")
        tipoCurso = TipoCurso.GRADUACAO;

    else if (opcaoTipo == "2")
        tipoCurso = TipoCurso.POS_GRADUACAO;
    else
    {
        WriteLine("Tipo de curso inválido.");
        return;
    }
    try
    {
        faculdadeService.CadastrarCurso(
            codigo,
            nome,
            tipoCurso
        );
        WriteLine("Curso cadastrado com sucesso!");
    }
    catch (Exception)
    {

        throw;
        WriteLine("Já existe um curso com esse código.");
    }
}