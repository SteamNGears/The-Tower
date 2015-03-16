using System.Collections.Generic;

namespace TheTower
{
    public class TrapActSpike : TrapAction
    {
        private Trap owner;
        private List<string> types;
        public TrapActSpike(Trap owner)
        {
            this.owner = owner;
            this.types = new List<string>();
            types.Add("Piercing");
        }
        public void Act()
        {
            Attack atk = new Attack(10, this.types);
            this.owner.GetTile().ApplyDamage(atk);
        }
    }
}
