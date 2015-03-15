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
