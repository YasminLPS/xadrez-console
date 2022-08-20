using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame partida = new ChessGame();

                while (!partida.terminada) 
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Digite a posição de origem: ");
                    Position origem = Tela.lerPosicaoXadrez().toPosition();
                    Console.Write("Digite a posição de destino: ");
                    Position destino = Tela.lerPosicaoXadrez().toPosition();

                    partida.executaMovimento(origem, destino);
                }
            }
            catch (TabuleiroExecption e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
