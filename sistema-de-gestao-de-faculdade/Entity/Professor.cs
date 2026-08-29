public class Professor : Pessoa
{
    public string Registro { get; private set; }
    public string Especialidade { get; private set; }

    public Professor(
        string nome,
        string cpf,
        string email,
        string registro,
        string especialidade
    ) : base(nome, cpf, email)
    {
        ValidarRegistro(registro);
        ValidarEspecialidade(especialidade);

        Registro = registro;
        Especialidade = especialidade;
    }

    private void ValidarRegistro(string registro)
    {
        if (string.IsNullOrWhiteSpace(registro))
            throw new ArgumentException("O registro é obrigatorio");
    }

    private void ValidarEspecialidade (string especialidade)
    {
        if (string.IsNullOrWhiteSpace(especialidade))
            throw new ArgumentException("A especialidade é obrigatoria");
    }
}