using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public class CustomerPictureBox : PictureBox
    {
        public CustomerPictureBox(Image image, PieceSetting setting)
        {
            this.Image = image;
            this.Size = new Size(setting.Size, setting.Size);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }
    }
}
