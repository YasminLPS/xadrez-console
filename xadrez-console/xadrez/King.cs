
using tabuleiro;

namespace xadrez
{
    class King : Piece
    {
        private ChessGame partida;

        public King(Tabuleiro tab, Color cor, ChessGame partida)
            : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Position pos)
        {
            Piece p = tab.peca(pos);
            return p == null || p.color != color;
        }

        private bool testeTorreParaRoque(Position pos)
        {
            Piece p = tab.peca(pos);
            return p != null && p is Tower && p.color == color && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            // acima
            pos.definirValores(position.linha - 1, position.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // ne
            pos.definirValores(position.linha - 1, position.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // direita
            pos.definirValores(position.linha, position.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // se
            pos.definirValores(position.linha + 1, position.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // abaixo
            pos.definirValores(position.linha + 1, position.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // so
            pos.definirValores(position.linha + 1, position.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // esquerda
            pos.definirValores(position.linha, position.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // no
            pos.definirValores(position.linha - 1, position.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //#jogadaespecial roque
            if (qteMovimentos == 0 && !partida.xeque)
            {
                //roque pequeno
                Position posT1 = new Position(position.linha, position.coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Position p1 = new Position(position.linha, position.coluna + 1);
                    Position p2 = new Position(position.linha, position.coluna + 2);
                    if (tab.peca(p1)==null && tab.peca(p2) == null) 
                    {
                        mat[position.linha, position.coluna + 2] = true;
                    }
                }

                //roque grande
                Position posT2 = new Position(position.linha, position.coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Position p1 = new Position(position.linha, position.coluna - 1);
                    Position p2 = new Position(position.linha, position.coluna - 2);
                    Position p3 = new Position(position.linha, position.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[position.linha, position.coluna - 2] = true;
                    }
                }

            }


            return mat;
        }
    }
}
