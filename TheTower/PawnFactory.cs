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

            wraith.SetSpecial(new SpecialSneakAttack(wraith));
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

        /*
         *  **INCOMPLETED**
         * 
         *  Make Hydra
         *  3 heads monster
         *  each head have it own attack point
         *  cut one head down and 50% chance it might grow back
         *  need to cut down all head to be killed         * 
         */
        public Pawn MakeHydra(string name)
        {
            Pawn hydra = new Pawn(name, ID++, 5, 50, 10, 10);
            hydra.AddTag("Hydra");
            hydra.AddTag("Creature");
            hydra.AddTag("Collidable");


            return hydra;
        }

        /*
         *  Make skeleton
         *  minor monster
         *  normal attack: close range attack (chop)
         *  special attack: high range attack (rock throwing)         *  
         */
        public Pawn MakeSkeleton(string name)
        {
            Pawn skeleton = new Pawn(name, ID++, 7, 15, 8, 10);
            skeleton.AddTag("Skeleton");
            skeleton.AddTag("Creature");
            skeleton.AddTag("Collidable");

            skeleton.SetAttack(new AttackChop(skeleton));
            skeleton.SetSpecial(new SpecialRockThrowing(skeleton));
            skeleton.SetDefense(new DefenseMode(skeleton));
            skeleton.SetMove(new MoveGround(skeleton));
            return skeleton;
        }

        /*
        *  make vampire (monster side)
        *  Immute to Ice
        *  normal attack: slash
        *  special Vampire Bite
        */
        public Pawn MakeVampireMonster(string name)
        {
            Pawn vampire = new Pawn(name, ID++, 10, 30, 11, 10);
            vampire.AddTag("Vampire");
            vampire.AddTag("Creature");
            vampire.AddTag("Collidable");
            DefenseMode def = new DefenseMode(vampire);
            def.AddNone("Ice");
            vampire.SetDefense(def);
            vampire.SetMove(new MoveGround(vampire));

            vampire.SetAttack(new AttackSlash(vampire));
            vampire.SetSpecial(new SpecialVampireBite(vampire));

            return vampire;
        }


        /*
         *  make vampire (hero side)
         *  Immute to Ice
         *  normal attack: slash
         *  special Vampire Bite
         */
        public Pawn MakeVampireHero(string name)
        {
            Pawn vampire = new Pawn(name, ID++, 10, 30, 11, 10);
            vampire.AddTag("Vampire");
            vampire.AddTag("Hero");
            vampire.AddTag("Collidable");
            DefenseMode def = new DefenseMode(vampire);
            def.AddNone("Ice");
            vampire.SetDefense(def);
            vampire.SetMove(new MoveGround(vampire));

            vampire.SetAttack(new AttackSlash(vampire));
            vampire.SetSpecial(new SpecialVampireBite(vampire));

            return vampire;
        }



        

        

        /*
         *  Make Shaolin Monk
         *  Immute to Fire
         *  normal attack: slash
         *  special skill: sacrify haft his heatlh to quadruple  his attacking point
         */
        public Pawn MakeShaolinMonk(string name)
        {
            Pawn shaolinMonk = new Pawn(name, ID++, 10, 23, 13, 9);
            shaolinMonk.AddTag("Shaolin Monk");
            shaolinMonk.AddTag("Hero");
            shaolinMonk.AddTag("Collidable");
            shaolinMonk.SetAttack(new AttackSlash(shaolinMonk));
            DefenseMode def = new DefenseMode(shaolinMonk);
            def.AddNone("Fire");
            shaolinMonk.SetDefense(def);           
            shaolinMonk.SetMove(new MoveGround(shaolinMonk));
            shaolinMonk.SetSpecial(new SpecialSacrifice(shaolinMonk));

            return shaolinMonk;
        }

        /*
         *  Make wizzard
         *  normal attack: wizzard stick
         *  special skill: healing
         */
        public Pawn MakeWizzard(string name)
        {
            Pawn wizzard = new Pawn(name, ID++, 10, 15, 10, 10);
            wizzard.AddTag("Wizzard");
            wizzard.AddTag("Hero");
            wizzard.AddTag("Collidable");
            wizzard.SetAttack(new AttackWizzardStick(wizzard));
            wizzard.SetDefense(new DefenseMode(wizzard));
            wizzard.SetMove(new MoveGround(wizzard));
            wizzard.SetSpecial(new SpecialHeal(wizzard));

            return wizzard;
        }

        

        /*
         *  Make elf
         *  Hero type
         *  get half damage from ice, fire
         *  normal attack: close range attack (chop)
         *  special attack: very high range attack (bow) but low damage          
         */
        public Pawn MakeElf(string name)
        {
            Pawn elf = new Pawn(name, ID++, 7, 15, 8, 10);
            elf.AddTag("Elf");
            elf.AddTag("Hero");
            elf.AddTag("Collidable");

            elf.SetAttack(new AttackChop(elf));
            elf.SetSpecial(new SpecialBow(elf));
            DefenseMode def = new DefenseMode(elf);
            def.AddHalf("Ice");
            def.AddHalf("Fire");

            elf.SetDefense(def);
            elf.SetMove(new MoveGround(elf));
            return elf;
        }

        /*
         *  Make ninja
         *  Hero type
         *      low health 
         *      high action point
         *  normal attack: close range attack (chop)
         *  special attack: high damage sneak attack (sneakAttack)
         *  sneak attack successful rate: 25%
         */
        public Pawn MakeNinja(string name)
        {
            Pawn ninja = new Pawn(name, ID++, 15, 15, 15, 8);
            ninja.AddTag("Ninja");
            ninja.AddTag("Hero");
            ninja.AddTag("Collidable");

            ninja.SetAttack(new AttackSlash(ninja));
            ninja.SetSpecial(new SpecialSneakAttack(ninja));
            ninja.SetDefense(new DefenseMode(ninja));

            ninja.SetMove(new MoveGround(ninja));
            return ninja;
        }


        /*
         *  Miss World
         *  Hero type
         *      low health 
         *      low action point
         *  normal attack: smile : do 1 point of damage no matter what
         *  special attack: cheer leader : 
         *      restore target health by number of power point
         *      power point will decrease after perform special
         */
        public Pawn MakeMissWorld(string name)
        {
            Pawn missWorld = new Pawn(name, ID++, 10, 10, 5, 15);
            missWorld.AddTag("Miss World");
            missWorld.AddTag("Hero");
            missWorld.AddTag("Collidable");

            missWorld.SetAttack(new AttackSmile(missWorld));
            missWorld.SetSpecial(new SpecialCheerLeader(missWorld));
            missWorld.SetDefense(new DefenseMode(missWorld));

            missWorld.SetMove(new MoveGround(missWorld));
            return missWorld;
        }
        
    }
}
