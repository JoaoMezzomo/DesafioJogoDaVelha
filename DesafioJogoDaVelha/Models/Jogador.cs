using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioJogoDaVelha.Models
{
    internal class Jogador
    {
        public int IDJogador { get; set; }
        public string Nome { get; set; }
        public char Simbolo { get; set; }
        public int Vitorias { get; set; }
    }
}
