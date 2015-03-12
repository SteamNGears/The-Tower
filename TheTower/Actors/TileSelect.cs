using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTower
{
    class TileSelect:Actor
    {
        private Image attackImg;
        private Image moveImg;
        private Image specialImg;
        private Options opt;

        public TileSelect(Options o)
            : base("Options", 0)
        {
            this.AddTag("Options");
            this.opt = o;
            this.Img = Image.FromFile("bitmap/GUI/Background.png");
            this.attackImg = Image.FromFile("bitmap/GUI/Attack.png");
            this.moveImg = Image.FromFile("bitmap/GUI/Move.png");
            this.specialImg = Image.FromFile("bitmap/GUI/Special.png");

        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e, int x, int y)
        {
            e.Graphics.DrawImage(this.Img,x,y, this.Img.Width, this.Img.Height);
            if (opt.canAttack)
                e.Graphics.DrawImage(this.attackImg, x, y);
            if (opt.canMove)
                e.Graphics.DrawImage(this.moveImg, x, y);
            if (opt.canSpecial)
                e.Graphics.DrawImage(this.specialImg, x, y);
        }

        public override Actor clone()
        {
            return new TileSelect(this.opt);
        }
 
    }
}
