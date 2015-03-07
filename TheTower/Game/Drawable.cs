using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTower
{
    public interface Drawable
    {
        void Draw(PaintEventArgs e, int x, int y);
    }
}
