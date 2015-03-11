using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class Options
    {
        public bool canMove;
        public bool canAttack;
        public bool canSpecial;

        public Options(bool move, bool atk, bool spec)
        {
            this.canMove = move;
            this.canAttack = atk;
            this.canSpecial = spec;
        }
    }
}
