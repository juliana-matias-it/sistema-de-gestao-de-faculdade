

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
        foreach (var entry in disciplinas)
        {
            if (entry.Key.Equals(disciplina))
            {
                decimal nota = entry.Value;
                if (tipoCurso == TipoCurso.Graduacao)
                {
                    if (nota >= 7)
                    {
                        Console.WriteLine($"Disciplina: {disciplina.Nome} - Aprovado");
                    }
                    else
                    {
                        Console.WriteLine($"Disciplina: {disciplina.Nome} - Reprovado");
                    }
                }
                else if (tipoCurso == TipoCurso.PosGraduacao)
                {
                    if (nota >= 8)
                    {
                        Console.WriteLine($"Disciplina: {disciplina.Nome} - Aprovado");
                    }
                    else
                    {
                        Console.WriteLine($"Disciplina: {disciplina.Nome} - Reprovado");
                    }
                }
                return;
            }
        }
        if (!disciplinas.ContainsKey(disciplina))
        {
            throw new ArgumentException("Disciplina não encontrada no boletim.");
        }
    }

}