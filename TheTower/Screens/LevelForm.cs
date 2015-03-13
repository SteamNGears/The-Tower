using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
		
namespace TheTower
{
    public partial class LevelForm : Form
    {
        //private Panel[,] SelectGrid;
        private Pawn[] Party;
        private Grid Level;         //the level grid
        private Grid Gui;           //The gui grid(player cards)
        private Tile selectedTile;
        private TileSelect selectionMenu;
        private TurnManager Turns;



        //temporary
        Image highlight = Image.FromFile("bitmap/HighlightViolet.png");
        public LevelForm(Pawn[] pParty)//Add xml filename
        {
            InitializeComponent();
            //enable double buffering
            this.DoubleBuffered = true;

            this.Visible = false;

            this.Party = pParty;

            //Create all the actor delegates and add them to the ActorFactory
            ActorDelegates.init();

        
            //create the level using the map factory
            this.Level = MapFactory.CreateMap("LucasLvl1.tmx");
            this.Level.setPosition(0, 96);
            
            this.Gui = new Grid();
            this.Gui.SetGrid(4, 1);
            this.Gui.setTileHeight(128);
            this.Gui.setTileWidth(256);
            this.Gui.setPosition(0, 640);

            this.Turns = new TurnManager();
            foreach (Pawn a in pParty)
            {
                this.Turns.AddPawn(a);
            }
            this.Turns.AddPawn(new Bomb("burb", TheTower.Properties.Resources.bomb64));
            this.selectedTile = null;

            if (this.Turns.NextTurn() == 1)
                Console.WriteLine("Level over");

            this.Gui.SetTile(pParty[0].getCard(), 0, 0);
            this.Gui.SetTile(pParty[1].getCard(), 1, 0);
            this.Gui.SetTile(pParty[2].getCard(), 2, 0);
            this.Gui.SetTile(pParty[3].getCard(), 3, 0);


            //Add actors manualy
            Level.GetTile(2, 12).AddActor(pParty[0]);
            Level.GetTile(7, 12).AddActor(pParty[1]);
            Level.GetTile(12, 12).AddActor(pParty[2]);
            Level.GetTile(14, 12).AddActor(pParty[3]);

            this.Refresh();
            this.ResumeLayout();
            this.Show();
			
        }
        


        /**
         * Calls render when the form is to be repainted
         * @author Jakob Wilson
         * */
        private void LevelForm_Paint(object sender, PaintEventArgs e)
        {
            this.Level.render(e);
            this.Gui.render(e);
        }


        /**
         * Handles clicking on the form. 
         * On right click, it generates a menu of movement/attack options
         * On left click, it performs the appropriate action selection for that tile
         * */
        private void LevelForm_Click(object sender, EventArgs e)
        {   
            
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                if (this.selectedTile != null)
                    this.selectedTile.RemoveActor(this.selectionMenu);//<-----------This line does not remove the actor correctly for some reason
                
                this.selectedTile = Level.getTileAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                Options options = this.Turns.getOptions(this.selectedTile);
                
                if (options != null)
                {
                    this.selectionMenu = new TileSelect(options);
                    this.selectedTile.AddActor(this.selectionMenu);
                }
                else
                    Console.WriteLine("no current pawn");
            }
            else if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                int sel;
                if(this.selectionMenu != null)
                    sel = this.selectionMenu.click((MouseEventArgs)e);
                else 
                    sel = 0;
                switch (sel)
                {

                    case 1: this.Turns.DoAttack(this.selectedTile);
                        break;
                    case 2: this.Turns.DoMove(this.selectedTile);
                        break;
                    case 3: this.Turns.DoSpecial(this.selectedTile);
                        break;
                }
                //this.selectedTile = null;
            }
            this.Refresh();
        }
    }
}
