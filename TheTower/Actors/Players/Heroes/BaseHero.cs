using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * A base class for all heroes
     * */
    abstract class BaseHero:BasePlayer
    {
        public BaseHero():base()
        {
            this.AddTag("Hero");
        }
    }
}
