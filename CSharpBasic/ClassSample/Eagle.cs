using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSample
{
    class Eagle : Bird
    {

        //public Eagle(String name)
        //{
        //    _name = name;
        //}

        //public Eagle()
        //{

        //}


        //public int AverageLifespan => _averageLifespan; //get 접근자
        //public string Name => _name;

        //int _averageLifespan;
        //string _name;

        //public void Fly()
        //{
        //    Console.WriteLine($"{this._name}(매), 날다");
        //}

        //public void Walk()
        //{
        //    Console.WriteLine($"{this._name}(매), 걷다");
        //}

        // base 키워드 : 기반타입 참조 키워드
        // 여기서는 Bird 의 멤버에 접근할 때 사용.
        public Eagle(string name) : base(name)
        {
        }

        public override int AverageLifespan => 10;
        //public override int AverageLifespan => _averLifeSpan;

        //private int _averLifeSpan = 10;

        public override void Fly()
        {
            Console.WriteLine($"{_name}(매), 날다"); //Bird 에서 _name 을 private 에서 protected 로 변경 (상속 받은 친구만 접근 가능)
        }

        public override void Walk()
        {
            Console.WriteLine($"{_name}(매), 걷다");
        }
    }
}
