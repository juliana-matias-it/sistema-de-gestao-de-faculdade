using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Aluno : Pessoa
    {
        public string NumeroMatricula { get; set; }
        public List<Matricula> Matriculas { get; set; }

        public Aluno(
            string nome,
            string cpf,
            string email,
            string numeroMatricula) : base(nome, cpf, email)
        {
            NumeroMatricula = ValidarNumeroMatricula(numeroMatricula);
            Matriculas = new List<Matricula>();
        }

        private string ValidarNumeroMatricula(string numeroMatricula)
        {
            if (string.IsNullOrWhiteSpace(numeroMatricula))
            {
                throw new ArgumentException(
                    "O número de matrícula deve ser informado."
                );
            }
            return numeroMatricula;
        }
    }
}

