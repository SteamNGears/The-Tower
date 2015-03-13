using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Paladin
     * Move - Ground
     * Attack - Slash
     * Special - Heal
     * Defense - Default
     */
    public class Paladin : Hero
    {
        public Paladin(string name):base(name,4,10,25,10,10)
        {
            this.AddTag("Paladin");
            this.AddTag("Collidable");
            this.SetAttack(new AttackSlash(this));
            this.SetDefense(new DefenseMode(this));
            this.SetMove(new MoveGround(this));
            this.setImage(TheTower.Properties.Resources.hero8_50x50);
            this.SetSpecial(new SpecialHeal(this));

        }
    }
}
