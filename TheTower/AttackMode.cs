using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public abstract class AttackMode
    {
        protected Pawn Owner;
        protected List<string> typeList;

        public AttackMode(Pawn owner)
        {
            this.Owner = owner;
        }
        public void Attack(Tile target)
        {
            if (this.GetAttackRange().Contains(target))
            {
                Console.WriteLine(this.Owner.Name + " Attacks!");
                Attack atk = new Attack(this.Owner.GetPower(), this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
            }
        }
        public abstract TileComposite GetAoeRange(Tile tile);
        public abstract TileComposite GetAttackRange();
    }
}
