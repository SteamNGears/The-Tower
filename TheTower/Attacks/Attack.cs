
using System.Collections.Generic;

namespace TheTower
{
    public class Attack
    {
        public int Power { get; private set; }
        private List<string> Types;

        public Attack(int p, List<string> t)
        {
            this.Power = p;
            this.Types = t;
        }
        public bool HasType(string t)
        {
            if (this.Types.Contains(t))
                return true;
            return false;
        }
        public List<string> GetTypes()
        {
            return this.Types;
        }
    }
}
