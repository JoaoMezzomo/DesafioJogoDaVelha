using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioJogoDaVelha.Models
{
    internal class Jogo
    {
        public char[,] Tabuleiro = new char[3, 3];
        public List<string> Posicoes { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Jogador> Jogadores { get; set; }
        public int Rodadas { get; set; }
        public int IDJogadorAtual { get; set; }
        public int IDJogadorVencedor { get; set; }
    }
}
