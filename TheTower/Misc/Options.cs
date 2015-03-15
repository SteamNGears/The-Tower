
namespace TheTower
{
    public class Options
    {
        public bool canMove;
        public bool canAttack;
        public bool canSpecial;

        public Options(bool move, bool atk, bool spec)
        {
            this.canMove = move;
            this.canAttack = atk;
            this.canSpecial = spec;
        }
    }
}
