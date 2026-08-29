public class Disciplina
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public int CargaHoraria { get; private set; }
    public Professor ProfessorResponsavel { get; private set; }

    public Disciplina(
        string codigo,
        string nome,
        int cargaHoraria,
        Professor professorResponsavel)
    {
        ValidarCodigo(codigo);
        ValidarNome(nome);
        ValidarCargaHoraria(cargaHoraria);
        ValidarProfessorResponsavel(professorResponsavel);

        Codigo = codigo;
        Nome = nome;
        CargaHoraria = cargaHoraria;
        ProfessorResponsavel = professorResponsavel;
    }

    private void ValidarCodigo(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("O código da disciplina é obrigatório.");
    }

    private void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome da disciplina é obrigatório.");
    }

    private void ValidarCargaHoraria(int cargaHoraria)
    {
        if (cargaHoraria <= 0)
            throw new ArgumentException("A carga horária deve ser maior que zero.");
    }

    private void ValidarProfessorResponsavel(Professor professorResponsavel)
    {
        if (professorResponsavel is null)
            throw new ArgumentException("A disciplina deve possuir um professor responsável.");
    }
}