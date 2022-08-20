using tabuleiro;

namespace xadrez
{
    class Dama : Piece
    {
        public Dama(Tabuleiro tab, Color cor)
          : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "D";
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

            // acima
            pos.definirValores(position.linha - 1, position.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            // abaixo
            pos.definirValores(position.linha + 1, position.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            // direita
            pos.definirValores(position.linha, position.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            // esquerda
            pos.definirValores(position.linha, position.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }
            // NOROESTE
            pos.definirValores(position.linha - 1, position.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }

            // NORDESTE
            pos.definirValores(position.linha - 1, position.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }

            // SUDESTE
            pos.definirValores(position.linha + 1, position.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }

            // SUDOESTE
            pos.definirValores(position.linha + 1, position.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).color != color)
                {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}
