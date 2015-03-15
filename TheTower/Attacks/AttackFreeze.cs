
using System.Collections.Generic;

namespace TheTower
{
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
