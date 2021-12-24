using System;
using DesafioJogoDaVelha.Models;
using DesafioJogoDaVelha.Controllers;

namespace DesafioJogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ligado = true;
            MenuController menuController = new MenuController();
            DadosController dadosController = new DadosController();

            while (ligado)
            {
                menuController.MostrarMenu();

                int menuSelecionado = dadosController.GetInt();

                if (!menuController.ValidarMenuSelecionado(menuSelecionado))
                {
                    continue;
                }

                menuController.SelecionarMenu(menuSelecionado);
            }
        }
    }
}
