using System;
using System.Collections.Generic;

namespace TheTower
{
    public class Pawn : Actor
    {

        public Pawn(string name, int id,int ap, int health, int speed, int power)
            : base(name, id)
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
        }
        public Controller Owner { get; private set; }
        public int AP { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
	    public int Speed{ get; private set; }
        public int Power { get; private set; }
        public bool Dead { get; private set;}

        private DefenseMode Defense;
        private AttackMode Attack;
        private MoveMode Move;
        private SpecialMode Special;

        public void SetHealth(int hp)
        {
            this.Health = hp;
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

        public override Actor clone()
        {
            throw new NotImplementedException("Need to add a clone method to pawn");
        }

    }
}
