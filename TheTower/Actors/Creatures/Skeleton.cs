using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheTower
{
    /* Long Nguyen
     * Creature Subclass - Skeleton
     * Move - Ground
     * Attack - Chop
     * Special - Rock Throw
     * Defense - Default
     */
    public class Skeleton:Creature
    {
        //base(name,typeID,AP,HP,Speed,Power)
        public Skeleton(string name,Image img):base(name,3,7,15,8,10)
        {
            this.setImage(img);
            this.AddTag("Skeleton");
            this.AddTag("Collidable");

            this.SetAttack(new AttackChop(this));
            this.SetSpecial(new SpecialRockThrowing(this));
            this.SetDefense(new DefenseMode(this));
            this.SetMove(new MoveGround(this));
        }
    }
}
