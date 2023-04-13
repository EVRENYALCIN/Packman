using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packman.Objects
{
    public class Coin:PictureBox
    {
        public Coin(int xkoord, int ykoord)
        {
            this.Image = Properties.Resources.coin;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Location = new Point(xkoord, ykoord);
            this.Name = "coin";
            this.Size = new Size(20, 20);
        }
    }
}
