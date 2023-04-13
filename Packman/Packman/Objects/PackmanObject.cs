using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
namespace Packman.Objects
{
    public class PackmanObject : PictureBox
    {
        private Form foundForm { get; }
        public bool rightLeft { get; set; } = true;
        public bool upDown { get; set; }
        public static Timer packmanTimerLeft { get; set; }
        public static Timer packmanTimerRight { get; set; }
        public static Timer packmanTimerUp { get; set; }
        public static Timer packmanTimerDown { get; set; }
        public int step { get; set; } = 15;
        public static int point = 0;


        public PackmanObject(Form FromToBeTransferred)
        {
            foundForm = FromToBeTransferred;
            packmanTimerLeft = new Timer();
            packmanTimerRight = new Timer();
            packmanTimerUp = new Timer();
            packmanTimerDown = new Timer();
            SetupTimerLeft(packmanTimerLeft);
            SetupTimerRight(packmanTimerRight);
            SetupTimerUp(packmanTimerUp);
            SetupTimerDown(packmanTimerDown);
            this.Image = Properties.Resources.XOsf;
            this.Location = new Point(300, 260);
            this.Name = "packman";
            this.Size = new Size(40, 40);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            foundForm.Controls.Add(this);
        }

        private void SetupTimerLeft(Timer timer)
        {
            timer.Interval = 100;
            timer.Enabled = false;
            timer.Tick += Timer_Tick_Left;
        }
        private void SetupTimerRight(Timer timer)
        {
            timer.Interval = 100;
            timer.Enabled = false;
            timer.Tick += Timer_Tick_Right;
        }
        private void SetupTimerUp(Timer timer)
        {
            timer.Interval = 100;
            timer.Enabled = false;
            timer.Tick += Timer_Tick_Up;
        }
        private void SetupTimerDown(Timer timer)
        {
            timer.Interval = 100;
            timer.Enabled = false;
            timer.Tick += Timer_Tick_Down;
        }

        public static bool ghostRemover=false;
        private void Timer_Tick_Left(object sender, EventArgs e)
        {
            this.Left -= step;

            foreach (Control c in foundForm.Controls)
            {
                if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    this.Left += step;
                    packmanTimerLeft.Stop();
                    break;
                }
                if (c is PictureBox && c.Name == "coin" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    foundForm.Controls.Remove(c);
                    PackmanMap.coins.Remove((Coin)c);
                    point += step;
                }
                if (c is PictureBox && c.Name == "coinSpecial" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    //breakpoint
                    ghostRemover = true;
                    foundForm.Controls.Remove(c);
                    PackmanMap.coinSpecials.Remove((CoinSpecial)c);
                    foundForm.BackColor= Color.GreenYellow;
                    break;
                }
                if (PackmanMap.coins.Count <= 0 && PackmanMap.coinSpecials.Count <= 0)
                {
                    StopTimers();
                    MessageBox.Show($"Congratulation\nPoint= {PackmanObject.point}");
                }
            }
        }
        private void Timer_Tick_Right(object sender, EventArgs e)
        {
            this.Left += step;
            foreach (Control c in foundForm.Controls)
            {
                if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    this.Left -= step;
                    packmanTimerRight.Stop();
                    break;
                }
                if (c is PictureBox && c.Name == "coin" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    foundForm.Controls.Remove(c);
                    PackmanMap.coins.Remove((Coin)c);
                    point += step;
                }
                if (c is PictureBox && c.Name == "coinSpecial" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    //breakpoint
                    ghostRemover = true;
                    foundForm.Controls.Remove(c);
                    PackmanMap.coinSpecials.Remove((CoinSpecial)c);
                    foundForm.BackColor = Color.GreenYellow;
                    break;
                }
                if (PackmanMap.coins.Count <= 0 && PackmanMap.coinSpecials.Count <= 0)
                {
                    StopTimers();
                    MessageBox.Show($"Congratulation\nPoint= {PackmanObject.point}");
                }
            }
        }
        private void Timer_Tick_Up(object sender, EventArgs e)
        {
            this.Top -= step;
            foreach (Control c in foundForm.Controls)
            {
                if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    this.Top += step;
                    packmanTimerUp.Stop();
                    break;
                }
                if (c is PictureBox && c.Name == "coin" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    foundForm.Controls.Remove(c);
                    PackmanMap.coins.Remove((Coin)c);
                    point += step;
                }
                if (c is PictureBox && c.Name == "coinSpecial" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    //breakpoint
                    ghostRemover = true;
                    foundForm.Controls.Remove(c);
                    PackmanMap.coinSpecials.Remove((CoinSpecial)c);
                    foundForm.BackColor = Color.GreenYellow;
                    break;
                }
                if (PackmanMap.coins.Count <= 0 && PackmanMap.coinSpecials.Count <= 0)
                {
                    StopTimers();
                    MessageBox.Show($"Congratulation\nPoint= {PackmanObject.point}");
                }
            }
        }
        private void Timer_Tick_Down(object sender, EventArgs e)
        {
            this.Top += step;
            foreach (Control c in foundForm.Controls)
            {
                if (c is PictureBox && c.Name == "wall" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    this.Top -= step;
                    packmanTimerDown.Stop();
                    break;
                }
                if (c is PictureBox && c.Name == "coin" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    foundForm.Controls.Remove(c);
                    PackmanMap.coins.Remove((Coin)c);
                    point += step;
                }
                if (c is PictureBox && c.Name == "coinSpecial" && this.Bounds.IntersectsWith(c.Bounds))
                {
                    //breakpoint
                    ghostRemover = true;
                    foundForm.Controls.Remove(c);
                    PackmanMap.coinSpecials.Remove((CoinSpecial)c);
                    foundForm.BackColor = Color.GreenYellow;
                    break;
                }
                if (PackmanMap.coins.Count <= 0 && PackmanMap.coinSpecials.Count <= 0)
                {
                    StopTimers();
                    MessageBox.Show($"Congratulation\nPoint= {PackmanObject.point}");
                }
            }
        }

        private static void StopTimers()
        {
            GhostObject.GhostTimer.Stop();
            packmanTimerDown.Stop();
            packmanTimerUp.Stop();
            packmanTimerLeft.Stop();
            packmanTimerRight.Stop();
        }
        bool right = true, left = false, down = false, up = false;

        public void LocationSetup(System.Windows.Forms.Keys e)
        {
            switch (e)
            {
                case Keys.Up:
                    if (down)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        this.Enabled=true;
                        left = false;
                        right = false;
                        down = false;
                        up = true;
                    }
                    if (right)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        this.Enabled=true;
                        left = false;
                        right = false;
                        down = false;
                        up = true;
                    }
                    if (left)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Enabled=true;
                        left = false;
                        right = false;
                        down = false;
                        up = true;
                    }
                    packmanTimerUp.Start();
                    packmanTimerDown.Stop();
                    packmanTimerRight.Stop();
                    packmanTimerLeft.Stop();
                    break;
                case Keys.Down:
                    if (up)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        this.Enabled=true;
                        left = false;
                        right = false;
                        up = false;
                        down = true;
                    }
                    if (right)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Enabled=true;
                        left = false;
                        right = false;
                        up = false;
                        down = true;
                    }
                    if (left)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        this.Enabled=true;
                        left = false;
                        right = false;
                        up = false;
                        down = true;
                    }
                    packmanTimerDown.Start();
                    packmanTimerRight.Stop();
                    packmanTimerLeft.Stop();
                    packmanTimerUp.Stop();
                    break;
                case Keys.Left:
                    if (right)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        this.Enabled=true;
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                    }
                    if (down)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Enabled=true;
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                    }
                    if (up)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        this.Enabled=true;
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                    }
                    packmanTimerLeft.Start();
                    packmanTimerDown.Stop();
                    packmanTimerRight.Stop();
                    packmanTimerUp.Stop();
                    break;
                case Keys.Right:
                    if (left)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        this.Enabled=true;
                        left = false;
                        right = true;
                        up = false;
                        down = false;
                    }
                    if (down)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        this.Enabled=true;
                        left = false;
                        right = true;
                        up = false;
                        down = false;
                    }
                    if (up)
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.Enabled=true;
                        left = false;
                        right = true;
                        up = false;
                        down = false;
                    }
                    packmanTimerRight.Start();
                    packmanTimerUp.Stop();
                    packmanTimerLeft.Stop();
                    packmanTimerDown.Stop();
                    break;
                default:
                    break;
            }
        }
    }
}
