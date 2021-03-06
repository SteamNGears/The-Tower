﻿using System;
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
        private Grid Overlay;       //a grid that lays over the leel grid for selection elements so they don't get drawn over by walls
        private Grid Gui;           //The gui grid(player cards)
        private Tile selectedTile;
        private Tile selectedGuiTile;
        private TileSelect selectionMenu;
        private TurnManager Turns;
        private string[] gameLevels;
        private int CurLevel;
        private PotionTile potions;


        //test
        //temporary
        //Image highlight = Image.FromFile("bitmap/HighlightViolet.png");
        public LevelForm(Pawn[] pParty)//Add xml filename
        {
            CurLevel = 0;
            gameLevels= new string[]{"Level1.tmx","Level2.tmx","Level3.tmx","Level4.tmx","Level5.tmx"};
            InitializeComponent();
            //enable double buffering
            this.DoubleBuffered = true;

            this.Visible = false;

            this.Party = pParty;

            //Create all the actor delegates and add them to the ActorFactory
            ActorDelegates.init();

        
            //create the level using the map factory

            this.Level = MapFactory.CreateMap(gameLevels[CurLevel]);
            this.Level.setPosition(0, 96);

            this.Overlay = new Grid();
            this.Overlay.SetGrid(this.Level.GetRow(), this.Level.GetColumn());
            this.Overlay.setTileWidth(this.Level.getTileWidth());
            this.Overlay.setTileHeight(this.Level.getTileHeight());
            this.Overlay.setPosition(0, 96);

            this.potions = new PotionTile();

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

            foreach(Actor a in this.Level.GetActorsByType("Creature"))
            {
                Pawn newPawn = (Pawn)a;
                this.Turns.AddPawn(newPawn);
            }
            this.selectedTile = null;


            this.Turns.NextTurn();


            this.Gui.SetTile(pParty[0].getCard(), 0, 0);
            this.Gui.SetTile(pParty[1].getCard(), 1, 0);
            this.Gui.SetTile(pParty[2].getCard(), 2, 0);
            this.Gui.SetTile(pParty[3].getCard(), 3, 0);


            //Add actors manualy
            Level.GetTile(2, 15).AddActor(pParty[0]);
            Level.GetTile(7, 15).AddActor(pParty[1]);
            Level.GetTile(12, 15).AddActor(pParty[2]);
            Level.GetTile(14, 15).AddActor(pParty[3]);

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
            this.Overlay.render(e);
            this.potions.Draw(e, 0, 64);
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
                    this.selectedGuiTile.RemoveActor(this.selectionMenu);
                
                this.selectedTile = Level.getTileAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                this.selectedGuiTile = Overlay.getTileAt(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

                if (this.selectedTile == null)
                    return;

                Options options = this.Turns.getOptions(this.selectedTile);
                
                if (options != null)
                {
                    this.selectionMenu = new TileSelect(options);
                    this.selectedGuiTile.AddActor(this.selectionMenu);
                }
                else
                    Console.WriteLine("no current pawn");
            }
            else if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                int sel;
                if (this.selectionMenu != null)
                {
                    sel = this.selectionMenu.click((MouseEventArgs)e);
                }
                else
                    sel = 0;
                switch (sel)
                {
                    case 1: if (this.Turns.DoAttack(this.selectedTile))
                            this.NextLevel();
                        break;
                    case 2: if (this.Turns.DoMove(this.selectedTile))
                            this.NextLevel();
                        break;
                    case 3: if (this.Turns.DoSpecial(this.selectedTile))
                            this.NextLevel();
                        break;
                }
                if (this.selectedTile != null)
                    this.selectedTile.RemoveActor(this.selectionMenu);

                int result = this.potions.click(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                
                //potion usage
                if (result == PotionTile.HEALTH)
                    potions.potions.UseHealthPotion(this.Turns.getCurrentTurn());
                if (result == PotionTile.AP)
                    potions.potions.UseApPotion(this.Turns.getCurrentTurn());
            }
            this.Refresh();
        }

        private void endTurn_Click(object sender, EventArgs e)
        {
            if (this.Turns.doNothing())
                this.NextLevel();
            this.Refresh();
        }
        private void NextLevel()
        {
            Console.WriteLine("Initiating next Level");

            bool gameOver=true;
            foreach(Pawn p in Party)
            {
                if(!p.Dead)
                    gameOver=false;
            }
            if (!gameOver)
            {
                this.selectedTile = null;
                this.Turns = new TurnManager();
                foreach (Pawn p in Party)
                {
                    p.SetHealth(p.MaxHealth);
                    p.ResetAP();
                    this.Turns.AddPawn(p);
                }
                this.CurLevel++;
                if (CurLevel == gameLevels.Length)
                {
                    MessageBox.Show("Final Level Finished!\nYou Win!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.Level = MapFactory.CreateMap(gameLevels[CurLevel]);
                    this.Level.setPosition(0, 96);
                    foreach (Actor a in this.Level.GetActorsByType("Creature"))
                    {
                        Pawn newPawn = (Pawn)a;
                        this.Turns.AddPawn(newPawn);
                    }

                    this.Turns.NextTurn();

                    Level.GetTile(2, 15).AddActor(Party[0]);
                    Level.GetTile(7, 15).AddActor(Party[1]);
                    Level.GetTile(12, 15).AddActor(Party[2]);
                    Level.GetTile(14, 15).AddActor(Party[3]);
                }

            }
            else
            {
                MessageBox.Show("You Lost!");
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
        }
    }
}
