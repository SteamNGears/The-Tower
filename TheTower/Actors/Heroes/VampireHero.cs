
namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Vampire
     * Move - Ground
     * Attack - Slash
     * Special - Vampire Bite
     * Defense - Immune to Ice
     */
    public class VampireHero:Hero
    {
        public VampireHero(string name):base(name,4,10,30,11,10)
        {

            this.AddTag("Vampire");
            this.AddTag("Collidable");
            DefenseMode def = new DefenseMode(this);
            def.AddNone("Ice");
            this.SetDefense(def);
            this.SetMove(new MoveGround(this));
            this.setImage(TheTower.Properties.Resources.hero2_50x50);
            this.SetAttack(new AttackSlash(this));
            this.SetSpecial(new SpecialVampireBite(this));
        }
    }
}
