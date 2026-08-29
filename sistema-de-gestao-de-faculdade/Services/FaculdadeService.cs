public class FaculdadeService
{
    private List<Professor> _professores = new();
    private List<Disciplina> _disciplinas = new();

    public void CadastrarProfessor(
        string nome,
        string cpf,
        string email,
        string registro,
        string especialidade)
    {
        if (_professores.Any(p => p.Cpf == cpf))
            throw new InvalidOperationException("Existe um professor cadastrado com este CPF.");

        if (_professores.Any(p => p.Registro == registro))
            throw new InvalidOperationException("Existe um professor cadastrado com este registro.");

        Professor professor = new Professor(
            nome,
            cpf,
            email,
            registro,
            especialidade
        );

        _professores.Add(professor);
    }

    public void CadastrarDisciplina(
        string codigo,
        string nome, 
        int cargaHoraria, 
        string registroProfessor)
    {
        if( _disciplinas.Any(d => d.Codigo == codigo))
            throw new InvalidOperationException("Existe uma disciplina cadastrada com este código.");

        Professor? professor = _professores.FirstOrDefault(p => p.Registro == registroProfessor);

        if ( professor == null )
            throw new InvalidOperationException("O professor não esta cadastrado no sistema");

        Disciplina disciplina = new Disciplina(
            codigo,
            nome,
            cargaHoraria,
            professor
        );

        _disciplinas.Add(disciplina);
    }

}