using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * Lucas Salom
     * Attack Class specifying damage dealt and the damage's type.
     */
    public class Attack
    {
        public int Power { get; private set; }
        private List<string> Types;

        public Attack(int p, List<String> t)
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
