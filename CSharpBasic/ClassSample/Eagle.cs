using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample
{
    class Eagle
    {
        public Eagle(String name)
        {
            _name = name;
        }

        public Eagle()
        {

        }


        public int AverageLifespan => _averageLifespan; //get 접근자
        public string Name => _name;

        int _averageLifespan;
        string _name;

        public void Fly()
        {
            Console.WriteLine("매, 날다");
        }

        public void Walk()
        {
            Console.WriteLine("매, 걷다");
        }
    }
}
