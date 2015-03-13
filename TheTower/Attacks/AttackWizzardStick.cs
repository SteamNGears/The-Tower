using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * Long Nguyen
     * Attack SubClass - WizzardStick
     * Type - Blunt
     * Single Target - Melee
     */
    class AttackWizzardStick : AttackMode
    {
        public AttackWizzardStick(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Blunt");
            this.Cost = 5;
        }
        public override int ModDamage()
        {
            return (int)(this.Owner.GetPower() / 2);
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetAttackRange()
        {
            return this.Owner.GetTile().GetRange(2);
        }
    }
}
