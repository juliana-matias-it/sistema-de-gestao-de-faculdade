using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Matricula
    {
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public Boletim Boletim   { get; set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            this.Aluno = aluno;
            this.Curso = curso;
            this.Boletim = new Boletim();
        }
    }
}