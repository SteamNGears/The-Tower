using System;

using System.Collections.Generic;

namespace TheTower
{
    public class TurnManager
    {
        #region Member Variables, Ctor, and Getters/Setters
        private Pawn CurPawn;
        private PotionBelt potions;
        private Queue<Pawn> TurnQueue;
        //private bool turnDone;

        public TurnManager()
        {
            this.TurnQueue = new Queue<Pawn>();
            this.CurPawn = null;
            this.potions = new PotionBelt();
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
        //
        //Lucas Salom
        //Manages the selection of the current player / if its is a Creature, turn execution is automated
        public bool NextTurn()
        {
            if(CleanQueue())
            {
                return true;
            }
            if(this.TurnQueue.Count>0)
            {
                this.CurPawn = TurnQueue.Dequeue();
                if (this.CurPawn != null)
                    this.CurPawn.isTurn = true;
                while(CurPawn.hasTag("Creature"))
                {
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
                        return true;
                    }
                    this.CurPawn.isTurn = false;
                    this.CurPawn = TurnQueue.Dequeue();
                    this.CurPawn.isTurn = true;
                }
            }
            return false;
        }
        #endregion

        #region Actions

        public void UseHealthPotion()
        {
            this.potions.UseHealthPotion(CurPawn);
        }
        public void UseApPotion()
        {
            this.potions.UseApPotion(CurPawn);
        }
        public bool DoSpecial(Tile tile)
        {
            CurPawn.UseSpecial(tile);
            if (!CurPawn.CanAct() || this.CleanQueue())
            {
                return this.endTurn();
            }
            return this.isFinished();
        }
        public bool DoAttack(Tile tile)
        {
            CurPawn.UseAttack(tile);
            if (!CurPawn.CanAct() || this.CleanQueue())
            {
                return this.endTurn();
            }
            return this.isFinished();
        }
        public bool DoMove(Tile tile)
        {
            
            CurPawn.MoveTo(tile);
            if (!CurPawn.CanAct() || this.CleanQueue())
            {
                return this.endTurn();
            }
            return this.isFinished();
        }
        public bool doNothing()
        {
            return this.endTurn();
        }
        #endregion
       
        /**
         * Gets the actor whose turn it is. 
         * */
        public Pawn getCurrentTurn()
        {
            return this.CurPawn;
        }
        
        private bool endTurn()
        {
            this.CurPawn.isTurn = false;
            this.CurPawn.ResetAP();
            this.TurnQueue.Enqueue(CurPawn);
            return this.NextTurn();
        }
    }
}
