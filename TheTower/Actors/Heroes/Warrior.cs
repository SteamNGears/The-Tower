using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /* Lucas Salom
     * Hero Subclass - Warrior
     * Move - Ground
     * Attack - Slash
     * Special - Heal
     * Defense - Default
     */
    public class Warrior : Hero
    {
        public Warrior(string name):base(name,4,10,25,10,10)
        {
            this.AddTag("Warrior");
            this.AddTag("Collidable");
            this.SetAttack(new AttackSlash(this));
            this.SetDefense(new DefenseMode(this));
            this.SetMove(new MoveGround(this));
            this.setImage(TheTower.Properties.Resources.hero1_50x50);
            this.SetSpecial(new SpecialHeal(this));
        }
    }
}
