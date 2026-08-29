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

        public void MatricularAlunoCurso(string numeroMatricula, string codigoCurso)
        {
            if (!alunos.Any(x => x.NumeroMatricula == numeroMatricula))
            {
                throw new ArgumentException($"Aluno com a matrícula {numeroMatricula} não encontrado. Cadastre o aluno antes de matriculá-lo em um curso.");
            }

            if (!cursos.Any(x => x.Codigo == codigoCurso))
            {
                throw new ArgumentException($"Curso com o código {codigoCurso} não encontrado. Cadastre o curso antes de matriculá-lo.");
            }

            Aluno aluno = alunos.First(x => x.NumeroMatricula == numeroMatricula);
            Curso curso = cursos.First(x => x.Codigo == codigoCurso);

            if (aluno.Matriculas.Any(x => x.Curso.Codigo == codigoCurso))
            {
                throw new ArgumentException($"Aluno {aluno.Nome} já está matriculado no curso {codigoCurso}. Não é possível realizar a matrícula novamente.");
            }

            Matricula matricula = new Matricula(aluno, curso);
            aluno.Matriculas.Add(matricula);
        }

        public void ConsultarMatriculas()
        {
            if(alunos.Count == 0)
            {
                throw new ArgumentException("Não há alunos cadastrados.");
            }

            foreach(Aluno aluno in alunos)
            {
                Console.WriteLine($"Aluno: {aluno.Nome}");
                Console.WriteLine($"Matrícula: {aluno.NumeroMatricula}");

                foreach(Matricula matricula in aluno.Matriculas)
                {
                    Console.WriteLine($"Curso: {matricula.Curso.Nome}");
                    Console.WriteLine($"Tipo: {matricula.Curso.TipoCurso}");
                }
            }
        }
    }
}
