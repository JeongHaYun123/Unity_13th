using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class PC : Character, IAttacker
    {
        // base 생성자 오버로드가 파라미터를 가진다면, 자식클래스는 생성자 오버로드를 정의하여 base 생성자의 파라미터에 인수를 전달하여야 한다.
        protected PC(string name, int hpMax, int attackForce)
            : base(name, hpMax)
        {
            AttackForce = attackForce;
        }


        public CharacterClass CurrentClass { get; private set; }

        public int AttackForce { get; private set; }


        public void Attack(IDamageable target)
        {
            target.Damage(this, AttackForce);
        }



        /* public PC(string name, string CharacterClass) : base(name, CharacterClass)
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
         }*/
    }
}
