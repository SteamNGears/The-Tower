﻿
using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheTower
{
    /**
     * Lucas Salom
     * Trap Subclass - Explosive
     * No Collision
     * Explodes upon being touched
     */
    public class TrapExplosive : Trap
    {
        public TrapExplosive(string name, int id, Image img)
            : base(name, id)
        {
            this.setImage(img);
            this.Action = new TrapActExplode(this);
        }
        public override Actor clone()
        {
            return new TrapExplosive(this.Name, this.ID,this.Img);
        }
    }
}
