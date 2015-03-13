using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheTower
{
    /* Long Nguyen
     * Creature Subclass - Vampire
     * Move - Ground
     * Attack - Slice
     * Special - Vampire Bite
     * Defense - Immune to Ice
     */
    public class VampireMonster:Creature
    {
        //base(name,typeID,AP,HP,Speed,Power)
        public VampireMonster(string name, Image img):base(name,3,10,30,11,10)
        {
            this.setImage(img);
            this.AddTag("Vampire");
            this.AddTag("Collidable");
            DefenseMode def = new DefenseMode(this);
            def.AddNone("Ice");
            this.SetDefense(def);
            this.SetMove(new MoveGround(this));
            this.SetAttack(new AttackSlash(this));
            this.SetSpecial(new SpecialVampireBite(this));
        }
    }
}
