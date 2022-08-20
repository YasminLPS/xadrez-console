
namespace tabuleiro
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Piece(Tabuleiro tab, Color color) 
        {
            position = null;
            this.tab = tab;
            this.color = color;
            qteMovimentos = 0;
        }

        public void incrementarQteMovimentos() 
        {
           qteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool existeMovimentosPossiveis() 
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i <tab.linhas; i ++) 
            {
                for (int j = 0; j < tab.colunas; j++) 
                {
                    if (mat[i,j]) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Position pos) 
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();

    }
}
