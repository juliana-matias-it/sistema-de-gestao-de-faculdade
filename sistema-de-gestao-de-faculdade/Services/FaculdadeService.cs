

public class FaculdadeService
{
    private List<Pessoa> pessoas;
    private List<Boletim> boletins;

    public FaculdadeService()
    {
        pessoas = new List<Pessoa>();
        boletins = new List<Boletim>();
    }

    public void consultarBoletim(string nomeroMatricula, string codigoCurso)
    {
        if (string.IsNullOrEmpty(nomeroMatricula) || string.IsNullOrEmpty(codigoCurso))
        {
            throw new ArgumentException("Número de matrícula e código do curso não podem ser nulos ou vazios.");
        }
        if (boletins.Count == 0)
        {
            throw new InvalidOperationException("Não há boletins cadastrados.");
        }
    }

    public void consultarPessoa()
    {
        if (pessoas.Count == 0)
        {
            throw new InvalidOperationException("Não há pessoas cadastradas.");
        }
    }
    
    public void LançarNota(string numeroMatricula, string codigoCurso, string codigoDisciplina, decimal nota)
    {
        if (string.IsNullOrEmpty(numeroMatricula) || string.IsNullOrEmpty(codigoCurso) || string.IsNullOrEmpty(codigoDisciplina))
        {
            throw new ArgumentException("Número de matrícula, código do curso e código da disciplina não podem ser nulos ou vazios.");
        }
    }
}