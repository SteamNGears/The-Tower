
using System.Collections.Generic;

namespace TheTower
{
    class SpecialCheerLeader: SpecialMode
    {
        /*
         *  cheer leader
         *  
         */ 
        public SpecialCheerLeader(Pawn owner)
            : base(owner)
        {
            typeList = new List<string>();
            typeList.Add("CheerLeader");
            this.Cost = 1;
        }
        public override void Special(Tile target)
        {
            if (this.GetSpecialRange().Contains(target) && this.Cost <= this.Owner.AP)
            {
                Attack atk = new Attack(-this.Owner.GetPower(), this.typeList);
                if(this.Owner.GetPower() > 0)
                    this.Owner.SetPower(this.Owner.GetPower()-1);
                this.GetAoeRange(target).ApplyDamage(atk);
                this.Owner.RemoveAP(this.Cost);
            }
        }
        public override TileComposite GetAoeRange(Tile tile)
        {
            return tile;
        }
        public override TileComposite GetSpecialRange()
        {
            return this.Owner.GetTile().GetRange(4);
        }
    }
}
