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
        private Pawn CurPawn;
        private AIController AITurn;
        private Queue<Pawn> TurnQueue;
        private bool turnDone;

        public TurnManager()
        {
            this.TurnQueue = new Queue<Pawn>();
            this.AITurn = new AIController();
            this.CurPawn = null;
            this.turnDone = true;
        }
        public Options getOptions(Tile tile)
        {
            if (CurPawn != null)
            {
                bool atk = false;
                bool move = false;
                bool spec = false;
                if (this.CurPawn.GetMoveRange().Contains(tile) && this.CurPawn.CanMove())
                    move = true;
                if (this.CurPawn.GetAttackRange().Contains(tile) && this.CurPawn.CanAttack())
                    atk = true;
                if (this.CurPawn.GetSpecialRange().Contains(tile) && this.CurPawn.CanSpecial())
                    spec = true;
                return new Options(move, atk, spec);
            }
            return null;
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
        private bool CleanQueue()
        {
            bool hasCreatures=false;
            int total=this.TurnQueue.Count;
            Pawn p;
            for(int i=0;i<total;i++)
            {
                p=this.TurnQueue.Dequeue();
                if(!p.Dead)
                {
                    if(p.GetTags().Contains("Creature"))
                        hasCreatures=true;
                    this.TurnQueue.Enqueue(p);
                }
            }
            return hasCreatures;
        }
        public int NextTurn()
        {
            if(this.turnDone==false)
            {
                return 0;
            }
            if(!CleanQueue())
            {
                Console.WriteLine("Level Over");
                return 1;
            }
            if(this.TurnQueue.Count>0)
            {
                this.CurPawn = TurnQueue.Dequeue();
                while(CurPawn.GetTags().Contains("Creature"))
                {
                    AITurn.SetPawn(CurPawn);
                    while(CurPawn.CanAct())
                    {
                        AITurn.ExecuteTurn();
                        //this.Level.Paint();
                    }
                    if (!CurPawn.Dead)
                        this.TurnQueue.Enqueue(CurPawn);
                    this.CurPawn = TurnQueue.Dequeue();
                }
            }
            this.turnDone = false;
            return 0;
        }
        public void DoSpecial(Tile tile)
        {
            if (CurPawn.GetSpecialRange().Contains(tile))
            {
                CurPawn.UseSpecial(tile);
                if (!CurPawn.CanAct())
                    turnDone = true;
            }
            else
            {
                Console.WriteLine("Cannot Special Here!");
            }
        }
        public void DoAttack(Tile tile)
        {
            if (CurPawn.GetAttackRange().Contains(tile))
            {
                CurPawn.UseAttack(tile);
                if (!CurPawn.CanAct())
                    turnDone = true;
            }
            else
            {
                Console.WriteLine("Cannot Attack Here!");
            }
        }
        public void DoMove(Tile tile)
        {
            if (CurPawn.GetMoveRange().Contains(tile))
            {
                CurPawn.MoveTo(tile);
                if (!CurPawn.CanAct())
                    turnDone = true;
            }
            else
            {
                Console.WriteLine("Cannot Move Here!");
            }
        }
    }
}
