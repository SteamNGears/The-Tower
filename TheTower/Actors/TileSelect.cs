using System.Drawing;
using System.Windows.Forms;

namespace TheTower
{
    /**
     * An actor tile that is used to select what operation to do to that tile
     * 
     * */
    class TileSelect:Actor
    {
        private Image attackImg;
        private Image moveImg;
        private Image specialImg;
        private Options opt;
        private int x;
        private int y;

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

        /**
         * Draws all of the available options for the tile(using the Opsions object
         * */
        public override void Draw(System.Windows.Forms.PaintEventArgs e, int x, int y)
        {
            this.x = x;
            this.y = y;
            e.Graphics.DrawImage(this.Img,x,y - this.Img.Height, this.Img.Width, this.Img.Height);
            if (opt.canAttack)
                e.Graphics.DrawImage(this.attackImg, x, y - this.attackImg.Height);
            if (opt.canMove)
                e.Graphics.DrawImage(this.moveImg, x, y - this.moveImg.Height);
            if (opt.canSpecial)
                e.Graphics.DrawImage(this.specialImg, x, y - this.moveImg.Height);
        }



        /**
         * Gets the tile selection based on a mouse click
         * 
         * */
        public int click(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.X < this.x + this.Img.Width) && (e.X > this.x) && (e.Y > this.y - this.Img.Width) && e.Y < this.y)
            {
                if (e.X < this.x + this.Img.Width / 3)
                    return 1;
                else if (e.X < this.x + 2 * (this.Img.Width / 3))
                    return 2;
                else
                    return 3;
            }
            return 0;
        }


        /**
         * Clones the tile
         * */
        public override Actor clone()
        {
            return new TileSelect(this.opt);
        }
 
    }
}
