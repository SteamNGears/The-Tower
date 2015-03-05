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
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target))
            {
                Attack atk = new Attack(this.Owner.GetPower(), this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
                this.Owner.SetHealth(1);
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
