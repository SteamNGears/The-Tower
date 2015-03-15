
namespace TheTower
{
    public class Switch : Structure
    {
        public Switch(int id, Trap trap) : base("A switch", id)
        {
            this.Target = trap;
        }
        public Trap Target { get; private set; }

        public override Actor clone()
        {
            return this;
        }

    }
}