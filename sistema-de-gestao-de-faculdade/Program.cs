using sistema_de_gestao_de_faculdade.Entity;
using sistema_de_gestao_de_faculdade.Services;
FaculdadeService faculdadeService = new FaculdadeService();

string opcao = "0";

do
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("========= GESTÃO DA FACULDADE =========");
        Console.WriteLine();
        Console.WriteLine("1 - Cadastrar curso");
        Console.WriteLine("2 - Cadastrar professor");
        Console.WriteLine("3 - Cadastrar aluno");
        Console.WriteLine("4 - Cadastrar disciplina");
        Console.WriteLine("5 - Vincular disciplina a um curso");
        Console.WriteLine("6 - Matricular aluno em curso");
        Console.WriteLine("7 - Lançar nota");
        Console.WriteLine("8 - Consultar pessoas");
        Console.WriteLine("9 - Consultar cursos");
        Console.WriteLine("10 - Consultar matrículas");
        Console.WriteLine("11 - Consultar boletim");
        Console.WriteLine("12 - Enviar notificação");
        Console.WriteLine("0 - Sair");
        Console.WriteLine();
        Console.WriteLine("========================================");

        Console.Write("Escolha uma opção:");
        opcao = Console.ReadLine();
        Console.WriteLine();

        switch (opcao)
        {
            //case "1":
            //    faculdadeService.CadastrarCurso();
            //    break;
            //case "2":
            //    faculdadeService.CadastrarProfessor();
            //    break;
            case "3":
                faculdadeService.CadastrarAluno();
                break;
            //case "4":
            //    faculdadeService.CadastrarDisciplina();
            //    break;
            //case "5":
            //    faculdadeService.VincularDisciplinaCurso();
            //    break;
            //case "6":
            //    faculdadeService.MatricularAlunoCurso();
            //    break;
            //case "7":
            //    faculdadeService.LancarNota();
            //    break;
            //case "8":
            //    faculdadeService.ConsultarPessoas();
            //    break;
            //case "9":
            //    faculdadeService.ConsultarCursos();
            //    break;
            //case "10":
            //    faculdadeService.ConsultarMatriculas();
            //    break;
            //case "11":
            //    faculdadeService.ConsultarBoletim();
            //    break;
            //case "12":
            //    faculdadeService.EnviarNotificacao();
            //break;
            case "0":
                Console.WriteLine("Encerrando...");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("Opção inválida. Por favor, digite um número de 0 a 12.");
                Console.ResetColor();
                Console.WriteLine();
                break;
        }
    }

    catch (Exception ex)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(ex.Message);
        Console.ResetColor();
        Console.WriteLine();
    }
} while (opcao != "0");