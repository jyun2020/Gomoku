using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Logic
{
    public class Game
    {
        public Board Board { get; set; }
        public PieceColor Color { get; set; }
        public Game(int xCount, int yCount, PieceColor firstColor)
        {
            Board = new Board(xCount,yCount);
            this.Color = firstColor;
        }
        public Piece AddPiece(int xIndex, int yIndex)
        {
            if (xIndex > Board.Xcount || yIndex > Board.Ycount)
                throw new ArgumentOutOfRangeException("超過棋盤大小");

            Piece piece = new Piece(xIndex,yIndex,Color);
            Board.Pieces.Add(piece);
            Color = Color == PieceColor.White ? PieceColor.Black : PieceColor.White;
            return piece;
        }
        public bool CheckResult(Piece lastPiece)
        {
            List<int> numbers = new();
            //判斷直線
            numbers = Board.Pieces.Where(w => w.xIndex == lastPiece.xIndex && w.Color == lastPiece.Color)
                .OrderBy(o => o.yIndex)
                .Select(s => s.yIndex).ToList();

            if(ContinuousNumber(numbers,lastPiece.yIndex) >= 5)
                return true;

            //判斷橫線
            numbers = Board.Pieces.Where(w => w.yIndex == lastPiece.yIndex && w.Color == lastPiece.Color)
                .OrderBy(o => o.xIndex)
                .Select(s => s.xIndex).ToList();

            if (ContinuousNumber(numbers, lastPiece.xIndex) >= 5)
                return true;

            //判斷右上左下斜線
            numbers = Board.Pieces.Where(w => w.yIndex + w.xIndex == lastPiece.yIndex + lastPiece.xIndex
                && w.Color == lastPiece.Color)
                .OrderBy(o => o.xIndex)
                .Select(s => s.xIndex).ToList();

            if (ContinuousNumber(numbers, lastPiece.xIndex) >= 5)
                return true;

            //判斷左上右下斜線
            numbers = Board.Pieces.Where(w => w.yIndex - w.xIndex == lastPiece.yIndex - lastPiece.xIndex
                && w.Color == lastPiece.Color)
                .OrderBy(o => o.xIndex)
                .Select(s => s.xIndex).ToList();

            if (ContinuousNumber(numbers, lastPiece.xIndex) >= 5)
                return true;

            return false;
        }
        private int ContinuousNumber(List<int> numbers, int startNumber)
        {
            int startIndex = numbers.IndexOf(startNumber);

            int leftContinuous = 0;
            int leftCount = 1;
            for (int i = startIndex-1 ; i >= 0; i--)
            {
                if (numbers[i] == startNumber - leftCount)
                    leftContinuous++;

                leftCount++;
            }

            int rightContinuous = 0;
            int rightCount = 1;
            for (int i = startIndex+1; i < numbers.Count; i++)
            {
                if (numbers[i] == startNumber + rightCount)
                    rightContinuous++;

                rightCount++;
            }

            return leftContinuous + rightContinuous + 1;
        }
        public void ResetGame()
        {
            Board.Pieces.Clear();
        }
    }
}
