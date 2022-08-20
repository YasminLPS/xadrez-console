
namespace tabuleiro
{
    class Piece
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
    }
}
