using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{
    public class Mercado
    {

        List<Produto> produtos = new List<Produto>();
        ProdutoDAO produtoDAO = new ProdutoDAO();
        Carrinho carrinho = new Carrinho();
        string adc = "";

        public void Corredores()
        {
            bool v = true;
            produtos = produtoDAO.obterTodosProdutos();

            do
            {
                Console.Clear();
                Console.WriteLine($"Varejista Uninassau\nMercado");
                dadosCarrinho();
                Console.WriteLine("Bem vindo! ");
                Console.Write("1.Alimentos\n2.Bebidas\n3.Higiene Pessoal\n4.Limpeza\n5.Eletronicos\n6.Todos os produtos\n\n7.Finalizar Compras\n8.Voltar\n\nSelecionar: ");

                switch (Console.ReadKey().KeyChar)
                {

                    case '1': exibirCorredor("1", "Alimentos"); break;
                    case '2': exibirCorredor("2", "Bebidas"); break;
                    case '3': exibirCorredor("3", "Higiene Pessoal"); break;
                    case '4': exibirCorredor("4", "Limpeza"); break;
                    case '5': exibirCorredor("5", "Eletronicos"); break;
                    case '6': listarProdutos(); break;
                    case '7': exibirCarrinho(); adc = ""; v = false; break;
                    case '8': carrinho = new Carrinho(); adc = ""; v = false; break;

                }

            } while (v);
        }

        public void exibirCorredor(string setorNum, string setor)
        {

            bool v = true;
            do
            {

                produtos = produtoDAO.obterProdutosPorSetor(setorNum);

                Console.Clear();
                Console.WriteLine($"Varejista Uninassau\nMercado");
                dadosCarrinho();
                Console.WriteLine($"Corredor {setor}\nCódigo | Qntd. | Descrição | Preço");

                foreach (Produto p in produtos)
                {

                    Console.WriteLine($"{p.getCodigo()}      | {p.getQntd()}     | {p.getNome()} | R${Math.Round(p.getPreco(), 2)} ");
                }


                Console.WriteLine("1.Adicionar Produto ao Carrinho || 2.Ver Carrinho || 3.Voltar ");
                switch (Console.ReadKey().KeyChar)
                {

                    case '1': addProduto(); v = true; break;
                    case '2': exibirCarrinho();/* v = false*/; break;
                    case '3': v = false; break;

                    default: Console.WriteLine("Opção inválida..."); break;
                }

            } while (v);

        }

        public void addProduto()
        {
            Console.Write(" - Adicionar Produto | Código: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            int q = int.Parse(Console.ReadLine());

            foreach (Produto p in produtos)
            {

                if (p.getCodigo() == c && p.getQntd() >= q)
                {

                    p.setQntd(q);
                    carrinho.add(p);
                    adc = "| Adicionado com sucesso!";

                }
                else { adc = "| Item não adicionado"; }

            }

        }

        public void listarProdutos()
        {

            bool v = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Varejista Uninassau\nAdministração - Lista de Produtos");
                List<Produto> produtos = new List<Produto>();
                dadosCarrinho();
                produtos = produtoDAO.obterTodosProdutos(); Console.WriteLine("Código | Qntd.  | Preço | Produto");
                foreach (Produto i in produtos)
                {

                    Console.Write($"{i.getCodigo()}      |  {i.getQntd()}    |   R${Math.Round(i.getPreco(), 2)}     |  {i.getNome()} \n");

                }

                Console.WriteLine("1.Adicionar Produto ao Carrinho || 2.Ver Carrinho || 3.Voltar ");
                switch (Console.ReadKey().KeyChar)
                {

                    case '1': addProduto(); v = true; break;
                    case '2': exibirCarrinho();/* v = false*/; break;
                    case '3': v = false; break;

                    default: Console.WriteLine("Opção inválida..."); break;
                }

            } while (v);

        }

        public void exibirCarrinho()
        {

            Console.Clear();
            Console.WriteLine("Carrinho\n");
            Console.Write("Produtos Selecionados\nCódigo | Qntd. | Descrição | Preço\n");

            foreach (Produto p in carrinho.getProdutos())
            {

                Console.WriteLine($"{p.getCodigo()}      | {p.getQntd()}   | {p.getNome()} | R${Math.Round(p.getPreco(), 2)}");
            }

            dadosCarrinho();

            Console.WriteLine("1.Finalizar compra || 2.Esvaziar Carrinho || 3.Voltar");

            switch (Console.ReadKey().KeyChar)
            {

                case '1': carrinho.finalizarCompras(); carrinho = new Carrinho(); break;
                case '2': carrinho = new Carrinho(); break;
                case '3': break;
            }
        }

        public void dadosCarrinho()
        {

            Console.Write($"Carrinho - Produtos: {carrinho.qntdProdutos()} Total: R${Math.Round(carrinho.totalProdutos(), 2)} {adc}\n\n");

        }


    }

}