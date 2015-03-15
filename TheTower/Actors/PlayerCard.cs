using System.Drawing;
using System.Windows.Forms;

namespace TheTower
{
    /*
     * A class to represent a player's gui card so it can be drawn in a grid
     * @author Jakob Wilson
     * */
    class PlayerCard : Actor
    {
        private Pawn _source;
        private Image _actorImg;
        private Image _background;


        public PlayerCard(Pawn p)
            : base("PlayerCard", 1)
        {
            this._source = p;
            this._actorImg = p.getImage();
            this._background = Image.FromFile("bitmap/CardBackGround.jpg");
        }

        public override Actor clone()
        {
            return new PlayerCard(this._source);
        }

        /**
         * Draws the card at the specified. The card contains a ackground image and all of the player information
         * */
        public override void Draw(PaintEventArgs e, int x, int y)
        {
            if (this._background != null)
                e.Graphics.DrawImage(this._background, x, y, this._background.Width, this._background.Height);
            if (this._actorImg != null)
                e.Graphics.DrawImage(this._actorImg, x, y, this._actorImg.Width, this._actorImg.Height);

            //setup
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                
            //info
           // e.Graphics.DrawImage(this._source.getImage(),x, y);
            e.Graphics.DrawString("Name: " + this._source.Name, drawFont, drawBrush, x + 64, y + 4, drawFormat);
            e.Graphics.DrawString("Health: " + this._source.Health + "/" + this._source.MaxHealth, drawFont, drawBrush, x + 64, y + 18, drawFormat);
            e.Graphics.DrawString("Action Points: " + this._source.AP + "/" + this._source.MaxAP, drawFont, drawBrush, x + 64, y + 32, drawFormat);
            
            
                //cleanup
            drawFont.Dispose();

            drawBrush.Dispose();

        }
    }
}
