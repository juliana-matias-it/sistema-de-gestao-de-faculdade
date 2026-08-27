using System.Globalization;

string opcao;

do
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
    

    switch(opcao)
    {
        case "1":
            CadastrarCurso();
            break;
        case "2":
            CadastrarProfessor();
            break;
        case "3":
            CadastrarAluno();
            break;
        case "4":
            CadastrarDisciplina();
            break;
        case "5":
            VincularDisciplinaCurso();
            break;
        case "6":
            MatricularAlunoCurso();
            break;
        case "7":
            LancarNota();
            break;
        case "8":
            ConsultarPessoas();
            break;
        case "9":
            ConsultarCursos();
            break;
        case "10":
            ConsultarMatriculas();
            break;
        case "11":
            ConsultarBoletim();
            break;
        case "12":
            EnviarNotificacao();
            break;
        case "0":
            Console.WriteLine("Encerrando...");
            break;
        default:
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida. Por favor, digite um número de 0 a 12.");
            Console.ResetColor();
            Console.WriteLine();
            break;
    }
} while(opcao != "0");

static void CadastrarCurso()
{
    Console.WriteLine("Cadastrar curso");
    // Implementação do cadastro de curso
}

static void CadastrarProfessor()
{
    Console.WriteLine("Cadastrar professor");
    // Implementação do cadastro de professor
}

static void CadastrarAluno()
{
    Console.WriteLine("Cadastrar aluno");
    // Implementação do cadastro de aluno
}

static void CadastrarDisciplina()
{
    Console.WriteLine("Cadastrar disciplina");
    // Implementação do cadastro de disciplina
}

static void VincularDisciplinaCurso()
{
    Console.WriteLine("Vincular disciplina a um curso");
    // Implementação do vínculo de disciplina a curso
}

static void MatricularAlunoCurso()
{
    Console.WriteLine("Matricular aluno em curso");
    // Implementação da matrícula de aluno em curso
}

static void LancarNota()
{
    Console.WriteLine("Lançar nota");
    // Implementação do lançamento de nota
}

static void ConsultarPessoas()
{
    Console.WriteLine("Consultar pessoas");
    // Implementação da consulta de pessoas
}

static void ConsultarCursos()
{
    Console.WriteLine("Consultar cursos");
    // Implementação da consulta de cursos
}

static void ConsultarMatriculas()
{
    Console.WriteLine("Consultar matrículas");
    // Implementação da consulta de matrículas
}

static void ConsultarBoletim()
{
    Console.WriteLine("Consultar boletim");
    // Implementação da consulta de boletim
}

static void EnviarNotificacao()
{
    Console.WriteLine("Enviar notificação");
    // Implementação do envio de notificação
}