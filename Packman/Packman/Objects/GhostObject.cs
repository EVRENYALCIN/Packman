using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Packman.Objects
{
    public class GhostObject : PictureBox
    {
        private Form FoundForm;
        public static Timer GhostTimer { get; set; }

        public int Step { get; set; }
        public GhostObject(Form FromToBeTransferred, int xkoord, int ykoord, int ghostSpeed)
        {
            FoundForm = FromToBeTransferred;
            GhostTimer = new Timer();
            SetupTimer(GhostTimer);
            Step = ghostSpeed;
            this.Image = Properties.Resources.pac_man_ghost;
            this.Location = new Point(xkoord, ykoord);
            this.Name = "ghost";
            this.Size = new Size(50, 50);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            FoundForm.Controls.Add(this);
        }

        private void SetupTimer(Timer timer)
        {
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }


       
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.IntersectsWith(PackmanMap.packmanObject.Bounds) && !PackmanObject.ghostRemover)
            {
                //break point
                Business.Business.StopTimers();
                MessageBox.Show($"GAME OVER\nPoint= {PackmanObject.point}");
                PackmanObject.ghostRemover=false;
            }

            Point packmanLocation = PackmanMap.packmanObject.Location;
            if (!PackmanObject.ghostRemover)
            {
                if (packmanLocation.X > this.Location.X)
                {
                    this.Left += Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Left -= Step;
                            break;
                        }
                    }
                }
                if (packmanLocation.X < this.Location.X)
                {
                    this.Left -= Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Left += Step;
                            break;
                        }
                    }
                }
                if (packmanLocation.Y > this.Location.Y)
                {
                    this.Top += Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Top -= Step;
                            break;
                        }
                    }
                }
                if (packmanLocation.Y < this.Location.Y)
                {
                    this.Top -= Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Top += Step;
                            break;
                        }
                    }
                }

            }
            if (PackmanObject.ghostRemover)
            {
                if (packmanLocation.X > this.Location.X)
                {
                    this.Left -= Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Left += Step;
                            break;
                        }
                    }
                }
                if (packmanLocation.X < this.Location.X)
                {
                    this.Left += Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Left -= Step;
                            break;
                        }
                    }
                }
                if (packmanLocation.Y > this.Location.Y)
                {
                    this.Top -= Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Top += Step;
                            break;
                        }
                    }
                }
                if (packmanLocation.Y < this.Location.Y)
                {
                    this.Top += Step;
                    foreach (Control c in FoundForm.Controls)
                    {
                        if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                        {
                            this.Top -= Step;
                            break;
                        }
                    }
                }
                

                if (this.Bounds.IntersectsWith(PackmanMap.packmanObject.Bounds) && PackmanObject.ghostRemover)
                {
                    this.Dispose();
                    FoundForm.BackColor = Color.White;
                    GhostTimer.Stop();
                    PackmanObject.ghostRemover = false;

                }



            }
        }
    }
}
