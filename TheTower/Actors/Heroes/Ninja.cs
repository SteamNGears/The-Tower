using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Ninja
     * Move - Ground
     * Attack - Slash
     * Special - Sneak Attack
     * Defense - Default
     */
    public class Ninja:Hero
    {
        public Ninja(string name):base(name,4,15,15,15,8)
        {
            this.AddTag("Ninja");
            this.AddTag("Collidable");
            this.setImage(TheTower.Properties.Resources.hero7_50x50);
            this.SetAttack(new AttackSlash(this));
            this.SetSpecial(new SpecialSneakAttack(this));
            this.SetDefense(new DefenseMode(this));
            this.SetMove(new MoveGround(this));
        }
    }
}
