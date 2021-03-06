﻿using System.Collections.Generic;
using System;
namespace TheTower
{
    public abstract class Pawn : Actor
    {

        public Pawn(string name,int ID,int ap, int health, int speed, int power)
            : base(name,ID)
        {
            this.Dead=false;
            this.AP = ap;
            this.Health = health;
            this.Speed = speed;
            this.Power = power;
            this.MaxHealth = this.Health;
            this.AddTag("Pawn");
            this.Special = null;
            this.Move = null;
            this.Defense = null;
            this.Attack = null;
            this.MaxAP = this.AP;
            this.AddTag("Pawn");
            this.isTurn = false;
        }
        public int AP { get; private set; }
        public int MaxAP { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
	    public int Speed{ get; private set; }
        public int Power { get; private set; }
        public bool Dead { get; private set;}
        public bool isTurn;

        protected DefenseMode Defense;
        protected AttackMode Attack;
        protected MoveMode Move;
        protected SpecialMode Special;

        public void SetPower(int p)
        {
            this.Power = p;
        }
        public bool CanAttack()
        {
            return this.AP >= this.Attack.GetCost();
        }
        public bool CanMove()
        {
            return this.AP >= this.Move.GetCost();
        }
        public bool CanSpecial()
        {
            return this.AP >= this.Special.GetCost();
        }
        public bool CanAct()
        {
            return this.AP >= this.Move.GetCost() || this.AP >= this.Attack.GetCost() || this.AP >= this.Special.GetCost();
        }
        public void ResetAP()
        {
            this.AP = this.MaxAP;
        }
        public void RemoveAP(int ap)
        {
            this.AP -= ap;
            if (this.AP < 0)
                this.AP = 0;
        }
        public void SetHealth(int hp)
        {
            this.Health = hp;
            this.Dead = false;
            if (this.Health > this.MaxHealth)
                this.Health = this.MaxHealth;
            else if (this.Health < 0)
            {
                this.Health = 0;
                this.Dead = true;
            }
        }
        public void MoveTo(Tile target)
        {
            if (this.Move == null)
                return;
            this.Move.Move(target);
            if(this.CurTile.HasType("Trap"))
            {
                List<Trap> traps = new List<Trap>();
                foreach(Actor a in this.CurTile.GetData())
                {
                    if (a is Trap)
                        traps.Add((Trap)a);
                }
                foreach (Trap t in traps)
                    t.Act();
            }
        }
        public void UseAttack(Tile target)
        {
            if (this.Attack == null)
                return;
            this.Attack.Attack(target);
        }
        public void UseSpecial(Tile target)
        {
            if (this.Special == null)
                return;
            this.Special.Special(target);
        }
        public void TakeDamage(Attack atk)
        {
            if (this.Defense == null || this.Dead==true)
                return;
            this.RemoveHealth(this.Defense.TakeDamage(atk));
        }
        public int GetPower()
        {
            return this.Power;
        }
        private void RemoveHealth(int dmg)
        {
            Console.WriteLine(this.Name + " takes " + dmg + " damage!");
            this.Health -= dmg;
            if (this.Health <= 0)
            {
                this.Health = 0;
                this.Dead = true;
                Console.WriteLine(this.Name + " has died!");
            }
            else if(this.Health>this.MaxHealth)
            {
                this.Health = this.MaxHealth;
            }
        }

        public TileSet GetAdjacent()
        {
            TileSet adj = new TileSet();
            adj.Add(this.GetTile().up);
            adj.Add(this.GetTile().upRight);
            adj.Add(this.GetTile().upLeft);
            adj.Add(this.GetTile().down);
            adj.Add(this.GetTile().downRight);
            adj.Add(this.GetTile().downLeft);
            adj.Add(this.GetTile().left);
            adj.Add(this.GetTile().right);
            return adj;
        }
        public TileComposite GetMoveRange()
        {
            return this.Move.GetMoveRange();
        }
        public TileComposite GetAttackRange()
        {
            return this.Attack.GetAttackRange();
        }
        public TileComposite GetSpecialRange()
        {
            return this.Special.GetSpecialRange();
        }
        public void SetDefense(DefenseMode def)
        {
            this.Defense = def;
        }
        public void SetAttack(AttackMode atk)
        {
            this.Attack=atk;
        }
        public void SetMove(MoveMode move)
        {
            this.Move = move;
        }
        public void SetSpecial(SpecialMode special)
        {
            this.Special = special;
        }

        /**
         * gets a gui tile that the pawn draws its information to
         * */
        public Actor getCard()
        {
            return new PlayerCard(this);
        }

        public override string ToString()
        {
            String ret = "";
            ret += ("Name: " + this.Name + "\n");
            ret += ("Health: " + this.Health + "/" + this.MaxHealth + "\n");
            ret += ("Action Points: " + this.AP + "/" + this.MaxAP + "\n");
            ret += ("Power: " + this.Power + "\n");
            ret += ("Speed: " + this.Speed + "\n");
            ret += ("Special: " + this.Special.ToString() + "\n");
            return ret;

        }

    }
}
