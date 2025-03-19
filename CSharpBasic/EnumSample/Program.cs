/*
 * enum : 열거형 사용자정의 자료형을 정의하기위한 키워드
 */

namespace EnumSample
{
    enum State
    {
        None,
        Move,
        inAir,
        Attack,
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                State currentState = (State)Enum.Parse(typeof(State), Console.ReadLine()); //Eunm 클래스 : enum 타입 관련 편의 기능들을 가지고 있음.

                switch (currentState)
                {
                    case State.None:
                        Console.WriteLine("암것도안하는중...");
                        break;
                    case State.Move:
                        Console.WriteLine("이동중...");
                        break;
                    case State.inAir:
                        Console.WriteLine("공중에뜸...");
                        break;
                    case State.Attack:
                        Console.WriteLine("공격중...");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
