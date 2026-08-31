using System;
using System.Collections.Generic;
using System.Linq;
using sistema_de_gestao_de_faculdade.Entity;

public class FaculdadeService
{
    private readonly List<Aluno> _alunos;
    private readonly List<Professor> _professores;
    private readonly List<Disciplina> _disciplinas;
    private readonly List<Curso> _cursos;

    public FaculdadeService()
    {
        _alunos = new List<Aluno>();
        _professores = new List<Professor>();
        _disciplinas = new List<Disciplina>();
        _cursos = new List<Curso>();
    }

    public void CadastrarAluno(Aluno aluno)
    {
        if (_alunos.Any(x => x.NumeroMatricula == aluno.NumeroMatricula))
        {
            throw new ArgumentException($"Número de matrícula {aluno.NumeroMatricula} já cadastrado. Informe um número de matrícula válido.");
        }

        if (_alunos.Any(x => x.CPF == aluno.CPF))
        {
            throw new ArgumentException($"CPF {aluno.CPF} já cadastrado. Informe um CPF válido.");
        }

        _alunos.Add(aluno);
    }

    public void MatricularAlunoCurso(string numeroMatricula, string codigoCurso)
    {
        Aluno? aluno = _alunos.FirstOrDefault(x => x.NumeroMatricula == numeroMatricula);

        if (aluno is null)
        {
            throw new ArgumentException($"Aluno com a matrícula {numeroMatricula} não encontrado. Cadastre o aluno antes de matriculá-lo em um curso.");
        }

        Curso? curso = _cursos.FirstOrDefault(x => x.Codigo == codigoCurso);

        if (curso is null)
        {
            throw new ArgumentException($"Curso com o código {codigoCurso} não encontrado. Cadastre o curso antes de matriculá-lo.");
        }

        if (aluno.Matriculas.Any(x => x.Curso.Codigo == codigoCurso))
        {
            throw new ArgumentException($"Aluno {aluno.Nome} já está matriculado no curso {codigoCurso}. Não é possível realizar a matrícula novamente.");
        }

        Matricula matricula = new Matricula(aluno, curso);

        aluno.AdicionarMatricula(matricula);
    }

    public void ConsultarMatriculas()
    {
        if (_alunos.Count == 0)
        {
            throw new ArgumentException("Não há alunos cadastrados.");
        }

        foreach (Aluno aluno in _alunos)
        {
            Console.WriteLine($"Aluno: {aluno.Nome}");
            Console.WriteLine($"Matrícula: {aluno.NumeroMatricula}");

            if (!aluno.Matriculas.Any())
            {
                Console.WriteLine("Cursos: Nenhum curso matriculado.");
                Console.WriteLine();
                continue;
            }

            foreach (Matricula matricula in aluno.Matriculas)
            {
                Console.WriteLine($"Curso: {matricula.Curso.Nome}");
                Console.WriteLine($"Código: {matricula.Curso.Codigo}");
                Console.WriteLine($"Tipo: {matricula.Curso.TipoCurso}");
                Console.WriteLine();
            }
        }
    }

    public void CadastrarCurso(string codigo, string nome, TipoCurso tipoCurso)
    {
        if (_cursos.Any(curso => curso.Codigo == codigo))
        {
            throw new InvalidOperationException("Curso já cadastrado.");
        }

        Curso curso = new Curso(codigo, nome, tipoCurso);

        _cursos.Add(curso);
    }

    public void ConsultarCursos()
    {
        if (_cursos.Count == 0)
        {
            Console.WriteLine("Nenhum curso cadastrado.");
            return;
        }

        foreach (Curso curso in _cursos)
        {            
            Console.WriteLine("==============================");
            Console.WriteLine($"Código: {curso.Codigo}");
            Console.WriteLine($"Nome: {curso.Nome}");
            Console.WriteLine($"Tipo: {curso.TipoCurso}");
            Console.WriteLine("==============================");
            
            if (!curso.Disciplinas.Any())
            {
                Console.WriteLine("Nenhuma disciplina vinculada.");
            }
            else
            {
                foreach(Disciplina disciplina in curso.Disciplinas)
                {
                    Console.WriteLine(disciplina.Nome);
                    Console.WriteLine(disciplina.ProfessorResponsavel.Nome);
                }                
            }
            List<Aluno> alunosMatriculadosCurso = _alunos
                .Where(aluno => aluno.Matriculas
                .Any(m => m.Curso.Codigo == curso.Codigo))
                .ToList();
           
            if (alunosMatriculadosCurso.Count == 0)
            {
                Console.WriteLine("Nenhum aluno está matriculado.");
            }
            else
            {
                foreach(Aluno aluno in alunosMatriculadosCurso)
                {
                    Console.WriteLine($"{aluno.Nome}");
                }
            }
        }

       
    }

    public void CadastrarProfessor(string nome, string cpf, string email, string registro, string especialidade)
    {
        if (_professores.Any(p => p.CPF == cpf))
        {
            throw new InvalidOperationException("Existe um professor cadastrado com este CPF.");
        }

        if (_professores.Any(p => p.Registro == registro))
        {
            throw new InvalidOperationException("Existe um professor cadastrado com este registro.");
        }

        Professor professor = new Professor(
            nome, 
            cpf, 
            email, 
            registro, 
            especialidade
         );

        _professores.Add(professor);
    }

    public void CadastrarDisciplina(string codigo, string nome, int cargaHoraria, string registroProfessor)
    {
        if (_disciplinas.Any(d => d.Codigo == codigo))
        {
            throw new InvalidOperationException("Existe uma disciplina cadastrada com este código.");
        }

        Professor? professor = _professores.FirstOrDefault(p => p.Registro == registroProfessor);

        if (professor is null)
        {
            throw new InvalidOperationException("O professor não está cadastrado no sistema.");
        }

        Disciplina disciplina = new Disciplina(codigo, nome, cargaHoraria, professor);

        _disciplinas.Add(disciplina);
    }

    public void VincularDisciplinaAoCurso(string codigoCurso, string codigoDisciplina)
    {
        Curso? curso = _cursos.FirstOrDefault(c => c.Codigo == codigoCurso);

        if (curso is null)
        {
            throw new InvalidOperationException("O curso não está cadastrado no sistema.");
        }

        Disciplina? disciplina = _disciplinas.FirstOrDefault(d => d.Codigo == codigoDisciplina);

        if (disciplina is null)
        {
            throw new InvalidOperationException("A disciplina não está cadastrada no sistema.");
        }

        curso.AdicionarDisciplina(disciplina);
    }

    public void LancarNota(
        string numeroMatricula,
        string codigoCurso,
        string codigoDisciplina,
        decimal nota)
    {
        Aluno? aluno = _alunos.FirstOrDefault(a => a.NumeroMatricula == numeroMatricula);

        if (aluno is null)
            throw new InvalidOperationException("Aluno não encontrado.");


        Matricula? matricula = aluno.Matriculas.FirstOrDefault(m => m.Curso.Codigo == codigoCurso);

        if (matricula is null)
            throw new InvalidOperationException("O aluno não está matriculado neste curso.");
       

        Disciplina? disciplina = matricula.Curso.Disciplinas.FirstOrDefault(d => d.Codigo == codigoDisciplina);

        if (disciplina is null)
            throw new InvalidOperationException("A disciplina não pertence a este curso.");


        matricula.Boletim.RegistrarNota(disciplina, nota);
    }

    public void ConsultarBoletim(
        string numeroMatricula,
        string codigoCurso)
    {
        Aluno? aluno = _alunos.FirstOrDefault(a => a.NumeroMatricula == numeroMatricula);

        if (aluno is null)
            throw new InvalidOperationException("Aluno não encontrado.");

        Matricula? matricula = aluno.Matriculas.FirstOrDefault(m => m.Curso.Codigo == codigoCurso);

        if (matricula is null)
            throw new InvalidOperationException("O aluno não está matriculado neste curso.");

        Curso curso = matricula.Curso;

        Console.WriteLine("========= BOLETIM =========");
        Console.WriteLine($"Aluno: {aluno.Nome}");
        Console.WriteLine($"Matrícula: {aluno.NumeroMatricula}");
        Console.WriteLine($"Curso: {curso.Nome}");
        Console.WriteLine($"Tipo: {curso.TipoCurso}");
        Console.WriteLine();

        foreach (Disciplina disciplina in curso.Disciplinas)
        {
            decimal nota = matricula.Boletim.ObterNota(disciplina);

            string situacao = ObterSituacao(
                nota,
                curso.TipoCurso
            );

            Console.WriteLine($"Disciplina: {disciplina.Nome}");
            Console.WriteLine($"Nota: {nota}");
            Console.WriteLine($"Situação: {situacao}");
            Console.WriteLine();
        }

    }

    public string ObterSituacao(decimal nota, TipoCurso tipoCurso)
    {
        decimal notaMinima;

        if (tipoCurso == TipoCurso.GRADUACAO)
        {
            notaMinima = 7;
        }
        else if (tipoCurso == TipoCurso.POS_GRADUACAO)
        {
            notaMinima = 8;
        }
        else
        {
            throw new ArgumentException("Tipo de curso inválido.");
        }

        return nota >= notaMinima
            ? "Aprovado"
            : "Reprovado";
    }

    public void ConsultarPessoas()
    {
        if (_alunos.Count == 0 && _professores.Count == 0)
        {
            throw new InvalidOperationException("Não há alunos e professores cadastradas.");
        }

        Console.WriteLine("========== ALUNOS ==========");

        foreach (Aluno aluno in _alunos)
        {
            Console.WriteLine($"Nome: {aluno.Nome}");
            Console.WriteLine($"CPF: {aluno.CPF}");
            Console.WriteLine($"E-mail: {aluno.Email}");
            Console.WriteLine($"Número de matrícula: {aluno.NumeroMatricula}");

            if (aluno.Matriculas.Count == 0)
            {
                Console.WriteLine($"Nenhum curso matriculado para o aluno {aluno.Nome}.");
            }
            else
            {
                Console.WriteLine("Cursos:");

                foreach (Matricula matricula in aluno.Matriculas)
                {
                    Console.WriteLine($"- {matricula.Curso.Nome}");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("======== PROFESSORES ========");

        foreach (Professor professor in _professores)
        {
            Console.WriteLine($"Nome: {professor.Nome}");
            Console.WriteLine($"CPF: {professor.CPF}");
            Console.WriteLine($"E-mail: {professor.Email}");
            Console.WriteLine($"Registro: {professor.Registro}");
            Console.WriteLine($"Especialidade: {professor.Especialidade}");
            Console.WriteLine();
        }
    }

    public void EnviarNotificacao(string cpf, string mensagem)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("O CPF deve ser informado.");

        if (string.IsNullOrWhiteSpace(mensagem))
            throw new ArgumentException("A mensagem deve ser informada.");

        Pessoa? pessoa = _alunos.FirstOrDefault(a => a.CPF == cpf);

        pessoa ??= _professores.FirstOrDefault(p => p.CPF == cpf);

        if (pessoa is null)
            throw new InvalidOperationException("Não foi encontrada nenhuma pessoa com este CPF.");

        Console.WriteLine();
        Console.WriteLine("===== NOTIFICAÇÃO =====");
        Console.WriteLine($"Para: {pessoa.Nome}");
        Console.WriteLine($"Mensagem: {mensagem}");
        Console.WriteLine("=======================");
    }
}
