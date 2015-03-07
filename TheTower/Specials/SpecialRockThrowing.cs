using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class SpecialRockThrowing : SpecialMode
    {
        public SpecialRockThrowing(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("RockThrowing");
            this.Cost = 10;
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Attack atk = new Attack(this.Owner.GetPower(), this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);         
            }
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetSpecialRange()
        {
            return this.Owner.GetTile().GetRange(10);
        }
    }
}
