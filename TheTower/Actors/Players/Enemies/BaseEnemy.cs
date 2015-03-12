using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
     * A base class for all enemies
     * */
    abstract class BaseEnemy:BasePlayer
    {
        public BaseEnemy():base()
        {
            this.AddTag("Enemy");
        }
    }
}
