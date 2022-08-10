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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Tower(tab, Color.Preta), new Position(0, 0));
                tab.colocarPeca(new Tower(tab, Color.Preta), new Position(1, 3));
                tab.colocarPeca(new King(tab, Color.Preta), new Position(2, 4));

                tab.colocarPeca(new Tower(tab, Color.Branca), new Position(3, 5));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroExecption e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
