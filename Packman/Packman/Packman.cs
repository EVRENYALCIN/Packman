using Packman.Business;
using Packman.Objects;
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
    public partial class PackmanMap : Form
    {
        public static PackmanObject packmanObject { get; set; }
        public GhostObject ghost1 { get; set; }
        public GhostObject ghost2 { get; set; }
        public GhostObject ghost3 { get; set; }
        public GhostObject ghost4 { get; set; }
        public List<Wall> walls { get; set; }
        public static List<Coin> coins { get; set; }
        public static List<CoinSpecial> coinSpecials { get; set; }
        public PackmanMap(int ghostSpeed, int ghostPopulation)
        {
            InitializeComponent();
            packmanObject = new PackmanObject(this);
            switch (ghostPopulation)
            {
                case 1:
                    ghost1 = new GhostObject(this, 1100, 10, ghostSpeed);
                    break;
                case 2:
                    ghost1 = new GhostObject(this, 1100, 10, ghostSpeed);
                    ghost2 = new GhostObject(this, 10, 10, ghostSpeed);
                    break;
                case 3:
                    ghost1 = new GhostObject(this, 1100, 10, ghostSpeed);
                    ghost2 = new GhostObject(this, 10, 10, ghostSpeed);
                    ghost3 = new GhostObject(this, 1100, 500, ghostSpeed);
                    break;
                case 4:
                    ghost1 = new GhostObject(this, 1100, 10, ghostSpeed);
                    ghost2 = new GhostObject(this, 10, 10, ghostSpeed);
                    ghost3 = new GhostObject(this, 1100, 500, ghostSpeed);
                    ghost4 = new GhostObject(this, 10, 500, ghostSpeed);
                    break;
                default:
                    break;
            }
            walls = Business.Business.BringWalls();
            foreach (Wall wall in walls)
                Controls.Add(wall);
            coins = Business.Business.BringCoins();
            foreach (Coin coin in coins)
                Controls.Add(coin);
            coinSpecials = Business.Business.BringCoinSpecials();
            foreach (CoinSpecial coinSpecial in coinSpecials)
                Controls.Add(coinSpecial);
        }

        private void PackmanMap_KeyDown(object sender, KeyEventArgs e)
        {
            packmanObject.LocationSetup(e.KeyCode);
        }

        private void PackmanMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
