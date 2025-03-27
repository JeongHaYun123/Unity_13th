using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class TownNPC_VillageChief : TownNPC
    {
        public TownNPC_VillageChief(string name, int hpMax) : base(name, hpMax)
        {
        }

        public override char Symbol => '♀';

        public override ConsoleColor SymbolColor => ConsoleColor.DarkMagenta;

        public override void interaction(PC pc)
        {
            SaySomething();
        }

        public void SaySomething()
        {

        }
    }
}
