

public class Boletim
{
    private Dictionary<Disciplina, decimal> disciplinas;
   
    public Boletim()
    {
        disciplinas = new Dictionary<Disciplina, decimal>();
    }
    public void LancarNota(KeyValuePair<Disciplina, decimal> disciplinaNota, decimal nota)
    
    {
        if (disciplinaNota.Key == null)
        {
            throw new ArgumentException("Disciplina não pode ser nula.");
        }
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentOutOfRangeException("Nota deve estar entre 0 e 10.");
        }
        disciplinas[disciplinaNota.Key] = nota;
    }
    
    public void ObterSituacao(Dictionary<Disciplina, decimal> disciplinas, TipoCurso tipoCurso)
    {
        
        foreach (var disciplina in disciplinas.Keys)
        {
            if (disciplinas[disciplina] < 6)
            {
                throw new InvalidOperationException($"Aluno reprovado na disciplina {disciplina.Nome}.");
            }
        }
        if (tipoCurso == TipoCurso.Graduacao)
        {
            foreach (var disciplina in disciplinas.Keys)
            {
                if (disciplinas[disciplina] < 7)
                {
                    throw new InvalidOperationException($"Aluno reprovado na disciplina {disciplina.Nome}.");
                }
            }
        }
        if (tipoCurso == TipoCurso.PosGraduacao)
        {
            foreach (var disciplina in disciplinas.Keys)
            {
                if (disciplinas[disciplina] < 8)
                {
                    throw new InvalidOperationException($"Aluno reprovado na disciplina {disciplina.Nome}.");
                }
            }
        } 
        
    }
}