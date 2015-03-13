using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class TrapExplode:TrapAction
    {
        private Trap owner;
        private List<string> types;
        public TrapExplode(Trap owner)
        {
            this.owner = owner;
            this.types = new List<string>();
            types.Add("Fire");
        }
        public void Act()
        {
            Attack atk = new Attack(this.owner.Power,this.types);
            this.GetRange(this.owner.GetTile()).ApplyDamage(atk);
        }
        public TileComposite GetRange(Tile tile)
        {
            return tile.GetRange(5);
        }
    }
}
