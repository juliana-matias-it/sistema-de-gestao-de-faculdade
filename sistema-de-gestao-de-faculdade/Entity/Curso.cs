using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Curso
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public TipoCurso TipoCurso { get; private set; }
        public List<Disciplina> Disciplinas { get; private set; }

        public Curso(string codigo, string nome, TipoCurso tipoCurso)
        {
            Codigo = codigo;
            Nome = nome;
            TipoCurso = tipoCurso;
            List<Disciplina> Disciplinas = new();
        }
        public void AdicionarDisciplina(Disciplina disciplina)
        {
            if (Disciplinas.Any(d => d.Codigo == disciplina.Codigo))            
                throw new InvalidOperationException("Essa disciplina já está cadastrada a este curso!");

            Disciplinas.Add(disciplina);
        }
    }
}
