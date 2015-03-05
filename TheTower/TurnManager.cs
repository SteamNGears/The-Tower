using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TheTower
{
    public class TurnManager
    {
        private Queue<Pawn> TurnQueue;

        public TurnManager()
        {
            this.TurnQueue = new Queue<Pawn>();
        }
        public bool isFinished()
        {
            return this.TurnQueue.Count == 0;
        }
        public void AddPawn(Pawn p)
        {
            if(!p.Dead)
                this.TurnQueue.Enqueue(p);
        }
        public Pawn NextTurn()
        {
            try
            {
                Pawn CurPawn = TurnQueue.Dequeue();
                while (CurPawn.Dead)
                    CurPawn = TurnQueue.Dequeue();
                return CurPawn;
                
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("Queue is empty");
                return null;
            }
        }
    }
}
