using tabuleiro;
namespace xadrez
{
    class Peao : Piece
    {
        private ChessGame partida;

        public Peao(Tabuleiro tab, Color cor, ChessGame partida)
          : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Position pos)
        {
            Piece p = tab.peca(pos);
            return p != null && p.color != color;
        }

        private bool livre(Position pos)
        {
            return tab.peca(pos) == null;
        }

        private bool podeMover(Position pos)
        {
            Piece p = tab.peca(pos);
            return p == null || p.color != color;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            if (color == Color.Branca)
            {
                pos.definirValores(position.linha - 1, position.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(position.linha - 2, position.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(position.linha - 1, position.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(position.linha - 1, position.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#jogadaespecial en passant
                if (position.linha == 3)
                {
                    Position esquerda = new Position(position.linha, position.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha -1, esquerda.coluna] = true;
                    }


                    Position direita = new Position(position.linha, position.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.definirValores(position.linha + 1, position.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(position.linha + 2, position.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(position.linha + 1, position.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(position.linha + 1, position.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#jogadaespecial en passant
                if (position.linha == 4)
                {
                    Position esquerda = new Position(position.linha, position.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha +1, esquerda.coluna] = true;
                    }


                    Position direita = new Position(position.linha, position.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha +1, direita.coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
