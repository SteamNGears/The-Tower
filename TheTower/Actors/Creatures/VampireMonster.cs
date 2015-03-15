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
        public override Actor clone()
        {
            return new VampireMonster(this.Name, this.Img);
        }

        //Determines whether or not to do Special Attack or Regular attack
        //
        public override bool CalculateSpecial()
        {
            if (this.Health < this.MaxHealth / 2)
                return true;
            return false;
        }
    }
}
