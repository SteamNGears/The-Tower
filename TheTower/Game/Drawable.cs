
using System.Windows.Forms;

namespace TheTower
{
    public interface Drawable
    {
        void Draw(PaintEventArgs e, int x, int y);
    }
}
