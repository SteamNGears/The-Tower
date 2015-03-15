using System.Drawing;
using System;

namespace TheTower
{
    /* Long Nguyen
     * Creature Subclass - Skeleton
     * Move - Ground
     * Attack - Chop
     * Special - Rock Throw
     * Defense - Absorbs Holy (Heals hurt skeletons)
     */
    public class Skeleton : Creature
    {
        //base(name,typeID,AP,HP,Speed,Power)
        public Skeleton(string name, Image img)
            : base(name, 3, 7, 15, 8, 10)
        {
            this.setImage(img);
            this.AddTag("Skeleton");
            this.AddTag("Collidable");

            this.SetAttack(new AttackChop(this));
            this.SetSpecial(new SpecialRockThrowing(this));
            DefenseMode def = new DefenseMode(this);
            def.AddAbsorb("Holy");
            this.SetDefense(def);
            this.SetMove(new MoveGround(this));
        }
        public override Actor clone()
        {
            return new Skeleton(this.Name, this.Img);
        }
        //Determines whether or not to do Special Attack or Regular attack
        //
        public override bool CalculateSpecial()
        {
            Random rand = new Random();
            if (rand.Next(0,100) < 60)
                return true;
            return false;
        }
    }
}
