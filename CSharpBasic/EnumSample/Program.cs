/*
 * enum : 열거형 사용자정의 자료형을 정의하기위한 키워드
 */

namespace EnumSample
{
    /*
     * C# 의 enum 타입은 기본적으로 int 값으로 취급
     * enum 정의시 0 값 자리는 의미없는 default 로 설정함. ( idle, None, Nothing, Default .. 등등)
     */
    enum State : ushort //천 단위까지 가능, 일반적인 열거형은 단수 비트 열거형은 복수
    {
        None,
        Move,
        inAir,
        Attack = 100,
        Skill1,
        Skill2,
    }

    [Flags] // 현재 enum 의 ToString() 으로 문자열 반환하는 함수에서 모든 플래그의 요소들을 문자열로 바꿔주는 특성을 부여
    enum Layers
    {
        Nothing       = 0 << 0, // 0b... 00000000 // 0b... 00000000   //0번 째는 의미 없는 걸로 채우는게 원칙 ( 아무것도 안 했는데 그라운드 되기 좀 그래서 0번째는 아무것도 안하는걸로 채움 )
        Ground        = 1 << 0, // 0b... 00000001 // 0b... 00000001   //비트 플래그를 사용하지 않으면 연산 값이 이상하게 나온다 ( Ground + Enemy = Player 가 나옴 )
        Enemy         = 1 << 1, // 0b... 00000010 // 0b... 00000010
        Player        = 1 << 2, // 0b... 00000100 // 0b... 00000011
        Interactable  = 1 << 3, // 0b... 00001000 // 0b... 00000100
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Layers targetLayer = Layers.Enemy | Layers.Interactable;

            Layers collisionLayerMask = Layers.Ground | Layers.Enemy;

            // 충돌가능
            if ((targetLayer & collisionLayerMask) > 0)
            {
                // 충돌 처리
            }

            //Console.WriteLine(Layers.Ground.ToString());
            //Console.WriteLine((Layers.Ground | Layers.Enemy).ToString());

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
