using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    class AttackWizzardStick : AttackMode
    {
        public AttackWizzardStick(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("WizzardStick");
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
