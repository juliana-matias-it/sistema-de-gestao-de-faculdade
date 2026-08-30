

public class FaculdadeService
{
    public List<Pessoa> pessoas;
    public List<Boletim> boletins;
    public List<Curso> cursos;

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
        Console.WriteLine("Nome\tCPF\tEmail");
        foreach (var pessoa in pessoas)
        {
            Console.WriteLine($"{pessoa.Nome}\t{pessoa.CPF}\t{pessoa.Email}");
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
        for(int i = 0; i < cursos.Count; i++)
        {
            var curso = cursos[i];
            if (curso == null)
            {
                throw new InvalidOperationException("Curso não encontrado.");
            }
        }
        for(int i = 0; i < disciplinas.Count; i++)
        {
            var disciplina = disciplinas[i];
            if (disciplina == null)
            {
                throw new InvalidOperationException("Disciplina não encontrada.");
            }
        }
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentOutOfRangeException("Nota deve estar entre 0 e 10.");
        }
        if (string.IsNullOrEmpty(numeroMatricula) || string.IsNullOrEmpty(codigoCurso) || string.IsNullOrEmpty(codigoDisciplina))
        {
            throw new ArgumentException("Número de matrícula, código do curso e código da disciplina não podem ser nulos ou vazios.");
        }
    }
}