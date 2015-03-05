using System;
using System.Collections;
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
    public partial class HeroSelection : Form
    {
        ArrayList heroQueue;
        LevelForm gameScreen;
        public HeroSelection()
        {
            InitializeComponent();
            GoFullscreen(false);
            heroQueue = new ArrayList(4);
            InitializeHeroQueue();
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

        private void btBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Enqueue(ArrayList heroQueue, HeroNode heroNode)
        {
            heroQueue.Insert(0, heroNode);
            if (heroQueue.Count > 4)
                heroQueue.RemoveAt(4);
        }

        private void DrawHero()
        {
            pbHero1.Image = Image.FromFile(((HeroNode)heroQueue[0]).ImagePath);
            pbHero2.Image = Image.FromFile(((HeroNode)heroQueue[1]).ImagePath);
            pbHero3.Image = Image.FromFile(((HeroNode)heroQueue[2]).ImagePath);
            pbHero4.Image = Image.FromFile(((HeroNode)heroQueue[3]).ImagePath);
        }

        private void InitializeHeroQueue()
        {
            for (int x = 0; x < 4; x++)
            {
                HeroNode newHero = new HeroNode("");
                Enqueue(heroQueue, newHero);
            }
            DrawHero();
        }
        private void btHero1_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 1");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero2_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 2");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero3_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 3");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero4_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 4");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero5_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 5");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero6_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 6");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero7_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 7");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero8_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 8");
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void tbHero1_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[0]).UserNamed = tbHero1.Text;
        }

        private void tbHero2_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[1]).UserNamed = tbHero1.Text;
        }

        private void tbHero3_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[2]).UserNamed = tbHero1.Text;
        }

        private void tbHero4_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[3]).UserNamed = tbHero1.Text;
        }

        private void btReady_Click(object sender, EventArgs e)
        {
            PawnFactory fact = new PawnFactory();
            Pawn[] party = new Pawn[4];
            party[0] = fact.MakeWarrior("a");
            party[0].setImage(Image.FromFile("bitmap/dice0.png"));
            party[1] = fact.MakeWarrior("b");
            party[1].setImage(Image.FromFile("bitmap/dice0.png"));
            party[2] = fact.MakeWarrior("c");
            party[2].setImage(Image.FromFile("bitmap/dice0.png"));
            party[3] = fact.MakeWarrior("d");
            party[3].setImage(Image.FromFile("bitmap/dice0.png"));

            gameScreen = new LevelForm(party);
            gameScreen.Visible = false;
            this.Hide();
            if (gameScreen.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
