﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheTower
{
    /**
     * Lucas Salom
     * Structure Subclass - Trap
     * No Collision
     * Performs an action upon being touched
     */
    public abstract class Trap : Structure
    {
        protected TrapAction Action;
        private bool activated;
        public Trap(string name, int id, int power)
            : base(name, id)
        {
            this.activated = false;
            this.Power = power;
        }
        public int Power { get; private set; }
        public int GetPower()
        {
            return this.Power;
        }
        public override Actor clone()
        {
            return this;
        }

        /**
         * Lucas Salom
         * Executes the Traps specified action upon being touched.
         */
        public void checkState()
        {
            if(!this.activated && this.GetTile().HasType("Pawn"))
            {
                this.Act();
            }
        }
        private void Act()
        {
            this.activated = true;
            this.Action.Act();
        }
    }
}