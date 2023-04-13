using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packman.Objects
{
    public class Wall:PictureBox
    {
        public Wall(int xkoord, int ykoord, int xsize, int ysize)
        {
            this.Location = new Point(xkoord, ykoord);
            this.Name = "wall";
            this.BackColor = Color.Blue;
            this.Size = new Size(xsize, ysize);
        }
    }
}
