

public class Boletim
{
    
    private Dictionary<Disciplina, decimal> disciplinas = new Dictionary<Disciplina, decimal>();
    public double notas { get; private set; }


    public Boletim()
    {}
    public void LancarNota(Disciplina disciplina, decimal nota)
    {
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentException("Nota inválida. A nota deve estar entre 0 e 10.");
        }
        disciplinas[disciplina] = nota;
    }
    
    public void ObterSituacao(Disciplina disciplina, TipoCurso tipoCurso)
    {
        if (!disciplinas.ContainsKey(disciplina))
        {
            throw new ArgumentException("Disciplina não encontrada no boletim.");
        }
    }

}