using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * abstract class (추상 클래스)
 * 추상화를 위한 클래스타입을 정의하는것이므로, 인스턴스화가 불가능하다.
 * 
 * 추상화를 할때에는, 하위에서 해당 멤버를 구현하지 않을 경우를 만들어서는 안되는것이 원칙
 */
namespace ClassSample
{
    abstract class Bird : Object
    {
        // 추상클래스에서도 생성자는 정의 가능하지만, 이 생성자를 직접 호출할수는 없다 ( new Bird(string name) 호출 안됨 )
        public Bird(string name)
        {
            _name = name;
        }

        public abstract int AverageLifespan { get; } // 평균수명에대한 멤버변수같은게 꼭 있을필요는 없는데 어쨋든 외부에서 평균수명을 읽는기능은 있어야함.

        public string Name => _name; // 추상클래스라고 해서 모든 기능을 추상화 해야하는것은 아니다

        protected string _name; // 이 클래스가 추상적이라고해도, 만약 이름이라는 데이터가 반드시 있어야한다면 멤버변수 정의가능. //이것은 추상화 개념이 아니다 (abstract 안 붙음), 대신 클래스가 추상화다.

        public abstract void Fly();

        public abstract void Walk();

        // virtual : 가상키워드
        // 구현부를 작성을 했으나, 자식이 재정의할수 있도록 명시하는 키워드
        public virtual void PrintName()
        {
            Console.WriteLine($"제 이름 : {_name} 입니다."); //자식이 재정의 안 하면 그대로 쓴다.
        }
    }
}
