using System.Collections.Generic;

namespace TheTower
{
    abstract class Highlight:Actor
    {
        public Highlight(string name, int id)
            : base(name, id)
        {
            this.Tags.Add("highlight");
        }

        public abstract override Actor clone();

    }
}
