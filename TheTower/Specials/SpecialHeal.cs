using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class SpecialHeal : SpecialMode
    {
        public SpecialHeal(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Holy");
            this.Cost = 4;
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Attack atk = new Attack(-this.Owner.GetPower(), this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
                this.Owner.RemoveAP(this.Cost);
            }
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetSpecialRange()
        {
            return this.Owner.GetTile().GetRange(8);
        }

        public override string ToString()
        {
            return "Heal";
        }
    }
}
