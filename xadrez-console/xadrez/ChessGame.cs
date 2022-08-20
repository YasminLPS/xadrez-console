using System;
using tabuleiro;


namespace xadrez
{
    class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Color jogadorAtual;
        public bool terminada { get; private set; }

        public ChessGame()
        {
            tab = new Tabuleiro(8,8);
            turno = 1;
            jogadorAtual = Color.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Position origem, Position destino) 
        {
            Piece p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Piece pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas() 
        {
            tab.colocarPeca(new Tower(tab, Color.Branca), new PosicaoXadrez('c', 1).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Branca), new PosicaoXadrez('c', 2).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Branca), new PosicaoXadrez('d', 2).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Branca), new PosicaoXadrez('e', 2).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Branca), new PosicaoXadrez('e', 1).toPosition());
            tab.colocarPeca(new King(tab, Color.Branca), new PosicaoXadrez('d', 1).toPosition());

            tab.colocarPeca(new Tower(tab, Color.Preta), new PosicaoXadrez('c', 7).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Preta), new PosicaoXadrez('c', 8).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Preta), new PosicaoXadrez('d', 7).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Preta), new PosicaoXadrez('e', 7).toPosition());
            tab.colocarPeca(new Tower(tab, Color.Preta), new PosicaoXadrez('e', 8).toPosition());
            tab.colocarPeca(new King(tab, Color.Preta), new PosicaoXadrez('d', 8).toPosition());

        }
    }
}
