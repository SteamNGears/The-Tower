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
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public HeroSelection()
        {
            InitializeComponent();
            GoFullscreen(false);
            heroQueue = new ArrayList(4);
            InitializeHeroQueue();
            foreach(Control c in this.Controls)
            {
                c.TabIndex = 99;
            }
            this.btReady.TabIndex = 5;
            this.tbHero1.TabIndex = 1;
            this.tbHero2.TabIndex = 2;
            this.tbHero3.TabIndex = 3;
            this.tbHero4.TabIndex = 4;
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
            newHero.HeroClass = "Warrior";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero2_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 2");
            newHero.HeroClass = "Vampire";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero3_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 3");
            newHero.HeroClass = "Miss World";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero4_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 4");
            newHero.HeroClass = "Wizzard";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero5_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 5");
            newHero.HeroClass = "Elf";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero6_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 6");
            newHero.HeroClass = "Shaolin Monk";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero7_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 7");
            newHero.HeroClass = "Ninja";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void btHero8_Click(object sender, EventArgs e)
        {
            HeroNode newHero = new HeroNode("Hero 8");
            newHero.HeroClass = "Paladin";
            Enqueue(heroQueue, newHero);
            DrawHero();
        }

        private void tbHero1_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[0]).UserNamed = tbHero1.Text;
        }

        private void tbHero2_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[1]).UserNamed = tbHero2.Text;
        }

        private void tbHero3_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[2]).UserNamed = tbHero3.Text;
        }

        private void tbHero4_TextChanged(object sender, EventArgs e)
        {
            ((HeroNode)heroQueue[3]).UserNamed = tbHero4.Text;
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        private Pawn makingRandomHero(HeroFactory fact, String heroName)
        {
            int num = RandomNumber(0, 8);
            if (num == 0)
            {
                if (heroName == null)
                    heroName = "Warrior";
                return fact.MakeWarrior(heroName);
            }
            else if (num == 1)
            {
                if (heroName == null)
                    heroName = "Vampire";
                return fact.MakeVampireHero(heroName);
            }
            else if (num == 2)
            {
                 if (heroName == null)
                     heroName = "Miss World";
                 return fact.MakeMissWorld(heroName);
            }
            else if (num == 3)
            {
                 if (heroName == null)
                     heroName = "Wizzard";
                return fact.MakeWizzard(heroName);
            }
                
            else if (num == 4)
            {
                 if (heroName == null)
                     heroName = "Elf";
                 return fact.MakeElf(heroName);
            }
            else if (num == 5)
            {
                 if (heroName == null)
                     heroName = "Shaolin Monk";
                 return fact.MakeShaolinMonk(heroName);
            }
            else if (num == 6)
            {
                if (heroName == null)
                    heroName = "Ninja";
                return fact.MakeShaolinMonk(heroName);
            }
            else
            {
                if (heroName == null)
                    heroName = "Paladin";
                return fact.MakePaladin(heroName);
            }
        }
        private Pawn makingHero(HeroFactory fact, String heroClass, String heroName)
        {
            if (heroName==null)
                heroName = heroClass + "";
            if (heroClass.Equals("Warrior"))
                return fact.MakeWarrior(heroName);
            else if (heroClass.Equals("Vampire"))
                return fact.MakeVampireHero(heroName);
            else if (heroClass.Equals("Miss World"))
                return fact.MakeMissWorld(heroName);
            else if (heroClass.Equals("Wizzard"))
                return fact.MakeWizzard(heroName);
            else if (heroClass.Equals("Elf"))
                return fact.MakeElf(heroName);
            else if (heroClass.Equals("Shaolin Monk"))
                return fact.MakeShaolinMonk(heroName);
            else if (heroClass.Equals("Ninja"))
                return fact.MakeNinja(heroName);
            else if (heroClass.Equals("Paladin"))
                return fact.MakePaladin(heroName); 
            else
                return makingRandomHero(fact, heroName);

        }
        private void btReady_Click(object sender, EventArgs e)
        {
            foreach (HeroNode type in heroQueue)
            {
                if (type.HeroClass == null)
                    return;
            }
            HeroFactory fact = new HeroFactory();
            Pawn[] party = new Pawn[4];
            party[0] = makingHero(fact, ((HeroNode)heroQueue[0]).HeroClass, ((HeroNode)heroQueue[0]).UserNamed);
            party[1] = makingHero(fact, ((HeroNode)heroQueue[1]).HeroClass, ((HeroNode)heroQueue[1]).UserNamed); ;
            party[2] = makingHero(fact, ((HeroNode)heroQueue[2]).HeroClass, ((HeroNode)heroQueue[2]).UserNamed); ;
            party[3] = makingHero(fact, ((HeroNode)heroQueue[3]).HeroClass, ((HeroNode)heroQueue[3]).UserNamed); ;

            gameScreen = new LevelForm(party);
            gameScreen.Visible = false;
            this.Hide();


            if (gameScreen.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
