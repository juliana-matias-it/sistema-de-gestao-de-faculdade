namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Boletim
    {
        public Dictionary<Disciplina, decimal> BoletimNotas { get; private set; }

        public Boletim()
        {
            BoletimNotas = new Dictionary<Disciplina, decimal>();
        }

        public decimal ObterNotas(Disciplina disciplina)
        {
            if (!BoletimNotas.TryGetValue(disciplina, out decimal nota))
            {
                throw new ArgumentException($"Disciplina {disciplina.Nome} não encontrada no boletim.");
            }

            return nota;
        }

        public void RegistrarNota(Disciplina disciplina, decimal nota)
        {
            if (disciplina == null)
            {
                throw new ArgumentException("Disciplina não pode ser nula.");
            }

            if (nota < 0 || nota > 10)
            {
                throw new ArgumentOutOfRangeException("Nota deve estar entre 0 e 10.");
            }

            BoletimNotas[disciplina] = nota;
        }
    }
}