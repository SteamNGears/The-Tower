using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
