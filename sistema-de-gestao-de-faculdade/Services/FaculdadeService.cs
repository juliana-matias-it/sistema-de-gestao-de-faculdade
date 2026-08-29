public class FaculdadeService
{
    private List<Professor> _professores = new();
    private List<Disciplina> _disciplinas = new();
    private List<Curso> _cursos = new();

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

        if ( professor is null )
            throw new InvalidOperationException("O professor não esta cadastrado no sistema");

        Disciplina disciplina = new Disciplina(
            codigo,
            nome,
            cargaHoraria,
            professor
        );

        _disciplinas.Add(disciplina);
    }

    public void VincularDisciplinaAoCurso(
        string codigoCurso, 
        string codigoDisciplina)
    {
        Curso? curso = _cursos.FirstOrDefault(c => c.Codigo == codigoCurso);

        if (curso is null)
            throw new InvalidOperationException("O curso não esta cadastrado no sistema");


        Disciplina? disciplina = _disciplinas.FirstOrDefault(d => d.Codigo == codigoDisciplina);

        if (disciplina is null)
            throw new InvalidOperationException("A disciplina não esta cadastrada no sistema");

        curso.AdicionarDisciplina(disciplina);
    }
}