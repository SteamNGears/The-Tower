
namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Shaolin Monk
     * Move - Ground
     * Attack - Slash
     * Special - Sacrifice
     * Defense - Immune to Fire
     */
    public class ShaolinMonk:Hero
    {
        public ShaolinMonk(string name):base(name, 4, 10, 23,13,9)
        {

            this.AddTag("Shaolin Monk");
            this.AddTag("Collidable");
            this.SetAttack(new AttackSlash(this));
            DefenseMode def = new DefenseMode(this);
            def.AddNone("Fire");
            this.SetDefense(def);
            this.SetMove(new MoveGround(this));
            this.SetSpecial(new SpecialSacrifice(this));
            this.setImage(TheTower.Properties.Resources.hero6_50x50);
        }
    }
}
