using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{ 
    class Carrinho
    {

        ProdutoDAO produto = new ProdutoDAO();
        List<Produto> produtos;

        public Carrinho()
        {

            produtos = new List<Produto>();
        }


        public double totalProdutos()
        {

            double total = 0;

            foreach(Produto p in produtos)
            {

                total += p.getPreco() * p.getQntd();
            }

            return total;

        }

        public int qntdProdutos()
        {
            int soma = 0;

            foreach (Produto p in produtos)
            {

                soma += p.getQntd();
            } 

            return soma; 
        }

        public void exibirProdutos()
        {

            foreach (Produto p in produtos)
            {

                Console.Write($"{p.getCodigo()} | {p.getQntd()} | {p.getNome()} | {p.getPreco()} \n");

            }

        }

        public void add(Produto p) {

            produtos.Add(p);

        }

        public void remover(Produto p)
        {

            produtos.Remove(p);
        }

        public List<Produto> getProdutos() {


            return produtos;
        
        }

        public void finalizarCompras()
        {

            foreach(Produto p in produtos)
            {

                produto.venda(p);
            }

        }

    }
}
