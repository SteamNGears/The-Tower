using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public abstract class SpecialMode
    {
        protected Pawn Owner;
        protected List<string> typeList;
        protected int Cost;
        public SpecialMode(Pawn owner)
        {
            this.Owner = owner;
        }
        public abstract void Special(Tile target);
        public abstract TileComposite GetAoeRange(Tile tile);
        public abstract TileComposite GetSpecialRange();

        public int GetCost()
        {
            return this.Cost;
        }
    }
}
