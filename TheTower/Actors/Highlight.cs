using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    abstract class Highlight:Actor
    {
        public Highlight(String name, int id)
            : base(name, id)
        {
            this.Tags.Add("highlight");
        }

        public abstract override Actor clone();

    }
}
