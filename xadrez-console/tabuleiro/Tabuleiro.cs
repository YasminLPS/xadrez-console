
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Piece[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Piece[linhas, colunas];
        }

        public Piece peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Piece peca(Position po)
        {
            return pecas[po.linha, po.coluna];
        }

        public bool existePeca(Position pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Piece p, Position po)
        {
            if (existePeca(po)) 
            {
                throw new TabuleiroExecption("Ja existe uma peca nessa posicao!");
            }
            pecas[po.linha, po.coluna] = p;
            p.position = po;
        }

        public bool posicaoValida(Position pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Position pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroExecption("Posicao invalida!");
            }
        }
    }
}
