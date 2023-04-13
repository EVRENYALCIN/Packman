using Packman.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packman.Business
{
    public class Business
    {
        public List<Wall> walls { get; set; }
        public List<Coin> coins { get; set; }
        public List<CoinSpecial> coinSpecials { get; set; }
        public static List<Wall> BringWalls()
        {
            var walls = new List<Wall>();
            Wall wall1 = new Wall(60, 60, 20, 200);
            Wall wall2 = new Wall(60, 240, 400, 20);
            Wall wall3 = new Wall(140, 60, 840, 20);
            Wall wall4 = new Wall(140, 140, 400, 20);
            Wall wall5 = new Wall(540, 140, 20, 360);//left middle
            Wall wall6 = new Wall(640, 140, 20, 280);
            Wall wall7 = new Wall(60, 320, 300, 180);//left big
            Wall wall8 = new Wall(740, 240, 240, 180);// right big
            Wall wall9 = new Wall(660, 140, 320, 20);
            Wall wall10 = new Wall(440, 320, 20, 180);
            Wall wall11 = new Wall(640, 480, 340, 20);
            Wall wall12 = new Wall(1070, 60, 20, 440);
            Wall wall13 = new Wall(0, 0, 5, 600); //left wall
            Wall wall14 = new Wall(0, 0, 1200, 5); //top wall
            Wall wall15 = new Wall(1180, 0, 5, 600); //right wall
            Wall wall16 = new Wall(0, 558, 1200, 5); //bottom wall
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            walls.Add(wall4);
            walls.Add(wall5);
            walls.Add(wall6);
            walls.Add(wall7);
            walls.Add(wall8);
            walls.Add(wall9);
            walls.Add(wall10);
            walls.Add(wall11);
            walls.Add(wall12);
            walls.Add(wall13);
            walls.Add(wall14);
            walls.Add(wall15);
            walls.Add(wall16);
            return walls;
        }
        public static List<Coin> BringCoins()
        {
            var coins = new List<Coin>();
            int xkoord = -25;
            for (int i = 1; i < 24; i++) // top coins
            {
                Coin coin = new Coin(xkoord += 50, 20);
                coins.Add(coin);
            }
            xkoord = -25;
            for (int i = 1; i < 24; i++) // bottom coins
            {
                Coin coin = new Coin(xkoord += 50, 520);
                coins.Add(coin);
            }
            int ykoord = 20;
            for (int i = 1; i < 10; i++) // left coins
            {
                Coin coin = new Coin(25, ykoord += 50);
                coins.Add(coin);
            }
            ykoord = 20;
            for (int i = 1; i < 10; i++) // right coins
            {
                Coin coin = new Coin(1125, ykoord += 50);
                coins.Add(coin);
            }
            return coins;
        }
        public static List<CoinSpecial> BringCoinSpecials()
        {
            var coinSpecials = new List<CoinSpecial>();
            CoinSpecial coinSpecial = new CoinSpecial(580, 100);
            coinSpecials.Add(coinSpecial);
            CoinSpecial coinSpecial1 = new CoinSpecial(240, 270);
            coinSpecials.Add(coinSpecial1);
            CoinSpecial coinSpecial2 = new CoinSpecial(1000, 100);
            coinSpecials.Add(coinSpecial2);
            CoinSpecial coinSpecial3 = new CoinSpecial(200, 180);
            coinSpecials.Add(coinSpecial3);

            return coinSpecials;
        }

        public static void StopTimers()
        {
            GhostObject.GhostTimer.Stop();
            PackmanObject.packmanTimerDown.Stop();
            PackmanObject.packmanTimerUp.Stop();
            PackmanObject.packmanTimerLeft.Stop();
            PackmanObject.packmanTimerRight.Stop();
        }
    }
}
