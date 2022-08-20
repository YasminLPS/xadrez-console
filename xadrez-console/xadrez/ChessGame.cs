using System;
using tabuleiro;


namespace xadrez
{
    class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Color jogadorAtual { get; private set; }
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

        public void realizaJogada(Position origem, Position destino) 
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador() 
        {
            if (jogadorAtual == Color.Branca) 
            {
                jogadorAtual = Color.Preta;

            }
            else 
            {
                jogadorAtual = Color.Branca;
            }
        }

        public void validarPosicaoDeOrigem(Position pos) 
        {
            if (tab.peca(pos) == null) 
            {
                throw new TabuleiroExecption("Nao existe peca na posicao de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).color) 
            {
                throw new TabuleiroExecption("A peça de origem escolhida nao e sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) 
            {
                throw new TabuleiroExecption("Nao ha movimentos possiveis para a peca de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Position origem, Position destino) 
        {
            if (!tab.peca(origem).podeMoverPara(destino)) 
            {
                throw new TabuleiroExecption("Posicao de destino invalida!");
            }
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
