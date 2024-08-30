// Classe Turma
public class Turma
{
    public string ID;
    public string NomeProfessor;
    public string NumeroSala;
    public List<Aluno> Alunos = new List<Aluno>(); // Lista de alunos na turma

    public void AdicionarAluno(Aluno aluno)
    {
        Alunos.Add(aluno);
    }

    public void MostrarAlunos()
    {
        Console.WriteLine($"\nNa sala {NumeroSala}, ministrada pelo professor {NomeProfessor}, estão os seguintes alunos:");
        foreach (Aluno aluno in Alunos)
        {
            Console.WriteLine($"- {aluno.Nome} (ID: {aluno.ID})");
        }
    }
}
