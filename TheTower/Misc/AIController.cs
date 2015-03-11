﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    public class AIController
    {
        private Pawn AIPawn;
        private Tile Target;
        private bool isValidTarget;
        public AIController()
        {
            this.AIPawn = null;
            this.Target = null;
            this.isValidTarget = false;
        }
        public void SetPawn(Pawn p)
        {
            this.Target = null;
            this.isValidTarget = false;
            this.AIPawn = p;
        }
        public void ExecuteTurn()
        {
            this.isValidTarget = false;
            if(this.Target!=null)
                foreach (Actor a in this.Target.GetData())
                {
                    if ((a as Pawn).GetTags().Contains("Hero") && !(a as Pawn).Dead)
                    {
                        this.isValidTarget = true;
                    }
                }
            if(!this.isValidTarget)
                this.SearchForTarget(20);// 20 == search range
            if(!this.isValidTarget)
            {
                this.Target = null;
                this.AIPawn.RemoveAP(this.AIPawn.AP);
            }
            else
            {
                if (!this.AIPawn.GetAttackRange().Contains(Target))
                {
                    StepTowardsTarget();
                }
                else
                {
                    AttackTarget();
                }
            }
        }
        private void AttackTarget()
        {
            if(this.AIPawn.CanAttack())
            {
                this.AIPawn.UseAttack(this.Target);
            }
            else
            {
                this.AIPawn.RemoveAP(this.AIPawn.AP);
            }
        }
        private void StepTowardsTarget()
        {
            double smallestDistance=0.0;
            Tile BestMovement = null;

            foreach(Tile T in (TileSet)this.AIPawn.GetMoveRange())
            {
                if (smallestDistance == 0.0)
                {
                    smallestDistance = CalculateDistance(T, this.Target);
                    BestMovement = T;
                }
                else
                {
                    double curDistance = CalculateDistance(T, this.Target);
                    if (curDistance < smallestDistance)
                    {
                        smallestDistance = curDistance;
                        BestMovement = T;
                    }
                }
            }
            this.AIPawn.MoveTo(BestMovement);
        }
        private double CalculateDistance(Tile T1, Tile T2)
        {
            return Math.Sqrt(Math.Pow((T1.x-T2.x),2)+Math.Pow(T1.y-T2.y,2));
        }
        private void SearchForTarget(int range)
        {
            Tile Origin = this.AIPawn.GetTile();

            if (range > 2)
            {
                if (Origin.upLeft != null)
                {
                    SearchRangeHelper(Origin.upLeft, range - 3);
                }
                if (Origin.upRight != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.upRight, range - 3);
                }
                if (Origin.downLeft != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.downLeft, range - 3);
                }
                if (Origin.downRight != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.downRight, range - 3);
                    
                }
                if (Origin.up != null && this.Target == null)
                {
                     SearchRangeHelper(Origin.up, range - 2);
                   
                }
                if (Origin.down != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.down, range - 2);
                }
                if (Origin.left != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.left, range - 2);
                }
                if (Origin.right != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.right, range - 2);
                }
            }
            else if (range == 2)
            {
                if (Origin.up != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.up, range - 2);
                }
                if (Origin.down != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.down, range - 2);
                }
                if (Origin.left != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.left, range - 2);
                }
                if (Origin.right != null && this.Target == null)
                {
                    SearchRangeHelper(Origin.right, range - 2);
                }
            }
        }
        private void SearchRangeHelper(Tile Origin, double range)
        {
            if(Origin.HasType("Hero"))
            {
                foreach (Actor a in Origin.GetData())
                {
                    if (!(a as Pawn).Dead)
                    {
                        this.Target = Origin;
                        this.isValidTarget = true;
                        return;
                    }
                }
            }
            if (range > 2)
            {
                if (Origin.upLeft != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.upLeft, range - 3);
                }
                if (Origin.upRight != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.upRight, range - 3);
                }
                if (Origin.downLeft != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.downLeft, range - 3);
                }
                if (Origin.downRight != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.downRight, range - 3);
                }
                if (Origin.up != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.up, range - 2);
                }
                if (Origin.down != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.down, range - 2);
                }
                if (Origin.left != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.left, range - 2);
                }
                if (Origin.right != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.right, range - 2);
                }
            }
            else if (range == 2)
            {
                if (Origin.up != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.up, range - 2);
                }
                if (Origin.down != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.down, range - 2);
                }
                if (Origin.left != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.left, range - 2);
                }
                if (Origin.right != null && this.Target==null)
                {
                    SearchRangeHelper(Origin.right, range - 2);
                }
            }
        }
    }
}