using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheTower
{
    /**
     * Lucas Salom
     * Structure Subclass - Wall
     * Collidable Actor
     */
    public class Wall : Structure
    {
        public Wall(string name, int id)
            : base(name, id)
        {
            this.AddTag("Collidable");
            this.AddTag("Wall");
        }
        public override Actor clone()
        {
            Actor ret = new Wall(this.Name, this.ID);
            ret.setImage(this.Img);
            return ret;
        }
    }
}