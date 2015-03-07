using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public interface TileComposite
    {
        void ApplyDamage(Attack atk);

        bool Contains(Tile that);
    }
}
