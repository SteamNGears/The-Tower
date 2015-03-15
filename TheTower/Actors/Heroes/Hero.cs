using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    /* Lucas Salom
     * Pawn Subclass - Hero
     * This class signifies that the Pawn is a playable character (actions can be dictated by the client).
     */
    public abstract class Hero:Pawn
    {
        public Hero(string name,int ID,int ap, int health, int speed, int power):base(name,ID,ap,health,speed,power)
        {
            this.AddTag("Hero");
        }
        public override Actor clone()
        {
            return this;
        }
    }
}
