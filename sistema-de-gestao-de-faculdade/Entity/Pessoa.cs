
public abstract class Pessoa
{
    private string Nome { get; set; }
    private string CPF { get; set; }
    private string Email { get; set; }

    protected void ValidarPessoa(string nome, string cpf, string email)
    {
        ValidarNome(nome);
        ValidarCPF(cpf);
        ValidarEmail(email);

        Nome = nome;
        CPF = cpf;
        Email = email;
    }
   public void ValidarNome(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            throw new ArgumentException("O nome não pode ser nulo ou vazio.");
        }
        if (nome.Length < 3)
        {
            throw new ArgumentException("O nome deve ter pelo menos 3 caracteres.");
        }
    }
   
   public  void ValidarCPF(string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
        {
            throw new ArgumentException("O CPF não pode ser nulo ou vazio.");
        }
        if (cpf.Length != 11)
        {
            throw new ArgumentException("O CPF deve ter exatamente 11 caracteres.");
        }
    }

   public  void ValidarEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("O email não pode ser nulo ou vazio.");
        }
        if (!email.Contains("@"))
        {
            throw new ArgumentException("O email deve conter o caractere '@'.");
        }
    }
}