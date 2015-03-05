using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class MoveThrough : MoveMode
    {
        public MoveThrough(Pawn owner) : base(owner)
        {
            this.Cost = 3;
        }
        public override TileComposite GetMoveRange()
        {
            return this.Owner.GetTile().GetRange(this.Owner.Speed);
        }
    }
}
