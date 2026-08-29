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
        
        public void CadastrarAluno()
        {
            Console.WriteLine("**Cadastro de Aluno**");
            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do aluno:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o email do aluno:");
            string email = Console.ReadLine();

            Console.WriteLine("Digite o número de matrícula do aluno:");
            string numeroMatricula = Console.ReadLine();
            Console.WriteLine();

            if(alunos.Any(x => x.NumeroMatricula == numeroMatricula))
            {
                throw new ArgumentException($"Número de matrícula {numeroMatricula} já cadastrado. Informe um número de matrícula válido.");
            }

            try
            {
                Aluno aluno = new Aluno(nome, cpf, email, numeroMatricula);
                alunos.Add(aluno);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("Cadastro realizado com sucesso!");
                Console.ResetColor();
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
