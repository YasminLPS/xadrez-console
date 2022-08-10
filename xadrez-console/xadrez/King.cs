using System;
using tabuleiro;

namespace xadrez
{
    class King : Piece
    {
        public King(Tabuleiro tab, Color cor) 
            :base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
