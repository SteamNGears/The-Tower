using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    class AttackSmile : AttackMode
    {
        public AttackSmile(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Smile");
            this.Cost = 1;
        }
        public override int ModDamage()
        {
            return 1;
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
