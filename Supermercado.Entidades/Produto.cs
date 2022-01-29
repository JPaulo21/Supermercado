using System;

public class Produto
{

	private int codigo;
	private string nome;
	private double preco;
	private string setor;
	private int quantidade;

	public Produto() { }

	public Produto(int codigo)
    {

		this.codigo = codigo;
    }

	public Produto(string nome, double preco, string setor)
	{

		this.nome = nome;
		this.preco = preco;
		this.setor = setor;

	}

	public Produto(int codigo, string nome, int qntd, double preco, string setor)
	{

		this.codigo = codigo;
		this.nome = nome;
		this.preco = preco;
		this.quantidade = qntd;
		this.setor = setor;

	}

	public int getCodigo() { return codigo; }

	public void setCodigo(int codigo) { this.codigo = codigo; }

	public string getNome() { return nome; }

	public void setNome(string nome){ this.nome = nome; }

	public double getPreco() { return preco; }

	public void setPreco(double preco){	this.preco = preco;}

	public string getSetor() { return setor; } 
	
	public void setSetor(string setor) {this.setor = setor; }

	public int getQntd() { return quantidade; }

	public void setQntd(int quantidade) { this.quantidade = quantidade; }
}
