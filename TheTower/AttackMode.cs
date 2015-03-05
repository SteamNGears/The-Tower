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
        protected int Cost;

        public AttackMode(Pawn owner)
        {
            this.Owner = owner;
        }
        public void Attack(Tile target)
        {
            if (this.GetAttackRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Console.WriteLine(this.Owner.Name + " Attacks!");
                Attack atk = new Attack(this.ModDamage(), this.typeList);
                this.GetAoeRange(target).ApplyDamage(atk);
                this.Owner.RemoveAP(this.Cost);
            }
        }
        public int GetCost()
        {
            return this.Cost;
        }
        public abstract int ModDamage();
        public abstract TileComposite GetAoeRange(Tile tile);
        public abstract TileComposite GetAttackRange();
    }
}
