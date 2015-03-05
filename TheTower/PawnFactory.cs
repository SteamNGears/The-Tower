using System;
using System.Collections.Generic;

namespace TheTower
{
    class PawnFactory
    {
        public int ID { get; private set; }
        public PawnFactory()
        {
            this.ID = 0;   
        }

        //Name, ID, AP, Health, Speed, Power, Attack, Move, Damage
        public Pawn MakeWarrior(string name)
        {
            Pawn war=new Pawn(name,ID++, 10, 25, 10, 10);
            war.AddTag("Warrior");
            war.AddTag("Hero");
            war.AddTag("Collidable");
            war.SetAttack(new AttackSlash(war));
            war.SetDefense(new DefenseMode(war));
            war.SetMove(new MoveGround(war));

            war.SetSpecial(new SpecialHeal(war));
            return war;
        }
        public Pawn MakeWraith(string name)
        {
            Pawn wraith = new Pawn(name, ID++, 10, 15, 10, 3);
            wraith.AddTag("Wraith");
            wraith.AddTag("Creature");

            wraith.SetAttack(new AttackFreeze(wraith));

            DefenseMode def = new DefenseMode(wraith);
            def.AddAbsorb("Ice");
            def.AddHalf("Slashing");
            def.AddHalf("Piercing");
            def.AddHalf("Blunt");
            wraith.SetDefense(def);

            wraith.SetMove(new MoveThrough(wraith));

            return wraith;
        }
        public Pawn MakeBomb(string name)
        {
            Pawn bomb=new Pawn(name,ID++, 7, 15, 8, 10);
            bomb.AddTag("Bomb");
            bomb.AddTag("Creature");
            bomb.AddTag("Collidable");

            bomb.SetAttack(new AttackBurn(bomb));

            DefenseMode def = new DefenseMode(bomb);
            def.AddAbsorb("Fire");
            bomb.SetDefense(def);

            bomb.SetMove(new MoveGround(bomb));

            bomb.SetSpecial(new SpecialExplode(bomb));

            return bomb;
        }
    }
}
