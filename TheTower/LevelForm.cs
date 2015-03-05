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
        private Grid Level;
        //private PawnFactory PFactory;
        private int playerTurn;

        //temporary
        Image highlight = Image.FromFile("bitmap/HighlightViolet.png");
        public LevelForm(Pawn[] pParty)//Add xml filename
        {
            InitializeComponent();
            //enable double buffering
            this.DoubleBuffered = true;

            this.Visible = false;

            this.Party = pParty;
            playerTurn=0;

            //Create all the actor delegates and add them to the ActorFactory
            this.createActorDelegates();

        
            //create the level using the map factory
            this.Level = MapFactory.CreateMap("Level1.tmx");

            //Add actors manualy
            Level.GetTile(2, 12).AddActor(pParty[0]);
            Level.GetTile(7, 12).AddActor(pParty[1]);
            Level.GetTile(12, 12).AddActor(pParty[2]);
            Level.GetTile(14, 12).AddActor(pParty[3]);


            Lbl_Turn.Text = "Current Turn: " + Party[playerTurn].Name + "!";

            this.Refresh();
            this.ResumeLayout();
            this.Show();
        }
        private void SpecialClick(object sender, EventArgs e)
        {
            Panel CurSelection = ((Panel)((ContextMenu)((MenuItem)sender).Parent).SourceControl);
            Tile CurTile = getTile(CurSelection);
            if (Party[playerTurn].GetSpecialRange().Contains(CurTile))
            {
                Party[playerTurn].UseSpecial(CurTile);
                playerTurn = (playerTurn + 1) % 4;
                Lbl_Turn.Text = "Current Turn: " + Party[playerTurn].Name + "!";
            }
            else
            {
                Console.WriteLine("Cannot Attack Here!");
            }
        }
        private void AttackClick(object sender, EventArgs e)
        {
            Panel CurSelection = ((Panel)((ContextMenu)((MenuItem)sender).Parent).SourceControl);
            Tile CurTile = getTile(CurSelection);
            if (Party[playerTurn].GetAttackRange().Contains(CurTile))
            {
                Party[playerTurn].UseAttack(CurTile);
                playerTurn = (playerTurn + 1) % 4;
                Lbl_Turn.Text = "Current Turn: " + Party[playerTurn].Name + "!";
            }
            else
            {
                Console.WriteLine("Cannot Attack Here!");
            }
        }
        private void MoveClick(object sender, EventArgs e)
        {
            Panel CurSelection = ((Panel)((ContextMenu)((MenuItem)sender).Parent).SourceControl);
            Tile CurTile = getTile(CurSelection);
            if(Party[playerTurn].GetMoveRange().Contains(CurTile))
            {
                getButton(getPanel(Party[playerTurn].GetTile())).Text = "";
                getButton(getPanel(Party[playerTurn].GetTile())).Visible = false;
                Console.WriteLine(Party[playerTurn].Name + " moves to " + CurTile.x + ", " + CurTile.y);
                Party[playerTurn].MoveTo(CurTile);
                getButton(CurSelection).Visible = true;
                getButton(CurSelection).Text = Party[playerTurn].Name;
                playerTurn=(playerTurn+1)%4;
                Lbl_Turn.Text = "Current Turn: " + Party[playerTurn].Name + "!";
            }
            else
            {
                Console.WriteLine("Cannot Move Here!");
            }
        }

        private void SelectGridLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            Console.WriteLine("LEAVE");
            if(getButton(panel).Text.Equals(""))
            {
                getButton(panel).Visible = false;
            }
        }
        private void SelectGridEnter(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            Console.WriteLine("ENTER");
            (panel.Controls.Find("panelButton", false)[0]).Visible = true;
        }
        private Panel getPanel(Tile tile)
        {
            string key = ""+tile.x+","+tile.y;

            Control[] panels =this.Controls.Find(key,false);


            return (Panel)this.Controls.Find(key,false)[0];
        }
        private Tile getTile(Panel panel)
        {
            string[] xy = panel.Name.Split(',');
            return Level.GetTile(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));
        }
        private Button getButton(Panel panel)
        {
            return (Button)panel.Controls.Find("panelButton", false)[0];
        }


        /**
         * Calls render when the form is to be repainted
         * @author Jakob Wilson
         * */
        private void LevelForm_Paint(object sender, PaintEventArgs e)
        {
            this.Level.render(e);
        }


        /**
         * 
         * */
        private void LevelForm_Click(object sender, EventArgs e)
        {
            Tile cur = Level.getTileAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            Actor a = new Floor("Highlight", 8);
            a.setImage(this.highlight);
            cur.AddActor(a);
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
