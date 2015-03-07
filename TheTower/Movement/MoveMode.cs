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
        protected int Cost;
        public MoveMode(Pawn owner)
        {
            this.Owner = owner;
        }
        public void Move(Tile target)
        {
            if (this.GetMoveRange().Contains(target) && this.Cost<=this.Owner.AP)
            {
                this.Owner.GetTile().RemoveActor(this.Owner);
                target.AddActor(this.Owner);
                this.Owner.SetTile(target);
                this.Owner.RemoveAP(this.Cost);
            }
        }
        public int GetCost()
        {
            return this.Cost;
        }
        public abstract TileComposite GetMoveRange();
    }
}
