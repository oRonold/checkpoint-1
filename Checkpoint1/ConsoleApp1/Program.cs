Aluno al = new Aluno("Ronald", 19, "ADS");

al.Apresentar();

//Classe abstrata nao pode ser instanciada
public abstract class Pessoa
{
    //Variaveis
    private string _nome;

    //Propriedades
    public string Nome { get; }
    public int Idade { get; set; }

    //Construtores
    public Pessoa()
    {

    }

    //Definindo que o atributo _nome recebera o valor como o parametro nome do construtor
    //A Propriedade Nome recebera o valor de _nome
    public Pessoa(string nome, int idade)
    {
        this._nome = nome;
        this.Nome = _nome;
        this.Idade = idade;
    }

    //Metodos
    //virtual significa que o metodo pode ser sobreescrito por outras classes filhas 
    public virtual void Apresentar()
    {
        Console.WriteLine($"Meu nome é {this.Nome} e minha idade é {this.Idade} anos");
    }

}

//Fazemos herança com :
public class Aluno : Pessoa
{
    public string Curso { get; set; }

    //Criando construtor sendo classe filha
    public Aluno(string nome, int idade, string curso) : base(nome, idade)
    {
        this.Curso = curso;
    }

    //Sobreescrevendo metodo Apresentar da classe Pessoa
    public override void Apresentar()
    {
        base.Apresentar();
        Console.WriteLine($"e o meu curso é {this.Curso}");
    }

}