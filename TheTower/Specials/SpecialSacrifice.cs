using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /*
     *  special skill of shaolin monk hero
     *  sacrifice half of the health point
     *  quadruple the attack point in one single move.
     */
    class SpecialSacrifice : SpecialMode
    {
        public SpecialSacrifice(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("Sacrifice");
            this.Cost = 5;
        }
        public override void Special(Tile target)
        {
            if (this.Owner.Health > 1 && this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Attack atk = new Attack(this.Owner.GetPower()*4, this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
                this.Owner.SetHealth(this.Owner.Health/2);
            }
        }

        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetSpecialRange()
        {
            return this.Owner.GetTile().GetRange(5);
        }
    }
}
