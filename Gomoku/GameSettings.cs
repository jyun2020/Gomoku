using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public class GameSettings
    {
        public BoardSetting Board { get; set; }
        public PieceSetting Piece { get; set; }
    }
    public class BoardSetting
    { 
        public int Xcount { get; set; }
        public int Ycount { get; set; }
        public int ColumnWidth { get; set; }
    }
    public class PieceSetting
    { 
        public int Size { get; set; }
    }
}
