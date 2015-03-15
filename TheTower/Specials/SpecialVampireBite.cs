using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /*
     *  Special Bite 
     *  vampire special skill
     *  random damage: from power/10 up to power*2
     *  vampire take enemy blood and heal them self: damage/2
     */ 
    class SpecialVampireBite: SpecialMode
    {
        public SpecialVampireBite(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("VampireBite");
            this.Cost = 8;
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Random random = new Random();
                int randomNumber = random.Next(this.Owner.GetPower() / 10, this.Owner.GetPower() * 2);
                Attack atk = new Attack(randomNumber, this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
                this.Owner.SetHealth(this.Owner.Health + randomNumber/2);
            }
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetSpecialRange()
        {
            return this.Owner.GetTile().GetRange(3);
        }

        public override string ToString()
        {
            return "Vampire Bite";
        }
    }
}
