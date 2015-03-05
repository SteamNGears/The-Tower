using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class SpecialExplode : SpecialMode
    {
        public SpecialExplode(Pawn owner) : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Fire");
            this.Cost = 10;
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Attack atk = new Attack(this.Owner.GetPower(), this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
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
    }
}
