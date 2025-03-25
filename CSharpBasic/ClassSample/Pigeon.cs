using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample
{
    class Pigeon : Bird
    {
        //public Pigeon(String name)
        //{
        //    _name = name;
        //}

        //public Pigeon()
        //{

        //}


        //public int AverageLifespan => _averageLifespan; //get 접근자
        //public string Name => _name;

        //int _averageLifespan;
        //string _name;

        //public void Fly()
        //{
        //    Console.WriteLine($"{this._name}(비둘기), 날다");
        //}

        //public void Walk()
        //{
        //    Console.WriteLine($"{this._name}(비둘기), 걷다");
        //}

        public Pigeon(string name) : base(name)
        {
        }

        public override int AverageLifespan => 15;

        private string _feature = "평화의 상징";

        public override void Fly()
        {
            Console.WriteLine($"{_name}(비둘기), 날다");
        }

        public override void Walk()
        {
            Console.WriteLine($"{_name}(비둘기), 걷다");
        }

        public override void PrintName()
        {
            base.PrintName();

            Console.WriteLine("구구구...");
        }
    }
}
