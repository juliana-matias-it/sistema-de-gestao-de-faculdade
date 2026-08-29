using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Matricula
    {
        public Aluno aluno { get; set; }

        public Matricula(Aluno aluno)
        {
            this.aluno = aluno;
        }
    }
}