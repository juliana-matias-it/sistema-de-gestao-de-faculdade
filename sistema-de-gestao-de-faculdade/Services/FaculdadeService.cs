

public class FaculdadeService
{
    public List<Pessoa> pessoas;
    public List<Boletim> boletins;

    public FaculdadeService()
    {
        pessoas = new List<Pessoa>();
        boletins = new List<Boletim>();
    }

    public void ConsultarBoletim(List<Matricula> matriculas, Curso curso)
    {
       for(int i = 0; i < matriculas.Count; i++)
        {
            var matricula = matriculas[i];
            if (matricula == null)
            {
                throw new InvalidOperationException("Matrícula não encontrada.");
            }
        }
        if (matriculas == null || matriculas.Count == 0)
        {
            throw new ArgumentException("Lista de matrículas não pode ser nula ou vazia.");
        }
        if (curso == null)
        {
            throw new ArgumentException("Curso não pode ser nulo.");
        }
    }

    public void ConsultarPessoa()
    {
       for(int i = 0; i < pessoas.Count; i++)
        {
            var pessoa = pessoas[i];
            if (pessoa == null)
            {
                throw new InvalidOperationException("Pessoa não encontrada.");
            }
        }
        if (pessoas.Count == 0)
        {
            throw new InvalidOperationException("Não há pessoas cadastradas.");
        }
    }
    
    public void LancarNota(string numeroMatricula, string codigoCurso, string codigoDisciplina, decimal nota)
    {
        for(int i = 0; i < boletins.Count; i++)
        {
            var boletim = boletins[i];
            if (boletim == null)
            {
                throw new InvalidOperationException("Boletim não encontrado.");
            }
        }
       
        if (string.IsNullOrEmpty(numeroMatricula) || string.IsNullOrEmpty(codigoCurso) || string.IsNullOrEmpty(codigoDisciplina))
        {
            throw new ArgumentException("Número de matrícula, código do curso e código da disciplina não podem ser nulos ou vazios.");
        }
    }
}