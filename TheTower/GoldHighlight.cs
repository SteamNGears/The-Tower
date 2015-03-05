using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class GoldHighlight:Structure
    {
        public GoldHighlight(string name, int id):base(name, id)
        {
            this.AddTag("Highlight") ;
            this.setImage(Image.FromFile("bitmap/Highlight.png"));
        }

    }
}
