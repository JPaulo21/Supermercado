using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace Supermercado
{
    public class ProdutoDAO
    {

        List<Produto> produtos = new List<Produto>();


        public void cadastrar(Produto produto)
        {
            produtos.Add(produto);

            try
            {
                StreamWriter sr = new StreamWriter("C:\\Users\\JoãoPaulo\\Documents\\Sistema da Informação\\2021_2\\Lógica de Programação Algoritmica\\SuperMercado\\Supermercado\\produtos.txt");
                foreach (Produto p in produtos)
                {

                    sr.WriteLine($"{produto.getCodigo()}|{produto.getNome()}|{produto.getQntd()}|{produto.getPreco()}|{produto.getSetor()}");
                }
                sr.Close();
            } catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public List<Produto> obterTodosProdutos()
        {
            
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\JoãoPaulo\\Documents\\Sistema da Informação\\2021_2\\Lógica de Programação Algoritmica\\SuperMercado\\Supermercado\\produtos.txt");
                string AtributosProdutos = sr.ReadLine();

                while(AtributosProdutos != null)
                {
                    
                    string[] p = AtributosProdutos.Split("|");
                    produtos.Add(new Produto(int.Parse(p[0]), p[1], int.Parse(p[2]) , double.Parse(p[3]), p[4]));

                    AtributosProdutos = sr.ReadLine();
                }

                sr.Close();
            } catch (Exception e)
            {

                Console.WriteLine(e.Message);
            } 

            return produtos;
        }


        public List<Produto> obterProdutosPorSetor(string codigo)
        {
            List<Produto> produtosSetor = new List<Produto>();
            produtos = new List<Produto>();
            produtos = obterTodosProdutos();

            foreach (Produto p in produtos) 
            {

                if (p.getSetor() == codigo)
                {
                    produtosSetor.Add(p);
                }
                
            }


            return produtosSetor;

        }

        public Produto obterProduto(int codigo)
        {
            Produto produto = new Produto();
            produtos = new List<Produto>();
            produtos = obterTodosProdutos();

            foreach(Produto p in produtos)
            {
                if(p.getCodigo() == codigo)
                {
                    produto = p;
                }
            }

            return produto;

        }

        public void atualizar(Produto produto)
        {

            produtos = new List<Produto>();
            produtos = obterTodosProdutos();

            foreach (Produto p in produtos)
            {
                if (p.getCodigo() == produto.getCodigo())
                {
                    p.setNome(produto.getNome());
                }
            }

            try {
                StreamWriter sr = new StreamWriter("C:\\Users\\JoãoPaulo\\Documents\\Sistema da Informação\\2021_2\\Lógica de Programação Algoritmica\\SuperMercado\\Supermercado\\produtos.txt");
                foreach (Produto p in produtos)
                {

                    sr.WriteLine($"{p.getCodigo()}|{p.getNome()}|{p.getQntd()}|{p.getPreco()}|{p.getSetor()}");
                }
                sr.Close();
            } catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public void remover(int codigo)
        {
            produtos = new List<Produto>();
            produtos = obterTodosProdutos();

            foreach (Produto p in produtos)
            {
                if (p.getCodigo() == codigo)
                {
                    produtos.Remove(p);
                }
            }

            try
            {
                StreamWriter sr = new StreamWriter("C:\\Users\\JoãoPaulo\\Documents\\Sistema da Informação\\2021_2\\Lógica de Programação Algoritmica\\SuperMercado\\Supermercado\\produtos.txt");
                foreach (Produto p in produtos)
                {

                    sr.WriteLine($"{p.getCodigo()}|{p.getNome()}|{p.getQntd()}|{p.getPreco()}|{p.getSetor()}");
                }
                sr.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public void venda(Produto produto)
        {
            produtos = new List<Produto>();
            produtos = obterTodosProdutos();

            try
            {
                StreamWriter sr = new StreamWriter("C:\\Users\\JoãoPaulo\\Documents\\Sistema da Informação\\2021_2\\Lógica de Programação Algoritmica\\SuperMercado\\Supermercado\\produtos.txt");
                foreach (Produto p in produtos)
                {

                    sr.WriteLine($"{p.getCodigo()}|{p.getNome()}|{ p.getQntd() - produto.getQntd()}|{p.getPreco()}|{p.getSetor()}");
                }
                sr.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }

    }

}
