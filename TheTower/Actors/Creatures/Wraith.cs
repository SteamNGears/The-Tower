﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheTower
{
    /* Lucas Salom
     * Creature Subclass - Wraith
     * Move - Through (No Collision)
     * Attack - Freeze
     * Special - Sneak Attack
     * Defense - Absorbs Ice and takes half dmg from Physical
     */
    public class Wraith: Creature
    {
        //base(name,typeID,AP,HP,Speed,Power)
        public Wraith(string name, Image img):base(name,3,10,15,10,3)
        {
            this.setImage(img);
            this.AddTag("Wraith");
            this.SetAttack(new AttackFreeze(this));
            DefenseMode def = new DefenseMode(this);
            def.AddAbsorb("Ice");
            def.AddHalf("Slashing");
            def.AddHalf("Piercing");
            def.AddHalf("Blunt");
            this.SetDefense(def);
            this.SetSpecial(new SpecialSneakAttack(this));
            this.SetMove(new MoveThrough(this));
        }
    }
}