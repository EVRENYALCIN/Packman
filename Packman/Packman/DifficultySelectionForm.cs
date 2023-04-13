using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packman
{
    public partial class DifficultySelectionForm : Form
    {
        public DifficultySelectionForm()
        {
            InitializeComponent();
        }
        int speed = 5;
        int ghostPopulation = 1;
        private void btnStart_Click(object sender, EventArgs e)
        {
            PackmanMap packmanMap= new PackmanMap(speed, ghostPopulation);
            packmanMap.ShowDialog();
        }

        private void rbEasy_CheckedChanged(object sender, EventArgs e)
        {
            speed = 5;
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            speed = 10;
        }

        private void rbExpert_CheckedChanged(object sender, EventArgs e)
        {
            speed = 15;
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            ghostPopulation = 1;
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            ghostPopulation = 2;
        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            ghostPopulation = 3;
        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            ghostPopulation = 4;
        }

    }
}
