
using System.Collections.Generic;

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
        public TileSet GetEffectiveRange()
        {
            TileSet range = new TileSet();
            if (this.GetSpecialRange() is TileSet)
            {
                TileSet specRange = (TileSet)this.GetSpecialRange();
                foreach (Tile t in specRange)
                {
                    if (this.GetAoeRange(t) is TileSet)
                    {
                        TileSet aoeRange = (TileSet)this.GetAoeRange(t);
                        foreach (Tile b in aoeRange)
                            range.Add(b);
                    }
                    else
                        range.Add(t);
                }
            }
            else
            {
                Tile specRange = (Tile)this.GetSpecialRange();
                if (this.GetAoeRange(specRange) is TileSet)
                {
                    TileSet aoeRange = (TileSet)this.GetAoeRange(specRange);
                    foreach (Tile b in aoeRange)
                        range.Add(b);
                }
                else
                    range.Add(specRange);
            }
            return range;
        }

        public int GetCost()
        {
            return this.Cost;
        }
    }
}
