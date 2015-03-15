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
    public partial class StartGame : Form
    {
        private HeroSelection heroSelection;
        public StartGame()
        {
            InitializeComponent();
            GoFullscreen(false);
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
        }

        private void btStartGame_Click(object sender, EventArgs e)
        {
            heroSelection = new HeroSelection();
            this.Hide();
            if (heroSelection.ShowDialog(this) == DialogResult.OK)
            {
                this.Show();
            }

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lucas Salom \nJake Wilson \nLong Nguyen", "Credit", MessageBoxButtons.OK);
        }


    }
}
