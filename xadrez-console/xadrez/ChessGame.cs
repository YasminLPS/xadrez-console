﻿using System.Collections.Generic;
using tabuleiro;


namespace xadrez
{
    class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Color jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Piece> pecas;
        private HashSet<Piece> capturadas;
        public bool xeque { get; private set; }

        public ChessGame()
        {
            tab = new Tabuleiro(8,8);
            turno = 1;
            jogadorAtual = Color.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Piece>();
            capturadas = new HashSet<Piece>();
            colocarPecas();
        }

        public Piece executaMovimento(Position origem, Position destino) 
        {
            Piece p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Piece pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null) 
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Position origem, Position destino, Piece pecaCapturada ) 
        {
            Piece p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null) 
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Position origem, Position destino)
        {
            Piece pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExecption("Voce nao pode se colocar em xeque!");
            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else 
            {
                xeque = false;
            }

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

        public HashSet<Piece> pecasCapturadas(Color cor) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturadas) 
            {
                if (x.color == cor) 
                {
                   aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> pecasEmJogo(Color cor) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pecas)
            {
                if (x.color == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Color adversaria(Color cor) 
        {
            if (cor == Color.Branca) 
            {
                return Color.Preta;
            }
            else 
            {
                return Color.Branca;
            }
        }

        private Piece rei(Color cor) 
        {
            foreach (Piece x in pecasEmJogo(cor)) 
            {
                if (x is King) 
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Color cor) 
        {
            Piece R = rei(cor);
            if (R == null) 
            {
                throw new TabuleiroExecption("Nao ha rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Piece x in pecasEmJogo(adversaria(cor))) 
            {
                bool[,] matt = x.movimentosPossiveis();
                if (matt[R.position.linha, R.position.coluna]) 
                {
                    return true;
                }
            }
            return false;
        }

        public void colocarNovaPeca(char coluna, int linha, Piece peca) 
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosition());
            pecas.Add(peca);
        }

        private void colocarPecas() 
        {
            colocarNovaPeca('c', 1, new Tower(tab, Color.Branca));
            colocarNovaPeca('c', 2, new Tower(tab, Color.Branca));
            colocarNovaPeca('d', 2, new Tower(tab, Color.Branca));
            colocarNovaPeca('e', 2, new Tower(tab, Color.Branca));
            colocarNovaPeca('e', 1, new Tower(tab, Color.Branca));
            colocarNovaPeca('d', 1, new King(tab, Color.Branca));

            colocarNovaPeca('c', 7, new Tower(tab, Color.Preta));
            colocarNovaPeca('c', 8, new Tower(tab, Color.Preta));
            colocarNovaPeca('d', 7, new Tower(tab, Color.Preta));
            colocarNovaPeca('e', 7, new Tower(tab, Color.Preta));
            colocarNovaPeca('e', 8, new Tower(tab, Color.Preta));
            colocarNovaPeca('d', 8, new King(tab, Color.Preta));
        }
    }
}
