using System.Collections.Generic;
using static System.Console;
using System.Linq;
using sistema_de_gestao_de_faculdade.Entity;
public class FaculdadeService
{
    private List<Curso> _cursos;

    public FaculdadeService()
    {
        _cursos = new List<Curso>();
    }

    public void CadastrarCurso(string codigo, string nome, TipoCurso tipoCurso)
    {
        if (_cursos.Any(curso => curso.Codigo == codigo))
        {
            throw new InvalidOperationException(
                "Curso já cadastrado."
            );
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
}