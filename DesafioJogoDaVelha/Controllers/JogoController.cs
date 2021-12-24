using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioJogoDaVelha.Models;

namespace DesafioJogoDaVelha.Controllers
{
    internal class JogoController
    {
        public static Jogo JogoAtual = new Jogo();

        public static void NovoJogo(bool jogarNovamente = false) 
        {
            Console.Clear();

            DadosController dadosController = new DadosController();

            if (!jogarNovamente)
            {
                Jogador jogador1 = new Jogador();
                jogador1.IDJogador = 1;
                jogador1.Simbolo = 'X';
                jogador1.Vitorias = 0;
                jogador1.Nome = dadosController.GetString(" Digite o nome do Jogador 1");

                Console.WriteLine();

                Jogador jogador2 = new Jogador();
                jogador2.IDJogador = 2;
                jogador2.Simbolo = 'O';
                jogador2.Vitorias = 0;
                jogador2.Nome = dadosController.GetString(" Digite o nome do Jogador 2");

                JogoAtual.Jogadores = new List<Jogador>();
                JogoAtual.Jogadores.Add(jogador1);
                JogoAtual.Jogadores.Add(jogador2);

                JogoAtual.Rodadas = 0;
            }

            JogoAtual.IDJogadorVencedor = 0;
            JogoAtual.IDJogadorAtual = 1;

            JogoAtual.Tabuleiro[0, 0] = ' ';
            JogoAtual.Tabuleiro[0, 1] = ' ';
            JogoAtual.Tabuleiro[0, 2] = ' ';

            JogoAtual.Tabuleiro[1, 0] = ' ';
            JogoAtual.Tabuleiro[1, 1] = ' ';
            JogoAtual.Tabuleiro[1, 2] = ' ';

            JogoAtual.Tabuleiro[2, 0] = ' ';
            JogoAtual.Tabuleiro[2, 1] = ' ';
            JogoAtual.Tabuleiro[2, 2] = ' ';

            JogoAtual.Posicoes = new List<string>();

            JogoAtual.Posicoes.Add("A1");
            JogoAtual.Posicoes.Add("A2");
            JogoAtual.Posicoes.Add("A3");

            JogoAtual.Posicoes.Add("B1");
            JogoAtual.Posicoes.Add("B2");
            JogoAtual.Posicoes.Add("B3");

            JogoAtual.Posicoes.Add("C1");
            JogoAtual.Posicoes.Add("C2");
            JogoAtual.Posicoes.Add("C3");

            bool terminou = false;

            while (!terminou)
            {
                MostrarTabuleiro();

                string posicaoEscolhida = SolicitarJogada();

                terminou = ProcessarJogada(posicaoEscolhida);
            }

            Console.Clear();

            if (JogoAtual.IDJogadorVencedor != 0)
            {
                Jogador jogador = JogoAtual.Jogadores.Where(x => x.IDJogador == JogoAtual.IDJogadorVencedor).FirstOrDefault();

                Console.WriteLine(" {0} é o(a) vencedor(a)! Parabéns!", jogador.Nome);
            }
            else
            {
                Console.WriteLine(" Deu velha! Empatou!");
            }

            Console.WriteLine();

            bool valorCertoJogarNovamente = false;

            Console.WriteLine(" Desejam jogar novamente? [S = Sim | N = Não]");

            string resposta = "";

            while (!valorCertoJogarNovamente)
            {
                resposta = dadosController.GetString().ToUpper();

                if (resposta == "S" || resposta == "N")
                {
                    valorCertoJogarNovamente = true;
                }
                else
                {
                    Console.WriteLine(" Valor digitado incorreto. Por favor, digite um valor novamente.");
                }
            }

            if (resposta == "S")
            {
                NovoJogo(true);
            }
        }

        public static void Sair() 
        {
            Environment.Exit(1);
        }

        private static void MostrarTabuleiro() 
        {
            Console.Clear();

            string placar = string.Format(" === {0} - {1} X {2} - {3} ===", JogoAtual.Jogadores[0].Nome, JogoAtual.Jogadores[0].Vitorias, JogoAtual.Jogadores[1].Vitorias, JogoAtual.Jogadores[1].Nome);

            placar += Environment.NewLine + Environment.NewLine;

            string tabuleiro = "    1    2   3" + Environment.NewLine;

            int quantidade = 3;

            for (int i = 0; i < quantidade; i++)
            {
                if (i == 0)
                {
                    tabuleiro += " A";
                }
                else if (i == 1)
                {
                    tabuleiro += " B";
                }
                else if (i == 2)
                {
                    tabuleiro += " C";
                }

                for (int j = 0; j < quantidade; j++)
                {
                    tabuleiro += "  " + JogoAtual.Tabuleiro[i, j].ToString() + " ";

                    if (j == 0 || j == 1)
                    {
                        tabuleiro += "|"; 
                    }
                }

                tabuleiro += Environment.NewLine;

                if (i == 0 || i == 1)
                {
                    tabuleiro += "   ============" + Environment.NewLine;
                }
            }

            Console.WriteLine(placar + tabuleiro);
        }

        private static string SolicitarJogada() 
        {
            string posicaoEscolhida = "";

            DadosController dadosController = new DadosController();

            Jogador jogador = JogoAtual.Jogadores.Where(x => x.IDJogador == JogoAtual.IDJogadorAtual).FirstOrDefault();

            Console.WriteLine(" {0}, digite a posição desejada do tabuleiro.", jogador.Nome);

            Console.WriteLine();

            string posicoesDisponiveis = " Posições disponíveis: ";

            foreach (string posicao in JogoAtual.Posicoes)
            {
                posicoesDisponiveis += " " + posicao;
            }

            Console.WriteLine(posicoesDisponiveis);

            Console.WriteLine();

            bool valorCerto = false;

            while (!valorCerto)
            {
                posicaoEscolhida = dadosController.GetString().ToUpper();

                if (JogoAtual.Posicoes.Contains(posicaoEscolhida))
                {
                    valorCerto = true;
                }
                else
                {
                    Console.WriteLine(" Posição não disponível ou inválida. Por favor, digite novamente uma posição.");
                }
            }

            return posicaoEscolhida;
        }

        private static bool ProcessarJogada(string posicaoEscolhida) 
        {
            bool terminou = false;

            Jogador jogador = JogoAtual.Jogadores.Where(x => x.IDJogador == JogoAtual.IDJogadorAtual).FirstOrDefault();

            switch (posicaoEscolhida)
            {
                case "A1":
                    JogoAtual.Tabuleiro[0, 0] = jogador.Simbolo;
                    break;
                case "A2":
                    JogoAtual.Tabuleiro[0, 1] = jogador.Simbolo;
                    break;
                case "A3":
                    JogoAtual.Tabuleiro[0, 2] = jogador.Simbolo;
                    break;
                case "B1":
                    JogoAtual.Tabuleiro[1, 0] = jogador.Simbolo;
                    break;
                case "B2":
                    JogoAtual.Tabuleiro[1, 1] = jogador.Simbolo;
                    break;
                case "B3":
                    JogoAtual.Tabuleiro[1, 2] = jogador.Simbolo;
                    break;
                case "C1":
                    JogoAtual.Tabuleiro[2, 0] = jogador.Simbolo;
                    break;
                case "C2":
                    JogoAtual.Tabuleiro[2, 1] = jogador.Simbolo;
                    break;
                case "C3":
                    JogoAtual.Tabuleiro[2, 2] = jogador.Simbolo;
                    break;
                default:
                    break;
            }

            JogoAtual.Posicoes.Remove(posicaoEscolhida);

            if (JogoAtual.Tabuleiro[0, 0] == jogador.Simbolo
                && JogoAtual.Tabuleiro[0, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[0, 2] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[1, 0] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 2] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[2, 0] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 2] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[0, 0] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 0] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 0] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[0, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 1] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[0, 2] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 2] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 2] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[0, 0] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 2] == jogador.Simbolo)
            {
                terminou = true;
            }
            else if (JogoAtual.Tabuleiro[0, 2] == jogador.Simbolo
                && JogoAtual.Tabuleiro[1, 1] == jogador.Simbolo
                && JogoAtual.Tabuleiro[2, 0] == jogador.Simbolo)
            {
                terminou = true;
            }

            if (terminou)
            {
                JogoAtual.IDJogadorVencedor = jogador.IDJogador;
                JogoAtual.Jogadores.Where(x => x.IDJogador == jogador.IDJogador).FirstOrDefault().Vitorias++;
            }
            else if (JogoAtual.Posicoes.Count == 0)
            {
                terminou = true;
            }
            else
            {
                JogoAtual.IDJogadorAtual = JogoAtual.Jogadores.Where(x => x.IDJogador != jogador.IDJogador).FirstOrDefault().IDJogador;
            }

            JogoAtual.Rodadas++;

            return terminou;
        }
    }
}
