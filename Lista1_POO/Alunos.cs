// Classe Aluno
public class Aluno
{
    public string Nome;
    public int Idade;
    public string ID;
    public Disciplina Disciplina; // Relacionamento com a disciplina

    public void MostrarInformacoes()
    {
        Console.WriteLine($"Aluno {Nome}; Idade {Idade}; ID {ID}.");
        if (Disciplina != null)
        {
            Console.WriteLine($"Estou matriculado na disciplina {Disciplina.NomeDisciplina}, sala {Disciplina.Turma.NumeroSala}.");
        }
    }
}


