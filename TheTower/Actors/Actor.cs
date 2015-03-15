using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TheTower
{
    // ADD IN IMAGE ( Preferably PNG), DRAW METHOD
    // public void draw( PaintEventArgs e, int x, int y)
    // {
    //  e.Graphics.DrawImage(this.image,x,y,width,height);
    // }
    // ALSO ADD IN A COMPLETE WALL AND FLOOR CLASS FOR USE IN TESTING
    public abstract class Actor : Drawable
    {
        public string Name { get; private set; }
        protected int ID;
        protected Image Img;
        protected List<string> Tags;
        protected Tile CurTile;

        public Actor(string name, int id)
        {
            this.ID = id;
            this.Name = name;
            this.CurTile = null;
            this.Tags = new List<string>();
            this.Tags.Add("Drawable");
            this.Img = null;
        }

        public int GetId()
        {
            return this.ID;
        }
        public virtual void Draw(PaintEventArgs e, int x, int y)
        {
            if(this.Img!=null)
                e.Graphics.DrawImage(this.Img, x , y - this.Img.Height, this.Img.Width, this.Img.Height);
        }
        public override bool Equals(object obj)
        {
            return obj == this;
            /*if (obj is Actor)
                return this.ID == ((Actor)obj).ID;
            return false;*/
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.Name;
        }
        public void AddTag(string tag)
        {
            this.Tags.Add(tag);
        }
        public Tile GetTile()
        {
            return this.CurTile;
        }
        public void SetTile(Tile t)
        {
            this.CurTile = t;
        }
        /**
         *  Checks if an actor has a specific tag
         * */
        public bool hasTag(string s)
        {
            bool ret = false;
            foreach (string tag in this.Tags)
            {
                if (tag.Equals(s))
                    ret = true;
            }
            return ret;
        }

        /**
         * Sets the image for the actor
         * @author Jakob Wilson
         * */
        public void setImage(Image img)
        {
            this.Img = img;
        }

        /**
         * Gets the image for the actor
         * @author Jakob Wilson
         * */
        public Image getImage()
        {
            return this.Img;
        }

        /**
         *  Gets a shallow copy of the actor(same image data)
         * */
        public abstract Actor clone();
    }
}

