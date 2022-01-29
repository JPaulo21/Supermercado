using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{ 
    class AdmDAO
    {
        
        public bool CheckinADM(Adm a)
        {
            bool v = false;

            StreamReader sr = new StreamReader("C:\\Users\\JoãoPaulo\\Documents\\Sistema da Informação\\2021_2\\Lógica de Programação Algoritmica\\SuperMercado\\Supermercado\\administradores.txt");

            string dados = sr.ReadLine();
            string[] adm = dados.Split("|");

            while(adm != null)
            {

                if (adm[0] == a.getNome() && adm[1] == a.getSenha()) { v = true; break; }

                dados = sr.ReadLine();
                if (dados != null)
                {
                    adm = dados.Split("|");
                } else { break; }
                
            }

            return v;

        }


    }

}
