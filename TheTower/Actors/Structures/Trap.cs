
using System;
using System.Drawing;

namespace TheTower
{
    /**
     * Lucas Salom
     * Structure Subclass - Trap
     * No Collision
     * Performs an action upon being touched
     */
    public abstract class Trap : Structure
    {
        protected TrapAction Action;
        private bool activated;
        public Trap(string name, int id)
            : base(name, id)
        {
            this.activated = false;
            this.AddTag("Trap");
        }
        public override void Draw(System.Windows.Forms.PaintEventArgs e, int x, int y)
        {
            if(this.activated)
                if (this.Img != null)
                    e.Graphics.DrawImage(this.Img, x, y - this.Img.Height, this.Img.Width, this.Img.Height);
        }
        public void Act()
        {
            if (this.activated == false)
            {
                Console.WriteLine(this.Name + " Activates!");
                this.activated = true;
                this.Action.Act();

            }
        }
    }
}