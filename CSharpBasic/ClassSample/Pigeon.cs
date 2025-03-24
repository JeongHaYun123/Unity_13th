using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample
{
    class Pigeon
    {
        public Pigeon(String name)
        {
            _name = name;
        }

        public Pigeon()
        {

        }


        public int AverageLifespan => _averageLifespan; //get 접근자
        public string Name => _name;

        int _averageLifespan;
        string _name;

        public void Fly()
        {
            Console.WriteLine("비둘기, 날다");
        }

        public void Walk()
        {
            Console.WriteLine("비둘기, 걷다");
        }
    }
}
