using System;
using System.Collections.Generic;

namespace TheTower
{
    /**
     * Lucas Salom
     * Hero Factory
     * Contains Constructor references for each Hero PC type.
     */
    public class HeroFactory
    {
        #region Factory Methods
        public Pawn MakeBomb(String name)
        {
            Pawn bomb = new Pawn(name, 3, 7, 15, 8, 10);
            bomb.setImage(TheTower.Properties.Resources.hero1_50x50);
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
        //Name, ID, AP, Health, Speed, Power, Attack, Move, Damage
        public Pawn MakeWarrior(string name)
        {
            return new Warrior(name);
        }
        public Pawn MakePaladin(string name)
        {
            return new Paladin(name);
        }
        public Pawn MakeVampireHero(string name)
        {
            return new VampireHero(name);
        }
        public Pawn MakeShaolinMonk(string name)
        {
            return new ShaolinMonk(name);
        }
        public Pawn MakeWizzard(string name)
        {
            return new Wizzard(name);
        }
        public Pawn MakeElf(string name)
        {
            return new Elf(name);
        }
        public Pawn MakeNinja(string name)
        {
            return new Ninja(name);
        }
        public Pawn MakeMissWorld(string name)
        {
            return new MissWorld(name);
        }
        #endregion
    }
}
