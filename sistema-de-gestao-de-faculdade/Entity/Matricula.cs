namespace sistema_de_gestao_de_faculdade.Entity
{
    public class Matricula
    {
        public Aluno Aluno { get; private set; }
        public Curso Curso { get; private set; }
        public Boletim Boletim { get; private set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            this.Aluno = aluno;
            this.Curso = curso;
            this.Boletim = new Boletim();
        }
    }
}