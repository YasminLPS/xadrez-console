
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

    }
}
