using System;
using System.Collections.Generic;

namespace Supermercado
{
    public class Administracao
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        List<Produto> produtos = new List<Produto>();
        static int i = 1;

        public void login()
        {
            Adm adm = new Adm();
            bool v = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Supermercado\nLogin Administrador");
                Console.WriteLine("Insira 0 nas informações para voltar");
                Console.Write("Nome: ");
                adm.setNome(Console.ReadLine());
                Console.Write("Senha: ");
                adm.setSenha(Console.ReadLine());

                AdmDAO admDAO = new AdmDAO();

                if (adm.getNome().Equals("0") && adm.getSenha().Equals("0"))
                {

                    v = false; break;
                }
                else
                {

                    if (admDAO.CheckinADM(adm))
                    {

                        v = MenuAdm();
                    }
                    else
                    {
                        Console.WriteLine("Usuário ou senha não cadastrados!\nPressione Enter para tentar novamente...");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            v = true;
                    }

                }

            } while (v);

        }


        public bool MenuAdm()
        {
            produtos = produtoDAO.obterTodosProdutos();

            bool v = true;
            do
            {
                
                Console.Clear();
                Console.WriteLine("Varejista Uninassau\nMenu Administração");
                Console.Write("1.Cadastrar Produto\n2.Atualizar Produto\n3.Remover Produto\n4.Listar Produtos\n5.Logoff\n");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1': cadastrarProduto(); break;
                    case '2': atualizarProduto(); break;
                    case '3': removerProduto(); break;
                    case '4': listarProdutos(); break;

                    case '5': v = false; break;

                    default: Console.WriteLine("Opção Inválida"); break;

                }


            } while (v);

            return v;

        }

        public void cadastrarProduto()
        {
            Produto produto = new Produto();

            Console.Clear();
            Console.WriteLine("Varejista Uninassau\nAdministração - Cadastro de Produto");
            Console.Write("Nome: ");
            produto.setNome(Console.ReadLine());
            Console.Write("Preço: R$");
            produto.setPreco(double.Parse(Console.ReadLine()));
            Console.Write("Setor: ");
            produto.setSetor(Console.ReadLine());
            Console.Write("Quantidade: ");
            produto.setQntd(int.Parse(Console.ReadLine()));
            produto.setCodigo(i++);

            produtoDAO.cadastrar(produto);

        }

        public void atualizarProduto()
        {


            Console.Clear();
            Console.WriteLine("Varejista Uninassau\nAdministração - Atualizar Produto");

            Console.WriteLine("Código | Qntd.  | Preço | Produto");
            foreach (Produto i in produtos)
            {

                Console.Write($"{i.getCodigo()}      |  {i.getQntd()}    |   R${i.getPreco()}     |  {i.getNome()} \n");

            }

            Console.Write("Insira o código: ");
            int codigo = int.Parse(Console.ReadLine());

            if (codigo != 0)
            {

                Produto produto = produtoDAO.obterProduto(codigo);

                Console.Write($"{produto.getNome()} | R${produto.getPreco()} | Quantidade: {produto.getQntd()}\n");

                string[] atributos = { "Nome", "Quantidade", "Preço", "Setor" };
                string[] p = new string[4];
                for (int i = 0; i < 4; i++)
                {

                    Console.Write($"{atributos[i]}: ");
                    if (i == 2) { Console.Write("R$"); }
                    p[i] = Console.ReadLine();
                }

                produto.setNome(p[0]);
                produto.setQntd(int.Parse(p[1]));
                produto.setPreco(double.Parse(p[2]));
                produto.setSetor(p[3]);

                produtoDAO.atualizar(produto);

            }

        }

        public void listarProdutos()
        {
            Console.Clear();
            Console.WriteLine("Varejista Uninassau\nAdministração - Lista de Produtos");
            Console.WriteLine("Código | Qntd.  | Preço | Produto");
            foreach (Produto i in produtos)
            {

                Console.Write($"{i.getCodigo()}      |  {i.getQntd()}    |   R${i.getPreco()}     |  {i.getNome()} \n");

            }

            Console.WriteLine("Pressione Enter para voltar...");
            if (Console.ReadKey().Key == ConsoleKey.Enter) { };

        }

        public void removerProduto()
        {

            Console.Clear();
            Console.WriteLine("Varejista Uninassau\nAdministração - Remover Produto");

            Console.WriteLine("Código | Qntd.  | Preço | Produto");
            foreach (Produto i in produtos)
            {

                Console.Write($"{i.getCodigo()}      |  {i.getQntd()}    |   R${i.getPreco()}     |  {i.getNome()} \n");

            }

            Console.Write("Insira o código: ");
            int codigo = int.Parse(Console.ReadLine());

            produtoDAO.remover(codigo);

        }

    }
}
