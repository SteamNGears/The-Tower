
namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Elf
     * Move - Ground
     * Attack - Chop
     * Special - Bow Shot
     * Defense - Take half from Fire/Ice
     */
    public class Elf:Hero
    {
        public Elf(string name):base(name, 4,7,15,8,10)
        {
            this.AddTag("Elf");
            this.AddTag("Collidable");
            this.setImage(TheTower.Properties.Resources.hero5_50x50);
            this.SetAttack(new AttackChop(this));
            this.SetSpecial(new SpecialBow(this));
            DefenseMode def = new DefenseMode(this);
            def.AddHalf("Ice");
            def.AddHalf("Fire");
            this.SetDefense(def);
            this.SetMove(new MoveGround(this));
        }
    }
}
