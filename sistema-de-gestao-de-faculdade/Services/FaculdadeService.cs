using sistema_de_gestao_de_faculdade.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_gestao_de_faculdade.Services
{

    public class FaculdadeService
    {
        private List<Aluno> alunos;

        public FaculdadeService()
        {
            alunos = new List<Aluno>();
        }

        public void CadastrarAluno(Aluno aluno)
        {

            if (alunos.Any(x => x.NumeroMatricula == aluno.NumeroMatricula))
            {
                throw new ArgumentException($"Número de matrícula {aluno.NumeroMatricula} já cadastrado. Informe um número de matrícula válido.");
            }

            try
            {
                alunos.Add(aluno);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }