using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packman.Objects
{
    public class CoinSpecial:PictureBox
    {

        public CoinSpecial(int xkoord, int ykoord)
        {
            this.Image = Properties.Resources.coin;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Location = new Point(xkoord, ykoord);
            this.Name = "coinSpecial";
            this.Size = new Size(30, 30);
        }
    }
}
