/*
    CHECKPOINT 1 - Advanced Business Development with .NET
    Integrante:
    Ronald de Oliveira Farias - RM 552364

    Tema: Sistema de Gestao Escolar
 */
public abstract class Pessoa
{

    public string Nome { get; }
    public int Idade { get; }

    public Pessoa()
    {

    }

    public Pessoa(string nome, int idade)
    {
        this.Nome = nome;
        this.Idade = idade;
    }

    public virtual void Apresentar()
    {
        Console.WriteLine($"Me chamo {this.Nome}, tenho {this.Idade} anos");
    }
}

public class Sistema
{
    private List<Aluno> ListaDeAlunos = new List<Aluno>();
    private List<Professor> ListaDeProfessores = new List<Professor>();

    public void CadastrarAluno(int idade)
    {
        Console.WriteLine("Digite o nome do aluno: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o periodo do aluno: ");
        string periodo = Console.ReadLine();
        Console.WriteLine("Digite a matricula do aluno: ");
        string matricula = Console.ReadLine();

        Aluno aluno = new Aluno(nome, idade, periodo, matricula);
        ListaDeAlunos.Add(aluno);
        Console.WriteLine("Aluno cadastrado com sucesso!");
    }

    public void exibeListaAlunos()
    {
        foreach(Aluno aluno in ListaDeAlunos)
        {
            Console.WriteLine("\nAluno " + aluno.Nome + "\nIdade " + aluno.Idade + "\nPeriodo " + aluno.Periodo + "\nMatricula: ");
        }
    }

    public void ExibeListaProfessores()
    {
        foreach(Professor professor in ListaDeProfessores)
        {
            Console.WriteLine("\nProfessor " + professor.Nome + "\nIdade " + professor.Idade + "\nGraduacao " + professor.Graduacao + "\nDisciplina: " + professor.Disciplina);
            professor.Apresentar();
        }
    }

    public void CadastrarProfessor(int idade)
    {
        Console.WriteLine("Digite o nome do professor: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite a graduação do professor: ");
        string graduacao = Console.ReadLine();
        Console.WriteLine("Digite a disciplina do professor: ");
        string disciplina = Console.ReadLine();

        Professor professor = new Professor(nome, idade, graduacao, disciplina);
        ListaDeProfessores.Add(professor);
        Console.WriteLine("Professor cadastrado com sucesso!");
    }

}

internal class Aluno : Pessoa
{
    public string Periodo { get; }
    protected string NumeroMatricula { get; }

    public Aluno(string nome, int idade, string periodo, string matricula) : base(nome, idade)
    {
        this.Periodo = periodo;
        this.NumeroMatricula = matricula;
    } 
}   

public class Professor : Pessoa
{
    public string Disciplina { get; }
    public string Graduacao { get; }

    public Professor(string nome, int idade, string graduacao, string disciplina) : base(nome, idade)
    {
        this.Disciplina = disciplina;
        this.Graduacao = graduacao;
    }

    public override void Apresentar()
    {
        Console.WriteLine($"Me chamo {this.Nome}, tenho {this.Idade} anos, sou formado em {this.Graduacao} e leciono a disciplina de {this.Disciplina}");
    }

}   

class Program
{
    static void Main(string[] args)
    {
        Sistema sistema = new Sistema();

        int opcao = 0;

        while (true)
        {
            Console.WriteLine("\nBem-vindo ao sistema de gestão escolar");
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Professor");
            Console.WriteLine("3 - Exibir lista de alunos");
            Console.WriteLine("4 - Exibir lista de professores");
            Console.WriteLine("5 - Sair");

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
            {
                Console.WriteLine("Quantos alunos voce deseja cadastrar?");
                int qtd = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a idade do aluno mais novo: ");
                int idade = int.Parse(Console.ReadLine());

                for (int i = 0; i < qtd; i++)
                {
                    if(idade >= 6)
                    {
                        sistema.CadastrarAluno(idade);
                    } else
                    {
                        Console.WriteLine($"O aluno precisa ter no mínimo 6 anos para cursar o ensino fundamental");
                        continue;
                    }
                    
                }   
            }
            if(opcao == 2)
            {
                Console.WriteLine("Qual a idade do professor?");
                int idade = int.Parse(Console.ReadLine());
                if(idade < 18)
                {
                    Console.WriteLine("O professor precisa ter no mínimo 18 anos para lecionar");
                    continue;
                } else
                {
                    sistema.CadastrarProfessor(idade);
                    continue;
                }
            }
          if(opcao == 3)
            {
                Console.WriteLine("Lista de alunos cadastrados: ");
                sistema.exibeListaAlunos();
                continue;
            }
          if(opcao == 4)
            {
                Console.WriteLine("Lista de professores cadastrados: ");
                sistema.ExibeListaProfessores();
                continue;
            }
          if(opcao == 5)
            {
                Console.WriteLine("Saindo do sistema...");
                break;
            }

        }

        
    }
}   
