using System;
using tabuleiro;

namespace xadrez
{
    class Tower : Piece
    {
        public Tower(Tabuleiro tab, Color cor)
           : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
