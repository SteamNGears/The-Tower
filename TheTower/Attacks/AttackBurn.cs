using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class AttackBurn : AttackMode
    {
        public AttackBurn(Pawn owner) : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Fire");
            this.Cost = 4;
        }
        public override int ModDamage()
        {
            return (int)(this.Owner.GetPower() * 0.8);
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
