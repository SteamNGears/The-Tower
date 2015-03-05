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
        public LevelForm(Pawn[] pParty)//Add xml filename
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Visible = false;

            this.Party = pParty;
            playerTurn=0;

            //Create all the actor delegates and add them to the ActorFactory
            this.createActorDelegates();

            #region TestingStuff
            /* PFactory = new PawnFactory();

            Button panelButton;
            MenuItem menu;

            this.SuspendLayout();

            SelectGrid = new Panel[18, 16];

            for(int x = 0; x<SelectGrid.GetLength(0);x++)
            {
                for(int y = 0; y<SelectGrid.GetLength(1);y++)
                {
                    SelectGrid[x, y] = new Panel();

                    SelectGrid[x, y].ContextMenu = new ContextMenu();

                    menu = new MenuItem();
                    menu.Text = "Move";
                    menu.Click += new EventHandler(this.MoveClick);
                    SelectGrid[x, y].ContextMenu.MenuItems.Add(menu);
                    menu = new MenuItem();
                    menu.Text = "Attack";
                    menu.Click += new EventHandler(this.AttackClick);
                    SelectGrid[x, y].ContextMenu.MenuItems.Add(menu);
                    menu = new MenuItem();
                    menu.Text = "Special";
                    menu.Click += new EventHandler(this.SpecialClick);
                    SelectGrid[x, y].ContextMenu.MenuItems.Add(menu);

                    panelButton = new Button();
                    panelButton.Visible = false;
                    panelButton.Enabled = false;
                    panelButton.Name = "panelButton";
                    panelButton.BackgroundImage = Image.FromFile("png/MoveIndicator.png");
                    panelButton.BackgroundImageLayout = ImageLayout.Stretch;
                    panelButton.BackColor = Color.Transparent;
                    panelButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    panelButton.FlatStyle = FlatStyle.Flat;
                    panelButton.Size = new Size(64, 32);
                    panelButton.UseVisualStyleBackColor = false;
                    SelectGrid[x, y].Controls.Add(panelButton);

                    SelectGrid[x, y].Enabled = true;
                    SelectGrid[x, y].Location = new Point(y * 64, 64 + x * 32);
                    SelectGrid[x, y].Name = "" + x + "," + y;
                    SelectGrid[x, y].Size = new Size(64, 32);

                    SelectGrid[x, y].MouseEnter += new EventHandler(this.SelectGridEnter);
                    SelectGrid[x, y].MouseLeave += new EventHandler(this.SelectGridLeave);
                    //SelectGrid[x, y].MouseUp += new MouseEventHandler(this.SelectGridClick);

                    this.Controls.Add(SelectGrid[x, y]);
                }
            }
            //Assign map grid to this(also modify grid to have render() method
            Level = new Grid(); 
            Level.SetGrid(18, 16);  
            
            //Possibly have these defined in the .tmx
            Level.GetTile(17, 2).AddActor(Party[0]);
            Level.GetTile(17, 6).AddActor(Party[1]);
            Level.GetTile(17, 9).AddActor(Party[2]);
            Level.GetTile(17, 13).AddActor(Party[3]);

            //Not 100% sure what getButton does
            getButton(getPanel(Party[0].GetTile())).Text = Party[0].Name;
            getButton(getPanel(Party[1].GetTile())).Text = Party[1].Name;
            getButton(getPanel(Party[2].GetTile())).Text = Party[2].Name;
            getButton(getPanel(Party[3].GetTile())).Text = Party[3].Name;

            getButton(getPanel(Party[0].GetTile())).Visible = true;
            getButton(getPanel(Party[1].GetTile())).Visible = true;
            getButton(getPanel(Party[2].GetTile())).Visible = true;
            getButton(getPanel(Party[3].GetTile())).Visible = true;
            /**End map loading*/
            #endregion

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
        /*private void SelectGridClick(object sender,MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            CurSelection = panel;

            if (e.Button == MouseButtons.Right)
            {
                panel.ContextMenu.Show(panel, new Point(e.X, e.Y));
            }
        }*/
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


        #region actor_delegates
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
