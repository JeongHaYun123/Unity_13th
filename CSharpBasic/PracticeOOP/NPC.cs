using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace PracticeOOP
{
    abstract class NPC
    {
    }

    abstract class TownNPC : NPC
    {
        public virtual void Interaction(PC pc)
        {

        }
    }

    class TownNPC_VillageChief : TownNPC
    {
        public override void Interaction(PC pc)
        {
            SaySomething();
        }

        public void SaySomething()
        {
            Console.WriteLine("Welcome to the village!");
        }
    }

    abstract class Enemy : NPC
    {
        public virtual void Attack(Character player)
        {
            Attack(player);
        }
    }

    class Slime : Enemy
    {
    }

    class Mushroom : Enemy
    {
        public override void Attack(Character player)
        {
            Console.WriteLine("Mushroom Attack");
            Console.WriteLine("take damage 10");
            player.Hp -= 10;
        }
    }
}
