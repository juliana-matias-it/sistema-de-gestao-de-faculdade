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
            case "1":
                Console.WriteLine("**Cadastro de Curso**");
                Console.WriteLine("Digite o código do curso:");
                string codigo = Console.ReadLine();

                Console.WriteLine("Digite o nome do curso:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o tipo do curso:");
                TipoCurso tipo = Enum.Parse(TipoCurso, Console.ReadLine());

                Curso curso = new Curso(codigo, nome, tipo);
                faculdadeService.CadastrarCurso(curso);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("Cadastro realizado com sucesso!");
                Console.ResetColor();
                Console.WriteLine();
                break;
            case "2":
                Console.WriteLine("**Cadastro de Professor**");
                Console.WriteLine("Digite o nome do professor:");
                string nomeProfessor = Console.ReadLine();

                Console.WriteLine("Digite o CPF do professor:");
                string cpfProfessor = Console.ReadLine();

                Console.WriteLine("Digite o email do professor:");
                string emailProfessor = Console.ReadLine();

                Console.WriteLine("Digite o número de registro do professor:");
                string registroProfessor = Console.ReadLine();

                Console.WriteLine("Digite a especialidade do professor:");
                string especialidadeProfessor = Console.ReadLine();
                Console.WriteLine();

                Professor professor = new Professor(nomeProfessor, cpfProfessor, emailProfessor, registroProfessor, especialidadeProfessor);
                faculdadeService.CadastrarProfessor(professor);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("Cadastro realizado com sucesso!");
                Console.ResetColor();
                Console.WriteLine();
                break;
            case "3":
                Console.WriteLine("**Cadastro de Aluno**");
                Console.WriteLine("Digite o nome do aluno:");
                string nomeAluno = Console.ReadLine();

                Console.WriteLine("Digite o CPF do aluno:");
                string cpfAluno = Console.ReadLine();

                Console.WriteLine("Digite o email do aluno:");
                string emailAluno = Console.ReadLine();

                Console.WriteLine("Digite o número de matrícula do aluno:");
                string numeroMatricula = Console.ReadLine();
                Console.WriteLine();

                Aluno aluno = new Aluno(nomeAluno, cpfAluno, emailAluno, numeroMatricula);
                faculdadeService.CadastrarAluno(aluno);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("Cadastro realizado com sucesso!");
                Console.ResetColor();
                Console.WriteLine();
                break;
            case "4":
                Console.WriteLine("**Cadastro de Disciplina**");
                Console.WriteLine("Digite o código da disciplina:");
                string codigoDisciplina = Console.ReadLine();

                Console.WriteLine("Digite o nome da disciplina:");
                string nomeDisciplina = Console.ReadLine();

                Console.WriteLine("Digite a carga horária da disciplina:");
                string cargaHoraria = Console.ReadLine();

                Console.WriteLine("Digite o registro do professor responsável pela disciplina:");
                string professorResponsavel = Console.ReadLine();
                Console.WriteLine();

                Disciplina disciplina = new Disciplina(codigoDisciplina, nomeDisciplina, cargaHoraria, professorResponsavel);

                faculdadeService.CadastrarDisciplina(disciplina);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("Cadastro  de disciplina realizado com sucesso!");
                Console.ResetColor();
                Console.WriteLine();
            case "5":
                Console.WriteLine("**Vincular Disciplina a Curso**");
                Console.WriteLine("Digite o código do curso:");
                string codCurso = Console.ReadLine();

                Console.WriteLine("Digite o código da disciplina:");
                string codDisciplina = Console.ReadLine();

                faculdadeService.VincularDisciplinaCurso(codCurso, codDisciplina);
                break;
            case "6":
                Console.WriteLine("**Vincular Aluno a Curso**");
                Console.WriteLine("Digite o número de matrícula do aluno:");
                string numMatricula = Console.ReadLine();

                Console.WriteLine("Digite o código do curso:");
                string codigoCurso = Console.ReadLine();
                faculdadeService.MatricularAlunoCurso(numMatricula, codigoCurso);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write($"Aluno matriculado realizado com sucesso no curso {codigoCurso}!");
                Console.ResetColor();
                Console.WriteLine();
                break;
            case "7":
                Console.WriteLine("**Lançar Nota**");
                Console.WriteLine("Digite o número de matrícula do aluno:");
                string notaNumMatricula = Console.ReadLine();

                Console.WriteLine("Digite o código do curso:");
                string notaCodigoCurso = Console.ReadLine();

                Console.WriteLine("Digite o código da disciplina:");
                string notaCodigoDisciplina = Console.ReadLine();

                Console.WriteLine("Digite a nota do aluno:");
                decimal nota = decimal.Parse(Console.ReadLine());

                faculdadeService.LancarNota(notaNumMatricula, notaCodigoCurso, notaCodigoDisciplina, nota);
                break;

            case "8":
                faculdadeService.ConsultarPessoas();
                break;
            case "9":
                faculdadeService.ConsultarCursos();
                break;
            case "10":
                faculdadeService.ConsultarMatriculas();
                break;
            case "11":
                Console.WriteLine("**Consultar Boletim**");
                Console.WriteLine("Digite o número de matrícula do aluno:");
                string boletimNumMatricula = Console.ReadLine();

                Console.WriteLine("Digite o código do curso:");
                string boletimCodigoCurso = Console.ReadLine();

                faculdadeService.ConsultarBoletim(boletimNumMatricula, boletimCodigoCurso);
                break;
            case "12":
                Console.WriteLine("**Enviar Notificação**");
                Console.WriteLine("Digite o CPF da pessoa:");
                string notificacaoCPF = Console.ReadLine();

                Console.WriteLine("Digite a mensagem:");
                string mensagem = Console.ReadLine();

                faculdadeService.EnviarNotificacao(notificacaoCPF, mensagem);
                break;
            case "0":
                Console.WriteLine("Encerrando...");
                break;
            default:
                throw new ArgumentException("Opção inválida. Por favor, digite um número de 0 a 12.");
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
