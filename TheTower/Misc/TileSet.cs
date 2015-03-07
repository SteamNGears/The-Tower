using System;
using System.Collections;
using System.Collections.Generic;

namespace TheTower
{
	public class TileSet : ICollection, IEnumerable, TileComposite
	{
        private List<Tile> set;
		public TileSet()
		{
            set = new List<Tile>();
		}
        public bool Contains(Tile that)
        {
            foreach(Tile tile in this.set)
            {
                if (tile.Equals(that))
                    return true;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public TileSetEnum GetEnumerator()
        {
            return new TileSetEnum(set);
        }
		public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }
        public object SyncRoot
        {
            get
            {
                return null;
            }
        }
        public int Count
		{
			get
			{
                return set.Count;
			}
		}
		public bool Empty
		{
			get
			{
                return set.Count == 0;
			}
		}
		public Tile this[int index]
		{
			get
			{
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index too high!");
                else if (index < 0)
                    throw new IndexOutOfRangeException("Index too low!");
                return (Tile)set[index];
			}
		}
		public bool Contains(object o)
		{
            foreach (Tile that in set)
                if (that.Equals(o))
                    return true;
            return false;
		}
		public bool Add(Tile o)
		{
            foreach (Tile that in set)
                if (that.Equals(o))
                    return false;
            set.Add(o);
            return true;
		}
		public bool Remove(Tile o)
		{
            if(set.Contains(o))
            {
                set.Remove(o);
                return true;
            }
            return false;
		}
		public override bool Equals(object o)
		{
            TileSet thatSet=(TileSet)o;
            if(thatSet.Count != set.Count)
                return false;
			foreach(Tile that in thatSet)
            {
                if (!(set.Contains(that)))
                    return false;
            }
            return true;
		}
		public override int GetHashCode()
		{
            int total=0;
            foreach (Tile o in set)
                total += o.GetHashCode();
            return total;
		}
		public override string ToString()
		{
            string setString = "[ ";
            int first = 1;
		    foreach(Tile o in set)
            {
                if (first == 1)
                {
                    setString += o.ToString();
                    first = 0;
                }
                else
                    setString += " , " + o.ToString();
          
            }
            setString += " ]";
            return setString;

		}
        public void CopyTo(Array array, int index)
        {
            object[] newArray = new object[set.Count - index];
            for(int i=0;i<set.Count-index;i++)
            {
                newArray[i] = set[i + index];
            }
            newArray.CopyTo(array,0);
        }

        public void ApplyDamage(Attack atk)
        {
            foreach(Tile t in set)
            {
                t.ApplyDamage(atk);
            }
        }
	}

    public class TileSetEnum : IEnumerator
    {
        public List<Tile> set;
        int position = -1;
        public TileSetEnum(List<Tile> pSet)
        {
            this.set=pSet;
        }
        public bool MoveNext()
        {
            position++;
            return (position < set.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public object Current
        {
            get
            {
                try
                {
                    return set[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
