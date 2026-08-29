public class FaculdadeService
{
    private List<Professor> _professores = new();

    public void CadastrarProfessor(
        string nome,
        string cpf,
        string email,
        string registro,
        string especialidade)
    {
        if (_professores.Any(p => p.Cpf == cpf))
            throw new InvalidOperationException(
                "Existe um professor cadastrado com este CPF."
            );

        if (_professores.Any(p => p.Registro == registro))
            throw new InvalidOperationException(
                "Existe um professor cadastrado com este registro."
            );

        Professor professor = new Professor(
            nome,
            cpf,
            email,
            registro,
            especialidade
        );

        _professores.Add(professor);
    }
}