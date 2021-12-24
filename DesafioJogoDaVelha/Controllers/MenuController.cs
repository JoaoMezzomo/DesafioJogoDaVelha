using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioJogoDaVelha.Models;

namespace DesafioJogoDaVelha.Controllers
{
    internal class MenuController
    {
        public void MostrarMenu() 
        {
            Console.Clear();

            JogoController.JogoAtual.Menus = new List<Menu>();
            JogoController.JogoAtual.Menus.Add(new Menu() { Valor = 1, Descricao = "Novo Jogo" });
            JogoController.JogoAtual.Menus.Add(new Menu() { Valor = 2, Descricao = "Sair" });

            string menuTexto = @"
  ===============================
 |--------:Jogo da Velha:--------|
  ===============================
    Selecione a Opção Desejada

";

            foreach (Menu menu in JogoController.JogoAtual.Menus)
            {
                menuTexto += string.Format(" {0}) {1}" + Environment.NewLine, menu.Valor, menu.Descricao);
            }

            Console.WriteLine(menuTexto);
        }

        public bool ValidarMenuSelecionado(int valor) 
        {
            if (JogoController.JogoAtual.Menus.Where(x => x.Valor == valor).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SelecionarMenu(int valor) 
        {
            switch (valor)
            {
                case (int)EnumMenu.NovoJogo:

                    JogoController.NovoJogo();

                    break;
                case (int)EnumMenu.Sair:

                    JogoController.Sair();

                    break;
                default:
                    break;
            }
        }

    }
}
