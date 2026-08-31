namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Aluno : Pessoa
    {
        public string NumeroMatricula { get; private set; }
        public List<Matricula> Matriculas { get; private set; }

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

        public void AdicionarMatricula(Matricula matricula)
        {
            if (Matriculas.Any(m => m.Curso.Codigo == matricula.Curso.Codigo))
            {
                throw new InvalidOperationException("O aluno já está matriculado neste curso");
            }
            Matriculas.Add(matricula);
        }
    }
}
