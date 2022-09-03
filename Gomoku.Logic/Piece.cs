using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Logic
{
    public class Piece
    {
        public int xIndex { get; set; }
        public int yIndex { get; set; }
        public PieceColor Color { get; set; }

        public Piece(int xIndex, int yIndex, PieceColor color)
        {
            this.xIndex = xIndex;
            this.yIndex = yIndex;
            Color = color;
        }
    }
}
