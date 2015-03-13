using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Miss World
     * Move - Ground
     * Attack - Smile
     * Special - Cheer
     * Defense - Default
     */
    public class MissWorld:Hero
    {
        public MissWorld(string name):base(name,4,10,10,5,15)
        {

            this.AddTag("Miss World");
            this.AddTag("Collidable");
            this.setImage(TheTower.Properties.Resources.hero3_50x50);
            this.SetAttack(new AttackSmile(this));
            this.SetSpecial(new SpecialCheerLeader(this));
            this.SetDefense(new DefenseMode(this));
            this.SetMove(new MoveGround(this));
        }
    }
}
