using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Contadores de IDs
    static int contadorAlunoID = 0;
    static int contadorDisciplinaID = 0;
    static int contadorTurmaID = 0;

    static void Main(string[] args)
    {
        List<Aluno> alunos = new List<Aluno>();
        List<Disciplina> disciplinas = new List<Disciplina>();
        List<Turma> turmas = new List<Turma>();

        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n-----Menu de Cadastro-----");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Cadastrar Disciplina");
            Console.WriteLine("3. Cadastrar Turma");
            Console.WriteLine("4. Mostrar Todos os Alunos");
            Console.WriteLine("5. Mostrar Todas as Disciplinas");
            Console.WriteLine("6. Mostrar Todas as Turmas");
            Console.WriteLine("7. Pesquisar Aluno");
            Console.WriteLine("8. Pesquisar Disciplina");
            Console.WriteLine("9. Pesquisar Turma");
            Console.WriteLine("0. Sair");
            Console.WriteLine("--------------------------");
            Console.Write("\nEscolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    alunos.Add(CadastrarAluno(disciplinas));
                    break;
                case 2:
                    disciplinas.Add(CadastrarDisciplina(turmas));
                    break;
                case 3:
                    turmas.Add(CadastrarTurma());
                    break;
                case 4:
                    MostrarAlunos(alunos);
                    break;
                case 5:
                    MostrarDisciplinas(disciplinas);
                    break;
                case 6:
                    MostrarTurmas(turmas);
                    break;
                case 7:
                    PesquisarAluno(alunos);
                    break;
                case 8:
                    PesquisarDisciplina(disciplinas);
                    break;
                case 9:
                    PesquisarTurma(turmas);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static Aluno CadastrarAluno(List<Disciplina> disciplinas)
    {
        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine();
        
        Console.Write("Digite a idade do aluno: ");
        int idade = int.Parse(Console.ReadLine());

        // Gerar ID automaticamente
        string id = (++contadorAlunoID).ToString();

        if (disciplinas.Count > 0)
        {
            Console.WriteLine("Escolha a disciplina:");
            for (int i = 0; i < disciplinas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {disciplinas[i].NomeDisciplina}");
            }
            int disciplinaEscolhida = int.Parse(Console.ReadLine()) - 1;
            Disciplina disciplina = disciplinas[disciplinaEscolhida];

            Aluno aluno = new Aluno { Nome = nome, Idade = idade, ID = id, Disciplina = disciplina };
            disciplina.Turma.AdicionarAluno(aluno);
            return aluno;
        }
        else
        {
            Console.WriteLine("Nenhuma disciplina cadastrada. Cadastrando aluno sem disciplina.");
            return new Aluno { Nome = nome, Idade = idade, ID = id };
        }
    }

    static Disciplina CadastrarDisciplina(List<Turma> turmas)
    {
        Console.Write("Digite o nome da disciplina: ");
        string nomeDisciplina = Console.ReadLine();
        
        // Gerar ID automaticamente
        string idDisciplina = (++contadorDisciplinaID).ToString();

        if (turmas.Count > 0)
        {
            Console.WriteLine("Escolha a turma:");
            for (int i = 0; i < turmas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {turmas[i].NumeroSala} - Professor: {turmas[i].NomeProfessor}");
            }
            int turmaEscolhida = int.Parse(Console.ReadLine()) - 1;
            Turma turma = turmas[turmaEscolhida];

            return new Disciplina { NomeDisciplina = nomeDisciplina, IdDisciplina = idDisciplina, Turma = turma };
        }
        else
        {
            Console.WriteLine("Nenhuma turma cadastrada. Cadastrando disciplina sem turma.");
            return new Disciplina { NomeDisciplina = nomeDisciplina, IdDisciplina = idDisciplina };
        }
    }

    static Turma CadastrarTurma()
    {
        Console.Write("Digite o nome do professor: ");
        string nomeProfessor = Console.ReadLine();
        
        Console.Write("Digite o número da sala: ");
        string numeroSala = Console.ReadLine();

        // Gerar ID automaticamente
        string idTurma = (++contadorTurmaID).ToString();

        return new Turma { NomeProfessor = nomeProfessor, NumeroSala = numeroSala, ID = idTurma };
    }

    static void MostrarAlunos(List<Aluno> alunos)
    {
        Console.WriteLine("\nLista de Alunos:");
        foreach (var aluno in alunos)
        {
            aluno.MostrarInformacoes();
        }
    }

    static void MostrarDisciplinas(List<Disciplina> disciplinas)
    {
        Console.WriteLine("\nLista de Disciplinas:");
        foreach (var disciplina in disciplinas)
        {
            Console.WriteLine($"Disciplina: {disciplina.NomeDisciplina}, ID: {disciplina.IdDisciplina}");
        }
    }

    static void MostrarTurmas(List<Turma> turmas)
    {
        Console.WriteLine("\nLista de Turmas:");
        foreach (var turma in turmas)
        {
            Console.WriteLine($"Turma: {turma.ID}, Professor: {turma.NomeProfessor}, Sala: {turma.NumeroSala}");
            turma.MostrarAlunos();
        }
    }

    // Métodos de Pesquisa

    static void PesquisarAluno(List<Aluno> alunos)
    {
        Console.Write("Digite o ID ou Nome do aluno: ");
        string busca = Console.ReadLine();

        var alunoEncontrado = alunos.FirstOrDefault(a => a.ID == busca || a.Nome.Equals(busca, StringComparison.OrdinalIgnoreCase));
        if (alunoEncontrado != null)
        {
            alunoEncontrado.MostrarInformacoes();
        }
        else
        {
            Console.WriteLine("Aluno não encontrado.");
        }
    }

    static void PesquisarDisciplina(List<Disciplina> disciplinas)
    {
        Console.Write("Digite o ID ou Nome da disciplina: ");
        string busca = Console.ReadLine();

        var disciplinaEncontrada = disciplinas.FirstOrDefault(d => d.IdDisciplina == busca || d.NomeDisciplina.Equals(busca, StringComparison.OrdinalIgnoreCase));
        if (disciplinaEncontrada != null)
        {
            Console.WriteLine($"Disciplina: {disciplinaEncontrada.NomeDisciplina}, ID: {disciplinaEncontrada.IdDisciplina}");
        }
        else
        {
            Console.WriteLine("Disciplina não encontrada.");
        }
    }

    static void PesquisarTurma(List<Turma> turmas)
    {
        Console.Write("Digite o ID ou Nome do Professor: ");
        string busca = Console.ReadLine();

        var turmaEncontrada = turmas.FirstOrDefault(t => t.ID == busca || t.NomeProfessor.Equals(busca, StringComparison.OrdinalIgnoreCase));
        if (turmaEncontrada != null)
        {
            Console.WriteLine($"Turma: {turmaEncontrada.ID}, Professor: {turmaEncontrada.NomeProfessor}, Sala: {turmaEncontrada.NumeroSala}");
            turmaEncontrada.MostrarAlunos();
        }
        else
        {
            Console.WriteLine("Turma não encontrada.");
        }
    }
}


