using System;
using System.Collections.Generic;

namespace Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            Administracao a = new Administracao();
            Mercado m = new Mercado();
            Carrinho carrnho = new Carrinho();
            bool v = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Varejista Uninassau");
                Console.WriteLine("1.Admnistração\n2.Fazer compras");

                switch (Console.ReadKey().KeyChar)
                {

                    case '1': a.login(); v = true; break;
                    case '2': m.Corredores(); break;

                    default:
                        Console.WriteLine(" - Opção inválida pressione Enter para tentar novamente...");
                        if (Console.ReadKey().Key == ConsoleKey.Enter) { v = true; }; break;
                }


            } while (v);

        }
    }
}
