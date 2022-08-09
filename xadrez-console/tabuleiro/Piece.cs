
namespace tabuleiro
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Piece(Position position, Tabuleiro tab, Color color) 
        {
            this.position = position;
            this.tab = tab;
            this.color = color;
            this.qteMovimentos = 0;
        }
    }
}
