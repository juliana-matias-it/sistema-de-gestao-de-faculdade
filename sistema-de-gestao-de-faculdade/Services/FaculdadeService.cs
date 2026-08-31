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

    public List<Boletim> boletins;

    public FaculdadeService()
    {
        _alunos = new List<Aluno>();
        _professores = new List<Professor>();
        _disciplinas = new List<Disciplina>();
        _cursos = new List<Curso>();

        boletins = new List<Boletim>();
    }

    // MÉTODOS DA MAIN

    public void CadastrarAluno(Aluno aluno)
    {
        if (_alunos.Any(x => x.NumeroMatricula == aluno.NumeroMatricula))
        {
            throw new ArgumentException($"Número de matrícula {aluno.NumeroMatricula} já cadastrado. Informe um número de matrícula válido.");
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
        }
    }

    public void CadastrarProfessor(string nome, string cpf, string email, string registro, string especialidade)
    {
        if (_professores.Any(p => p.Cpf == cpf))
        {
            throw new InvalidOperationException("Existe um professor cadastrado com este CPF.");
        }

        if (_professores.Any(p => p.Registro == registro))
        {
            throw new InvalidOperationException("Existe um professor cadastrado com este registro.");
        }

        Professor professor = new Professor(nome, cpf, email, registro, especialidade);

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
  
    public void ConsultarBoletim(List<Matricula> matriculas, Curso curso)
    {
       for(int i = 0; i < matriculas.Count; i++)
        {
            var matricula = matriculas[i];
            if (matricula == null)
            {
                throw new InvalidOperationException("Matrícula não encontrada.");
            }
        }
        if (matriculas == null || matriculas.Count == 0)
        {
            throw new ArgumentException("Lista de matrículas não pode ser nula ou vazia.");
        }
        if (curso == null)
        {
            throw new ArgumentException("Curso não pode ser nulo.");
        }
    }

    public void ConsultarPessoa()
    {
       for(int i = 0; i < pessoas.Count; i++)
        {
            var pessoa = pessoas[i];
            if (pessoa == null)
            {
                throw new InvalidOperationException("Pessoa não encontrada.");
            }
        }
        Console.WriteLine("Nome\tCPF\tEmail");
        foreach (var pessoa in pessoas)
        {
            Console.WriteLine($"{pessoa.Nome}\t{pessoa.CPF}\t{pessoa.Email}");
        }
    }
    
    public void LancarNota(string numeroMatricula, string codigoCurso, string codigoDisciplina, decimal nota)
    {
        for(int i = 0; i < boletins.Count; i++)
        {
            var boletim = boletins[i];
            if (boletim == null)
            {
                throw new InvalidOperationException("Boletim não encontrado.");
            }
        }
        for(int i = 0; i < cursos.Count; i++)
        {
            var curso = cursos[i];
            if (curso == null)
            {
                throw new InvalidOperationException("Curso não encontrado.");
            }
        }
        for(int i = 0; i < disciplinas.Count; i++)
        {
            var disciplina = disciplinas[i];
            if (disciplina == null)
            {
                throw new InvalidOperationException("Disciplina não encontrada.");
            }
        }
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentOutOfRangeException("Nota deve estar entre 0 e 10.");
        }
        if (string.IsNullOrEmpty(numeroMatricula) || string.IsNullOrEmpty(codigoCurso) || string.IsNullOrEmpty(codigoDisciplina))
        {
            throw new ArgumentException("Número de matrícula, código do curso e código da disciplina não podem ser nulos ou vazios.");
        }
    }
}
