using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class PC : Character
    {
        //public CharacterClass CurrentClass { get; private set; }

        //public virtual void Attack();


        public PC(string name, string CharacterClass) : base(name, CharacterClass)
        {
        }

        public string currentClass
        {
            get { return CharacterClass; }
            private set { CharacterClass = value; }
        }

        public virtual void Smash()
        {

        }
        public virtual void Fireball()
        {

        }


        public void Attack()
        {
            if (currentClass == "Warrior")
            {
                Console.WriteLine("Warrior Attack");
                Smash();
            }
            else if (currentClass == "Magician")
            {
                Console.WriteLine("Magician Attack");
                Fireball();
            }
            else
            {
                Console.WriteLine($"{currentClass}이다");
            }
        }

    }

    class Warrior : PC
    {
        public Warrior(string name, string CharacterClass) : base(name, CharacterClass)
        {
        }

        public override void Smash()
        {
            Console.WriteLine("Smash");

        }
    }

    class Magician : PC
    {
        public Magician(string name, string CharacterClass) : base(name, CharacterClass)
        {
        }

        public override void Fireball()
        {
            Console.WriteLine("Fireball");
        }
    }
}
