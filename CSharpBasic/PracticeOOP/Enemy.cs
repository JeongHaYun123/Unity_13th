using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class Enemy : NPC
    {
        protected Enemy(string name, int hpMax) : base(name, hpMax)
        {
        }
    }
}
