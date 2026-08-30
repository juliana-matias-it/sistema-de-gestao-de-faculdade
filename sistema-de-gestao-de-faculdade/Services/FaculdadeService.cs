using System.Collections.Generic;
using System.Linq;
using static System.Console;
using sistema_de_gestao_de_faculdade.Entity;

public class FaculdadeService
{
    private List<Professor> _professores;
    private List<Disciplina> _disciplinas;
    private List<Curso> _cursos;

    public FaculdadeService()
    {
        _cursos = new List<Curso>();
        _professores = new List<Professor>();
        _disciplinas = new List<Disciplina>();
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
            WriteLine("Nenhum curso cadastrado.");
            return;
        }

        foreach (Curso curso in _cursos)
        {
            WriteLine("==============================");
            WriteLine($"Código: {curso.Codigo}");
            WriteLine($"Nome: {curso.Nome}");
            WriteLine($"Tipo: {curso.TipoCurso}");
            WriteLine("==============================");
        }
    }

    public void CadastrarProfessor(
        string nome,
        string cpf,
        string email,
        string registro,
        string especialidade)
    {
        if (_professores.Any(p => p.Cpf == cpf))
            throw new InvalidOperationException("Existe um professor cadastrado com este CPF.");

        if (_professores.Any(p => p.Registro == registro))
            throw new InvalidOperationException("Existe um professor cadastrado com este registro.");

        Professor professor = new Professor(
            nome,
            cpf,
            email,
            registro,
            especialidade
        );

        _professores.Add(professor);
    }

    public void CadastrarDisciplina(
        string codigo,
        string nome,
        int cargaHoraria,
        string registroProfessor)
    {
        if (_disciplinas.Any(d => d.Codigo == codigo))
            throw new InvalidOperationException("Existe uma disciplina cadastrada com este código.");

        Professor? professor = _professores.FirstOrDefault(p => p.Registro == registroProfessor);

        if (professor is null)
            throw new InvalidOperationException("O professor não está cadastrado no sistema.");

        Disciplina disciplina = new Disciplina(
            codigo,
            nome,
            cargaHoraria,
            professor
        );

        _disciplinas.Add(disciplina);
    }

    public void VincularDisciplinaAoCurso(
        string codigoCurso,
        string codigoDisciplina)
    {
        Curso? curso = _cursos
            .FirstOrDefault(c => c.Codigo == codigoCurso);

        if (curso is null)
            throw new InvalidOperationException("O curso não está cadastrado no sistema.");

        Disciplina? disciplina = _disciplinas.FirstOrDefault(d => d.Codigo == codigoDisciplina);

        if (disciplina is null)
            throw new InvalidOperationException("A disciplina não está cadastrada no sistema.");

        curso.AdicionarDisciplina(disciplina);
    }
}