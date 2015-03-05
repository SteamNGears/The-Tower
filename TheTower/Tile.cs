using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheTower
{
    public class Tile : TileComposite
    {
        public int x;
        public int y;
        public Tile up { get; set; }
        public Tile upLeft { get; set; }
        public Tile upRight { get; set; }
        public Tile downLeft { get; set; }
        public Tile downRight { get; set; }
        public Tile right { get; set; }
        public Tile down { get; set; }
        public Tile left { get; set; }
        private List<Actor> Actors;

        public Tile()
        {
            this.up = null;
            this.down = null;
            this.left = null;
            this.right = null;
            this.upLeft = null;
            this.upRight = null;
            this.downLeft = null;
            this.downRight = null;
            this.Actors = new List<Actor>();
        }
        public bool HasType(string Type)
        {
            foreach (Actor a in Actors)
            {
                if (a.GetTags().Contains(Type))
                    return true;
            }
            return false;
        }
        public bool Contains(Tile that)
        {
            return this.Equals(that);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object o)
        {
            try
            {
                Tile that = (Tile)o;
                return this.x == that.x && this.y == that.y;
            }
            catch { return false; }
        }
        public void RemoveActor(Actor o)
        {
            this.Actors.Remove(o);
        }
        public void AddActor(Actor o)
        {
            //MessageBox.Show("Assign actor: " + o.Name);
            if (o != null)
            {
                this.Actors.Add(o);
                o.SetTile(this);
            }
        }

        public List<Actor> GetData()
        {
            return this.Actors;
        }
        public void ConnectDown(Tile down)
        {
            this.down = down;
            down.up=this;
        }

        public void ConnectUp(Tile up)
        {
            this.up = up;
            up.down = this;
        }
        public void ConnectDownLeft(Tile downl)
        {
            this.downLeft = downl;
            downl.upRight = this;
        }

        public void ConnectUpLeft(Tile upl)
        {
            this.upLeft = upl;
            upl.downRight = this;
        }
        public void ConnectDownRight(Tile downr)
        {
            this.downRight = downr;
            downr.upLeft = this;
        }

        public void ConnectUpRight(Tile upr)
        {
            this.upRight = upr;
            upr.downLeft = this;
        }

        public void ConnectRight(Tile right)
        {
            this.right = right;
            right.left = this;
        }

        public void ConnectLeft(Tile left)
        {
            this.left = left;
            left.right = this;
        }

        public override string ToString()
        {
            return this.GetData().ToString();
        }
        public TileSet GetMoveRange(int range)
        {
            TileSet rangeList = new TileSet();

            if (range > 2)
            {
                if (this.upLeft != null && !this.upLeft.HasCollidable())
                {
                    rangeList.Add(this.upLeft);
                    this.upLeft.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.upRight != null && !this.upRight.HasCollidable())
                {
                    rangeList.Add(this.upRight);
                    this.upRight.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.downLeft != null && !this.downLeft.HasCollidable())
                {
                    rangeList.Add(this.downLeft);
                    this.downLeft.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.downRight != null && !this.downRight.HasCollidable())
                {
                    rangeList.Add(this.downRight);
                    this.downRight.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.up != null && !this.up.HasCollidable())
                {
                    rangeList.Add(this.up);
                    this.up.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.down != null && !this.down.HasCollidable())
                {
                    rangeList.Add(this.down);
                    this.down.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.left != null && !this.left.HasCollidable())
                {
                    rangeList.Add(this.left);
                    this.left.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.right != null && !this.right.HasCollidable())
                {
                    rangeList.Add(this.right);
                    this.right.MoveRangeHelper(rangeList, range - 2);
                }
            }
            else if(range==2)
            {
                if (this.up != null && !this.up.HasCollidable())
                {
                    rangeList.Add(this.up);
                    this.up.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.down != null && !this.down.HasCollidable())
                {
                    rangeList.Add(this.down);
                    this.down.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.left != null && !this.left.HasCollidable())
                {
                    rangeList.Add(this.left);
                    this.left.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.right != null && !this.right.HasCollidable())
                {
                    rangeList.Add(this.right);
                    this.right.MoveRangeHelper(rangeList, range - 2);
                }
            }
            return rangeList;
        }
        public TileSet GetRange(int range)
        {
            TileSet rangeList = new TileSet();

            if (range > 2)
            {
                if (this.upLeft != null)
                {
                    rangeList.Add(this.upLeft);
                    this.upLeft.RangeHelper(rangeList, range - 3);
                }
                if (this.upRight != null)
                {
                    rangeList.Add(this.upRight);
                    this.upRight.RangeHelper(rangeList, range - 3);
                }
                if (this.downLeft != null)
                {
                    rangeList.Add(this.downLeft);
                    this.downLeft.RangeHelper(rangeList, range - 3);
                }
                if (this.downRight != null)
                {
                    rangeList.Add(this.downRight);
                    this.downRight.RangeHelper(rangeList, range - 3);
                }
                if (this.up != null)
                {
                    rangeList.Add(this.up);
                    this.up.RangeHelper(rangeList, range - 2);
                }
                if (this.down != null)
                {
                    rangeList.Add(this.down);
                    this.down.RangeHelper(rangeList, range - 2);
                }
                if (this.left != null)
                {
                    rangeList.Add(this.left);
                    this.left.RangeHelper(rangeList, range - 2);
                }
                if (this.right != null)
                {
                    rangeList.Add(this.right);
                    this.right.RangeHelper(rangeList, range - 2);
                }
            }
            else if (range == 2)
            {
                if (this.up != null)
                {
                    rangeList.Add(this.up);
                    this.up.RangeHelper(rangeList, range - 2);
                }
                if (this.down != null)
                {
                    rangeList.Add(this.down);
                    this.down.RangeHelper(rangeList, range - 2);
                }
                if (this.left != null)
                {
                    rangeList.Add(this.left);
                    this.left.RangeHelper(rangeList, range - 2);
                }
                if (this.right != null)
                {
                    rangeList.Add(this.right);
                    this.right.RangeHelper(rangeList, range - 2);
                }
            }
            return rangeList;
        }
        private void RangeHelper(TileSet rangeList, double range)
        {
            if (range > 2)
            {
                if (this.upLeft != null)
                {
                    rangeList.Add(this.upLeft);
                    this.upLeft.RangeHelper(rangeList, range - 3);
                }
                if (this.upRight != null)
                {
                    rangeList.Add(this.upRight);
                    this.upRight.RangeHelper(rangeList, range - 3);
                }
                if (this.downLeft != null)
                {
                    rangeList.Add(this.downLeft);
                    this.downLeft.RangeHelper(rangeList, range - 3);
                }
                if (this.downRight != null)
                {
                    rangeList.Add(this.downRight);
                    this.downRight.RangeHelper(rangeList, range - 3);
                }
                if (this.up != null)
                {
                    rangeList.Add(this.up);
                    this.up.RangeHelper(rangeList, range - 2);
                }
                if (this.down != null)
                {
                    rangeList.Add(this.down);
                    this.down.RangeHelper(rangeList, range - 2);
                }
                if (this.left != null)
                {
                    rangeList.Add(this.left);
                    this.left.RangeHelper(rangeList, range - 2);
                }
                if (this.right != null)
                {
                    rangeList.Add(this.right);
                    this.right.RangeHelper(rangeList, range - 2);
                }
            }
            else if (range == 2)
            {
                if (this.up != null)
                {
                    rangeList.Add(this.up);
                    this.up.RangeHelper(rangeList, range - 2);
                }
                if (this.down != null)
                {
                    rangeList.Add(this.down);
                    this.down.RangeHelper(rangeList, range - 2);
                }
                if (this.left != null)
                {
                    rangeList.Add(this.left);
                    this.left.RangeHelper(rangeList, range - 2);
                }
                if (this.right != null)
                {
                    rangeList.Add(this.right);
                    this.right.RangeHelper(rangeList, range - 2);
                }
            }
        }
        private void MoveRangeHelper(TileSet rangeList, double range)
        {
            if (range > 2)
            {
                if (this.upLeft != null && !this.upLeft.HasCollidable())
                {
                    rangeList.Add(this.upLeft);
                    this.upLeft.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.upRight != null && !this.upRight.HasCollidable())
                {
                    rangeList.Add(this.upRight);
                    this.upRight.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.downLeft != null && !this.downLeft.HasCollidable())
                {
                    rangeList.Add(this.downLeft);
                    this.downLeft.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.downRight != null && !this.downRight.HasCollidable())
                {
                    rangeList.Add(this.downRight);
                    this.downRight.MoveRangeHelper(rangeList, range - 3);
                }
                if (this.up != null && !this.up.HasCollidable())
                {
                    rangeList.Add(this.up);
                    this.up.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.down != null && !this.down.HasCollidable())
                {
                    rangeList.Add(this.down);
                    this.down.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.left != null && !this.left.HasCollidable())
                {
                    rangeList.Add(this.left);
                    this.left.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.right != null && !this.right.HasCollidable())
                {
                    rangeList.Add(this.right);
                    this.right.MoveRangeHelper(rangeList, range - 2);
                }
            }
            else if (range == 2)
            {
                if (this.up != null && !this.up.HasCollidable())
                {
                    rangeList.Add(this.up);
                    this.up.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.down != null && !this.down.HasCollidable())
                {
                    rangeList.Add(this.down);
                    this.down.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.left != null && !this.left.HasCollidable())
                {
                    rangeList.Add(this.left);
                    this.left.MoveRangeHelper(rangeList, range - 2);
                }
                if (this.right != null && !this.right.HasCollidable())
                {
                    rangeList.Add(this.right);
                    this.right.MoveRangeHelper(rangeList, range - 2);
                }
            }
        }
        public bool HasCollidable()
        {
            foreach (Actor o in Actors)
                if (o.GetTags().Contains("Collidable"))
                    return true;
            return false;
        }

        public void ApplyDamage(Attack atk)
        {
            foreach(Actor a in Actors)
            {
                if(a.GetTags().Contains("Pawn"))
                {
                    Pawn target = (Pawn)a;
                    target.TakeDamage(atk);
                }
            }
        }


        /**
         * renders all the layers in this tile by calling draw on each actor
         * @author Jakob Wilson
         * @see Actor.Draw()
         * */
        public void render(PaintEventArgs e, int x, int y)
        {
           
            foreach (Actor a in this.Actors)
            {
                a.Draw(e, x, y);
            }
        }
    }
}
