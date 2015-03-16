
using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheTower
{
    /**
     * Lucas Salom
     * Trap Subclass - Spike
     * No Collision
     * Shanks Pawn upon being touched
     */
    public class TrapSpike: Trap
    {
        public TrapSpike(string name, int id, Image img)
            : base(name, id)
        {
            this.setImage(img);
            this.Action = new TrapActSpike(this);
        }

        public override Actor clone()
        {
            return new TrapSpike(this.Name,this.ID,this.Img);
        }
    }
}
