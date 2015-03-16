using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    class PotionTile:Actor
    {
        public static int HEALTH = 1;
        public static int AP = 2;
        private Image healthImg, apImg;
        private int x, y;
        public PotionBelt potions;

        public PotionTile():base("PotionTile", 0)
        {
            this.potions = new PotionBelt();
            this.Img = Image.FromFile("bitmap/Gui/PotionBelt.png");
            this.healthImg = Image.FromFile("bitmap/Gui/HealBottle.png");
            this.apImg = Image.FromFile("bitmap/Gui/APBottle.png");
            this.x = 0;
            this.y = 0;
        }

        /**
         *  Handles clicking to use potions
         * */
        public int click(int x, int y)
        {
            if (y < (this.y - this.Img.Height) || y > this.y || x < this.x|| x > this.x + Img.Width)
                return 0;
            if (y < (this.y -  this.Img.Height/2))
                return HEALTH;
            if (y > (this.y - this.Img.Height/2))
                return AP;
            return 0;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e, int x, int y)
        {
            this.x = x;
            this.y = y;

            base.Draw(e, x, y);

            for (int i = 0; i < this.potions.GetHealthPotionList(); i++)
                e.Graphics.DrawImage(this.healthImg, this.x + i * 24 + 8, this.y - 60);

            for (int i = 0; i < this.potions.GetApPotionList(); i++)
                e.Graphics.DrawImage(this.apImg, this.x + i * 24 + 8, this.y - 24);
            
        }
        public override Actor clone()
        {
            return this;
        }
    }
}
