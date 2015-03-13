using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheTower
{
    /* Lucas Salom
     * Creature Subclass - Bomb
     * Move - Ground
     * Attack - Burn
     * Special - Explode
     * Defense - Absorb Fire
     */
    public class Bomb:Creature
    {
        ///base(name,typeID,AP,HP,Speed,Power)
        public Bomb(string name, Image img):base(name,3,7,15,8,10)
        {
            this.setImage(img);
            this.AddTag("Bomb");
            this.AddTag("Collidable");
            this.SetAttack(new AttackBurn(this));
            DefenseMode def = new DefenseMode(this);
            def.AddAbsorb("Fire");
            this.SetDefense(def);
            this.SetMove(new MoveGround(this));
            this.SetSpecial(new SpecialExplode(this));
        }
    }
}
