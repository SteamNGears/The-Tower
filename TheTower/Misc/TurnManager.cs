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
        #region Member Variables, Ctor, and Getters/Setters
        private Pawn CurPawn;
        private Queue<Pawn> TurnQueue;
        //private bool turnDone;

        public TurnManager()
        {
            this.TurnQueue = new Queue<Pawn>();
            this.CurPawn = null;
           // this.turnDone = true;
        }
        public void AddPawn(Pawn p)
        {
            if (!p.Dead)
                this.TurnQueue.Enqueue(p);

        }
        #endregion
        
        #region Helper Methods
        /**
         * Lucas Salom
         * Returns Current Active Pawn's ability to act on specified tile.
         */
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
        private bool CleanQueue()
        {
            int total=this.TurnQueue.Count;
            Pawn p;
            for(int i=0;i<total;i++)
            {
                p=this.TurnQueue.Dequeue();
                if(!p.Dead)
                {
                    this.TurnQueue.Enqueue(p);
                }
            }
            return isFinished();
        }
        private bool isFinished()
        {
            bool hasCreatures = false;
            bool hasPlayers=false;

            foreach(Pawn p in this.TurnQueue)
            {
                if (p.hasTag("Hero"))
                    hasPlayers = true;
                if (p.hasTag("Creature"))
                    hasCreatures = true;
            }
            if(CurPawn!=null && !CurPawn.Dead)
            {
                if (CurPawn.hasTag("Creature"))
                    hasCreatures = true;
                else if (CurPawn.hasTag("Hero"))
                    hasPlayers = true;
            }
            return !(hasCreatures && hasPlayers);
        }
        #endregion

        #region Turn Logic
        public bool NextTurn()
        {
            if(CleanQueue())
            {
                Console.WriteLine("Level Over");
                return false;
            }
            if(this.TurnQueue.Count>0)
            {
                this.CurPawn = TurnQueue.Dequeue();
                while(CurPawn.hasTag("Creature"))
                {
                    this.CurPawn.isTurn = true;
                    
                    Creature AIPawn = (Creature)this.CurPawn;
                    while(AIPawn.CanAct())
                    {
                        AIPawn.GetController().ExecuteTurn();
                    }
                    if (!CurPawn.Dead)
                    {
                        this.CurPawn.ResetAP();
                        this.TurnQueue.Enqueue(CurPawn);
                    }
                    if (CleanQueue())
                    {
                        Console.WriteLine("Level Over");
                        return false;
                    }

                    this.CurPawn.isTurn = false;
                    this.CurPawn = TurnQueue.Dequeue();
                    this.CurPawn.isTurn = true;
                }

            }
            return true;
        }
        #endregion

        #region Actions
        public bool DoSpecial(Tile tile)
        {
            if (CurPawn.GetSpecialRange().Contains(tile))
            {
                CurPawn.UseSpecial(tile);
                if (!CurPawn.CanAct())
                {
                    return this.endTurn();
                }
            }
            else
            {
                Console.WriteLine("Cannot Attack Here!");
            }
            return this.isFinished();
        }
        public bool DoAttack(Tile tile)
        {
            if (CurPawn.GetAttackRange().Contains(tile))
            {
                CurPawn.UseAttack(tile);
                if (!CurPawn.CanAct())
                {
                    return this.endTurn();
                }
            }
            else
            {
                Console.WriteLine("Cannot Attack Here!");
            }
            return this.isFinished();
        }
        public bool DoMove(Tile tile)
        {
            if (CurPawn.GetMoveRange().Contains(tile))
            {
                CurPawn.MoveTo(tile);
                if (!CurPawn.CanAct())
                {
                    return this.endTurn();
                }
            }
            else
            {
                Console.WriteLine("Cannot Move Here!");
            }
            return this.isFinished();
        }
        public bool doNothing()
        {
            return this.endTurn();
        }
        #endregion
        private bool endTurn()
        {
            this.CurPawn.isTurn = false;
            this.CurPawn.ResetAP();
            this.TurnQueue.Enqueue(CurPawn);
            return this.NextTurn();
        }
    }
}
