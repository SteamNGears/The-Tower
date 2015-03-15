using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /*
     *  sneak attack class
     *  can be used for ninja or stealthy pawn
     *  25% of success
     *  dammage = power * 3 (deadly)
     *  range = 3 (need to be very closed)
     */ 
    class SpecialSneakAttack : SpecialMode
    {
        public SpecialSneakAttack(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("SneakAttack");
            this.Cost = 15;
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100);
                Attack atk;
                if (randomNumber <= 25)
                    atk = new Attack(this.Owner.GetPower() * 3, this.typeList);
                else
                    atk = new Attack(0, this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);         
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
            return "Sneak Attack";
        }
    }
}
