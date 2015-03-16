using System.Collections.Generic;

namespace TheTower
{
    public class TrapActExplode:TrapAction
    {
        private Trap owner;
        private List<string> types;
        public TrapActExplode(Trap owner)
        {
            this.owner = owner;
            this.types = new List<string>();
            types.Add("Fire");
        }
        public void Act()
        {
            Attack atk = new Attack(7,this.types);
            this.GetRange(this.owner.GetTile()).ApplyDamage(atk);
        }
        private TileComposite GetRange(Tile tile)
        {
            return tile.GetRange(5);
        }
    }
}
