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
        private PawnFactory fact;
        private Tile selectedTile;
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
            this.createActorDelegates();

        
            //create the level using the map factory
            this.Level = MapFactory.CreateMap("Level1.tmx");
            this.Gui = new Grid();
            this.Gui.SetGrid(4, 1);
            this.Gui.setTileHeight(128);
            this.Gui.setTileWidth(256);
            this.Gui.setPosition(0, 640);

            this.fact = new PawnFactory();

            this.Turns = new TurnManager();
            foreach (Pawn a in pParty)
            {
                this.Turns.AddPawn(a);
            }
            this.Turns.AddPawn(fact.MakeBomb("Derpo"));
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
         * 
         * */
        private void LevelForm_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                if (this.selectedTile != null)
                {
                    Options options = this.Turns.getOptions(this.selectedTile);
                    if (options != null)
                        Console.WriteLine("move: " + options.canMove + " attack: " + options.canAttack + " special: " + options.canSpecial);
                    else
                        Console.WriteLine("no current pawn");
                }
            }
            else
            {
                this.selectedTile = Level.getTileAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                Actor a = new Floor("Highlight", 8);
                a.setImage(this.highlight);
                this.selectedTile.AddActor(a);
            }
            this.Refresh();
        }


        #region actor_delegates
        /**-------------------------------------SECTION for creating actor delegates ---------------------------------*/
        /**
         * Sets up all the actor delegates and adds them to the ActorFactory
         * @author Jakob Wilson
         * */
        private void createActorDelegates()
        {
            ActorFactory.actorMethod floorDel = createFloor;//create the actorMethod delegate
            ActorFactory.addActorMethod("Floor", floorDel); //add it to the Actor Factory

            ActorFactory.actorMethod wallDel = createWall;
            ActorFactory.addActorMethod("Wall", wallDel);
        }

        /**
         * Creates a floor actor
         * @see ActorFactory.actorMethod
         * @author Jakob Wilson
         * */
        public static Actor createFloor(XmlNode data)
        {
            Actor ret = new Floor("Floor", 0);
            ret.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            return ret;
        }


        /**
         * creates a wall actor
         * @see ActorFactory.actorMethod
         * @author Jakob Wilson
         * */
        public static Actor createWall(XmlNode data)
        {
            Actor ret = new Wall("Wall", 0);
            ret.setImage(Image.FromFile(data.SelectSingleNode("image").Attributes["source"].Value));
            return ret;
        }
        #endregion


    }
}
