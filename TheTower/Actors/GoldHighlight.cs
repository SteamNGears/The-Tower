using System.Drawing;

namespace TheTower
{
    public class GoldHighlight:Structure
    {
        public GoldHighlight(string name, int id):base(name, id)
        {
            this.AddTag("Highlight") ;
            this.setImage(Image.FromFile("bitmap/Highlight.png"));
        }

        public override Actor clone()
        {
            return this;
        }

    }
}
