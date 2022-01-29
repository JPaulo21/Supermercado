using System;

namespace Supermercado
{
	public class Adm
	{
		private int codigo;
		private string nome;
		private string senha;

		public Adm() { }

		public Adm(string nome, string senha)
		{

			this.nome = nome;
			this.senha = senha;

		}

		public string getNome() { return nome; }

		public void setNome(string nome) { this.nome = nome; }

		public string getSenha() { return senha; }

		public void setSenha(string senha) { this.senha = senha; }

		public int getCodigo() { return codigo; }

		public void setCodigo(int codigo) { this.codigo = codigo; }

	}
}