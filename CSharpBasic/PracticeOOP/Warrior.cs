﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class Warrior : PC
    {
        public Warrior(string name, int hpMax, int attackForce) : base(name, hpMax, attackForce)
        {
        }

        public override char Symbol => 'ⓦ';

        public override ConsoleColor SymbolColor => ConsoleColor.DarkBlue;
        
        public void Smash()
        {

        }
    }
}
