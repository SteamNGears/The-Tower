﻿using System;
using System.Windows.Forms;

namespace TheTower
{
    public class Grid
    {
        #region Member Variables and Ctor
        private Tile headTile;
        private int row;
        private int column;
        private int tileWidth;
        private int tileHeight;
        private int _offsetx;
        private int _offsety;

        public Grid()
        {
            this.headTile = null;
            this._offsetx = 0;
            this._offsety = 0;
        }

        #endregion

        #region Setters
        public void SetRow(int row)
        {
            this.row = row;
        }
        public void SetColumn(int column)
        {
            this.column = column;
        }
        public void SetHeadTile(Tile headTile)
        {
            this.headTile = headTile;
        }
        /**
         * Sets the offset of the grid for rendering
         * @author Jakob Wilson
         * */
        public void setPosition(int x, int y)
        {
            this._offsetx = x;
            this._offsety = y;
        }
        /*
         *  set data of a Tile at specific index
         */
        public void SetTile(Actor item, int rowIndex, int columnIndex)
        {
            Tile cur = this.GetTile(rowIndex, columnIndex);
            cur.AddActor(item);
            item.SetTile(cur);
        }

        /*
         *  create a grid system that have #row and #column
         */
        public void SetGrid(int row, int column)
        {
            this.row = row;
            this.column = column;
            int curRowIndex = -1;
            int curColumnIndex = -1;
            Tile lastTile = new Tile();
            for (int x = 0; x < row * column; x++)
            {
                Tile newTile = new Tile();
                if (this.headTile == null)      //if the grid is empty
                {
                    this.headTile = newTile;
                    lastTile = this.headTile;
                    curRowIndex++;
                    curColumnIndex++;
                    newTile.x = curRowIndex;
                    newTile.y = curColumnIndex;
                }
                else                            //if the grid is not empty
                {
                    if (curRowIndex == 0 && curColumnIndex < column - 1)    //if we are at the first row of the grid & not reaching column limit of that row
                    {
                        lastTile.ConnectRight(newTile);
                        lastTile = lastTile.right;
                        curColumnIndex++;
                        newTile.x = curRowIndex;
                        newTile.y = curColumnIndex;
                    }
                    else if (curColumnIndex == column - 1)                   //if we are reaching the column limit of the row
                    {
                        Tile upTile = GetTile(curRowIndex, 0);
                        newTile.ConnectUp(upTile);
                        if (upTile.left != null)
                            newTile.ConnectUpLeft(upTile.left);
                        if (upTile.right != null)
                            newTile.ConnectUpRight(upTile.right);
                        lastTile = newTile;
                        curColumnIndex = 0;
                        curRowIndex++;
                        newTile.x = curRowIndex;
                        newTile.y = curColumnIndex;
                    }
                    else if (curRowIndex > 0 && curColumnIndex < column - 1)     //other case
                    {
                        Tile upTile = (lastTile.up).right;
                        newTile.ConnectUp(upTile);
                        if (upTile.left != null)
                            newTile.ConnectUpLeft(upTile.left);
                        if (upTile.right != null)
                            newTile.ConnectUpRight(upTile.right);
                        lastTile.ConnectRight(newTile);
                        lastTile = lastTile.right;
                        curColumnIndex++;
                        newTile.x = curRowIndex;
                        newTile.y = curColumnIndex;
                    }
                }
            }
        }

        #endregion

        #region Getters
        public int GetRow()
        {
            return this.row;
        }
        public int GetColumn()
        {
            return this.column;
        }
        public Tile GetHeadTile()
        {
            return this.headTile;
        }
        /*
         *  return the Tile from the bottom left of the grid system 
         */
        public Tile GetLastTile()
        {
            Tile cur = this.headTile;
            while (cur.down != null)
            {
                cur = cur.down;
            }
            while (cur.right != null)
            {
                cur = cur.right;
            }
            return cur;
        }


        /*
         *  return the Tile base on the index
         */
        public Tile GetTile(int rowIndex, int columnIndex)
        {
            Tile cur = null;
            if (rowIndex < this.row && columnIndex < this.column)
            {
                cur = this.headTile;
                for (int x = 0; x < rowIndex; x++)
                    cur = cur.down;
                for (int y = 0; y < columnIndex; y++)
                    cur = cur.right;
            }
            else
                throw new IndexOutOfRangeException("You have walked off the grid with" + rowIndex + ", " + columnIndex);
            return cur;
        }
        public Tile getTileAt(int x, int y)
        {
            Tile ret = this.GetTile((int)x / this.tileWidth, (int)y / this.tileHeight);//SWITCH WHEN GRID IS FIXED

            return ret;
        }

#endregion

        #region Tile Width Height
        /*--------------GETTERS/SETTERS FOR TILE WIDTH/HEIGHT----------*/
        /** Sets the tile width for each tile*/
        public void setTileWidth(int width) { this.tileWidth = width; }

        /** Sets the tile height for each tile*/
        public void setTileHeight(int height) { this.tileHeight = height; }

        /** Gets the tile width for each tile*/
        public int getTileWidth() { return this.tileWidth; }

        /** Gets the tile width for each tile*/
        public int getTileHeight() { return this.tileHeight; }
        /*----------------------------------------------------------------*/
        #endregion

        #region Miscellaneous Methods
        /*
         *  print out the grid for testing
         */ 
        public void PrintGrid()
        {
            for(int x = 0; x < this.row; x++)
            {
                for(int y = 0; y < this.column; y++)
                {
                    Tile cur = this.GetTile(x,y);
                    if(cur.GetData().Count == 0)
                        Console.Write("null\t");
                    else
                        foreach (Actor a in cur.GetData())
                        {
                            Console.Write(a + "\t");
                        }
                }
                Console.WriteLine(); Console.WriteLine();  
            }
        }

        /**
         * Renders the entire by calling render on all moving right, then down
         * @NOTE The grid class has some issues with how tiles are tied together(right/down refs are messed up) so this patches by swapping right and up in double for looping
         * @author Jakob Wilson
         * * */
        #endregion

        #region Drawing
        public void render(PaintEventArgs e)
        {
            Tile t = this.headTile;
            int xPos = 0;
            int yPos = -this.tileHeight;

            for (Tile y = this.headTile; y != null; y = y.right)
            {
                xPos = 0;
                yPos += tileHeight;
                for (Tile x = y; x != null; x = x.down)
                {
                    x.render(e,xPos + this._offsetx,yPos + this._offsety);
                    xPos += tileWidth;///Make variable
                }
            }
        }
        #endregion

    }
}
