using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class MoveGround : MoveMode
    {
        public MoveGround(Pawn owner):base(owner){}
        public override TileComposite GetMoveRange()
        {
            return this.Owner.GetTile().GetMoveRange(this.Owner.Speed);
        }
    }
}
