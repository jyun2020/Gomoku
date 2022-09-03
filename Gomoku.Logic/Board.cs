namespace Gomoku.Logic
{
    public class Board
    {
        public int Xcount { get; set; }
        public int Ycount { get; set; }
        public List<Piece> Pieces { get; set; } = new List<Piece>();
        public Board(int xCount , int yCount)
        {
            Xcount = xCount;
            Ycount = yCount;
        }
    }
}