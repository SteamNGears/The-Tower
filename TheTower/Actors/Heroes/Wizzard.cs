
namespace TheTower
{
    /* Long Nguyen
     * Hero Subclass - Wizzard
     * Move - Ground
     * Attack - Wizzard Stick
     * Special - Heal
     * Defense - Default
     */
    public class Wizzard:Hero
    {
        public Wizzard (string name):base(name,4,10,15,10,10)
        {
            this.AddTag("Wizzard");
            this.AddTag("Collidable");
            this.SetAttack(new AttackWizzardStick(this));
            this.SetDefense(new DefenseMode(this));
            this.SetMove(new MoveGround(this));
            this.SetSpecial(new SpecialHeal(this));
            this.setImage(TheTower.Properties.Resources.hero4_50x50);
        }
    }
}
