using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * Long Nguyen
     * Attack SubClass - Smile
     * Type - Smile
     * Single Target - Ranged
     */
    class AttackSmile : AttackMode
    {
        public AttackSmile(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
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
