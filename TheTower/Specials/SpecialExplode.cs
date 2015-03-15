
using System.Collections.Generic;

namespace TheTower
{
    public class SpecialExplode : SpecialMode
    {
        public SpecialExplode(Pawn owner) : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Fire");
            this.Cost = 7;
        }
        public override void Special(Tile target)
        {
            if (this.Cost <= this.Owner.AP)
            {
                Attack atk = new Attack(this.Owner.GetPower(), this.typeList);
                this.GetAoeRange(this.Owner.GetTile()).ApplyDamage(atk);
                this.Owner.SetHealth(1);
                this.Owner.RemoveAP(this.Cost);
            }
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile.GetRange(5);
        }
        public override TileComposite GetSpecialRange()
        {
            return this.Owner.GetTile();
        }

        public override string ToString()
        {
            return "Explode";
        }
    }
}
