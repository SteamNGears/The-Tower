using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * A base class for all players
     * @author Jakob Wilson
     * */
    abstract class BasePlayer : Actor
    {
        public int damage       { get; private set; }
        public int health       { get; private set; }
        public int maxHealth    { get; private set; }
        public int armor        { get; private set; }

        public BasePlayer()
            : base("Player", 0)
        {
            this.AddTag("Player");
        }

        public abstract void Attack(BaseEnemy defender);
        public abstract void Defend(BaseEnemy attacker);
    }
}