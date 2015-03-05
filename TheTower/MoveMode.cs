using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public abstract class MoveMode
    {
        protected Pawn Owner;
        public MoveMode(Pawn owner)
        {
            this.Owner = owner;
        }
        public void Move(Tile target)
        {
            if (this.GetMoveRange().Contains(target))
            {
                this.Owner.GetTile().RemoveActor(this.Owner);
                target.AddActor(this.Owner);
                this.Owner.SetTile(target);
            }
        }
        public abstract TileComposite GetMoveRange();
    }
}
