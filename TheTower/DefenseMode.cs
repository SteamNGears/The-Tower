using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class DefenseMode
    {
        protected Pawn Owner;
        private List<string> Half;
        private List<string> None;
        private List<string> Absorb;
        public DefenseMode(Pawn owner)
        {
            this.Owner = owner;
            this.Half = new List<string>();
            this.None = new List<string>();
            this.Absorb = new List<string>();
        }
        public void AddHalf(string half)
        {
            this.Half.Add(half);
        }
        public void AddNone(string none)
        {
            this.None.Add(none);
        }
        public void AddAbsorb(string absorb)
        {
            this.Absorb.Add(absorb);
        }
        public int TakeDamage(Attack atk)
        {
            foreach(string t in atk.GetTypes())
            {
                if (Absorb.Contains(t))
                    return -atk.Power;
                if (None.Contains(t))
                    return 0;
                if (Half.Contains(t))
                    return atk.Power / 2;
            }
            return atk.Power;
        }

    }
}
