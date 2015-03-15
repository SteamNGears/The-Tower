
namespace TheTower
{
    /* Lucas Salom
     * Pawn Subclass - Creature
     * This class signifies that a Pawn has an AI controller as opposed to being a playable character.
     */
    public abstract class Creature : Pawn
    {
        private AIController AI;
        public Creature(string name,int ID,int ap, int health, int speed, int power):base(name,ID,ap,health,speed,power)
        {
            this.AI= new AIController(this);
            this.AddTag("Creature");
        }
        public AIController GetController()
        {
            return this.AI;
        }

        //Determines whether or not to do Special Attack or Regular attack
        //
        public abstract bool CalculateSpecial();

        //Returns effective range of special
        //
        public TileSet GetSpecialEffectiveRange()
        {
            return this.Special.GetEffectiveRange();
        }
    }
}
