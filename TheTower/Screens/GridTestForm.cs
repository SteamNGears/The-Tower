using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTower
{
    public partial class GridTestForm : Form
    {
        Grid Level;
        PawnFactory PFactory;
        Pawn p1;
        Pawn p2;
        public GridTestForm()
        {
            InitializeComponent();
            int x = 9, y = 9;
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Text = x.ToString() + " " + y.ToString();
                y--;
                if(y==-1)
                {
                    y = 9; x--;
                }
                button.Click += button_Click;
            }

            Level = new Grid();
            Level.SetGrid(10,10);
            PFactory = new PawnFactory();
            p1 = PFactory.MakeWarrior("Agrias");
            p2 = PFactory.MakeBomb("Perfo");
            Level.SetTile(p1, 5, 5);
            Level.SetTile(p2, 5, 6);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string[] xy = button.Text.Split(' ');
            int x = Convert.ToInt32(xy[0]);
            int y = Convert.ToInt32(xy[1]);
            if (Level.GetTile(x, y).HasCollidable())
                p1.UseAttack(Level.GetTile(x, y));
            else
                p1.MoveTo(Level.GetTile(x, y));
            Level.PrintGrid();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////");
        }
    }
}
