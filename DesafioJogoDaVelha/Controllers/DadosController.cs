using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioJogoDaVelha.Controllers
{
    internal class DadosController
    {
        public int GetInt(string mensagem = null) 
        {
            int retorno = 0;

            if (!string.IsNullOrEmpty(mensagem))
            {
                Console.WriteLine(mensagem);
            }

            bool valorCerto = false;

            while (!valorCerto)
            {
                string valor = Console.ReadLine();

                if (int.TryParse(valor, out int teste))
                {
                    retorno = Convert.ToInt32(valor);
                    valorCerto = true;
                }
                else
                {
                    Console.WriteLine("Valor digitado incorreto. Por favor, digite um valor novamente.");
                }
            }

            return retorno;
        }

        public string GetString(string mensagem = null)
        {
            string retorno = "";

            if (!string.IsNullOrEmpty(mensagem))
            {
                Console.WriteLine(mensagem);
            }

            bool valorCerto = false;

            while (!valorCerto)
            {
                string valor = Console.ReadLine();

                if (!string.IsNullOrEmpty(valor))
                {
                    retorno = valor;
                    valorCerto = true;
                }
                else
                {
                    Console.WriteLine("Valor digitado incorreto. Por favor, digite um valor novamente.");
                }
            }

            return retorno;
        }
    }
}
