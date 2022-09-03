using Gomoku.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Game _Game;
        private BoardSetting _BoardSetting;
        private PieceSetting _PieceSetting;
        public Form(IOptionsSnapshot<GameSettings> settings)
        {
            InitializeComponent();
            _BoardSetting = settings.Value.Board;
            _PieceSetting = settings.Value.Piece;
            _Game = new Game(_BoardSetting.Xcount, _BoardSetting.Ycount, PieceColor.White);
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            CustomerPictureBox pictureBox;
            Piece newPiece = _Game.AddPiece(e.X.ConvertToArrayIndex(), e.Y.ConvertToArrayIndex());
            if (newPiece.Color == PieceColor.White)
            {
                pictureBox = new CustomerPictureBox(Image.FromFile(@"white.png"),_PieceSetting);
            }
            else
            {
                pictureBox = new CustomerPictureBox(Image.FromFile(@"black.png"), _PieceSetting);
            }
            pictureBox.Location = new Point(newPiece.xIndex.ConvertToLocation(),newPiece.yIndex.ConvertToLocation());
            this.Controls.Add(pictureBox);

            var result = _Game.CheckResult(newPiece);
            if (result == true)
            {
                DialogResult dialog = MessageBox.Show($"{newPiece.Color.ToString()} Win !","­«·s¹Cª±",MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    _Game.ResetGame();
                    this.Controls.Clear();
                }
            }

        }
    }
}