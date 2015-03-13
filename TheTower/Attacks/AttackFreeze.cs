using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * Lucas Salom
     * Attack SubClass - Freeze
     * Type - Ice
     * Single Target - Ranged
     */
    public class AttackFreeze : AttackMode
    {
        public AttackFreeze(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Ice");
            this.Cost = 5;
        }
        public override int ModDamage()
        {
            return (int)(this.Owner.GetPower() * 1);
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
