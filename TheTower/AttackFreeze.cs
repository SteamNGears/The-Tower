using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class AttackFreeze : AttackMode
    {
        public AttackFreeze(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Ice");
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetAttackRange()
        {
            return this.Owner.GetTile().GetRange(6);
        }
    }
}
