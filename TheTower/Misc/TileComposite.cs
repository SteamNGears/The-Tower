using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /**
         * Lucas Salom
         * Composite interface to allow range detection to function on single and/or multiple tiles.
         */
    public interface TileComposite
    {
        void ApplyDamage(Attack atk);

        bool Contains(Tile that);
    }
}
