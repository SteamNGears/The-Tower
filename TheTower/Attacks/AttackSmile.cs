
using System.Collections.Generic;

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
