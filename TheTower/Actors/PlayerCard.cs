using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTower.Actors
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
        private Image _dead;
        private Image _curTurn;


        public PlayerCard(Pawn p)
            : base("PlayerCard", 1)
        {
            this._source = p;
            this._actorImg = p.getImage();
            this._dead = Image.FromFile("bitmap/GUI/Skull.png");
            this._background = Image.FromFile("bitmap/CardBackGround.jpg");
            this._curTurn = Image.FromFile("bitmap/CurrentTurn.png");
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
            if (this._source.Health > 0 && this._actorImg != null)
                e.Graphics.DrawImage(this._actorImg, x, y, this._actorImg.Width, this._actorImg.Height);
            else if (this._source.Health <= 0)
                e.Graphics.DrawImage(this._dead, x, y, this._dead.Width, this._dead.Height);


            //setup
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                
            //info
           // e.Graphics.DrawImage(this._source.getImage(),x, y);
            e.Graphics.DrawString(this._source.ToString(), drawFont, drawBrush, x + 64, y + 4, drawFormat);

            if (this._source.isTurn)
            {
                e.Graphics.DrawImage(this._curTurn, x, y, this._curTurn.Width, this._curTurn.Height);
            }


                //cleanup
            drawFont.Dispose();

            drawBrush.Dispose();

        }
    }
}
