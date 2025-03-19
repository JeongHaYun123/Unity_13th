/*
 * 변수의 형식
 * 값 형식     : 변수 할당한 메모리공간에 값을 쓰고 읽는 형식
 * 포인터 형식 : 변수 할당한 메모리공간에 다른 메모리 주소를 쓰고 읽는 형식
 * 참조 형식   : 변수의 별칭을 지정하는 형식, 변수 할당한 메모리공간에 다른 메모리 주소를 쓰고 읽긴 하지만, 
 * 개발자가 직접 메모리주소값을 신경쓰지않고, 해당 메모리주소의 데이터만 쓰고읽기함.
 * 
 * C# 은 개발자 편의를위해 기본적인 컨셉은 값과 참조형식만 사용하나, 
 * 포인터형식도 사용 가능하다.
 * 
 *  class :  객체를 설계한 사용자정의자료형
 *  객체 : 고유한 데이터 와 기능을 가진 단위
 */


using System.ComponentModel;

namespace MethodSample
{


    /*
    void main() //Code 영역 ( 컴파일 된 다음에 들어간다. ), main 함수 데이터는 stack에 들어간다.
    {
        int a = 3; // 값형식 변수
        string name = "Hi"; // 참조형식 변수
    }
    */

    class Human
    {
        /*
         * 클래스 내에서
         * 멤버 : 클래스가 포함하고있는 요소들
         * static 이 붙은 멤버 : 정적 멤버
         * static 이 안붙은 멤버 : 인스턴스 멤버
         */
        public Human(string name, int age)
        {
            _name = name;
            _age = age;
        }
        string _name; // 인스턴스 멤버 변수 : 객체 생성시 힙 영역에 할당할 변수 //Heap 할당할 때 BSS값 읽어서 Heap에 할당
        static int _age; // 정적 멤버 변수 : 힙영역에 할당하지않고 데이터(BSS) 영역에 직접 데이터를 쓰고 읽기 위한 변수 //BSS에 할당

        /// <summary>
        /// Non-Static(instance) method (인스턴스 멤버함수)
        /// 인스턴스 멤버함수 : 인스턴스 멤버들에 접근해서 연산을 수행하는 함수
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return _name;
        }
    }
    internal class Program
    {
        /// <summary>
        /// Main 함수는 static 함수이므로
        /// instance 멤버를 그냥 사용하지는 못한다.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 함수내 문자열 리터럴은 함수 호출때마다 동적할당 되는게 아니고, 어셈블리의 메타데이터와 함께 저장됨.
            // CLR 이 이 문자열 리터럴을 intern pool 에 로드해서 필요할때마다 참조해서 재사용함.
            // intern pool 은 Managed heap 영역에 할당됨.

            int num1 = 32341;
            Human human1 = new Human("정하윤", 320); //정하윤이라는 데이터를 가진 휴먼 데이터를 만들어서 휴먼1에 넣어줌
            string human1Name = human1.GetName();
            Console.WriteLine(human1Name);

            //Program program1 = new Program();
            //program1.Add(1, 2); //인스턴스 멤버함수 호출, int Add(int x, int y) 함수 호출
            num1 = Add(1, 2);

            // out 키워드 : 변수의 참조 전달, 보통 두개이상의 값을 반환해야하는 경우 사용 //unity에서 많이 사용
            if (TryReinforce(70.0, 30.0, 1, out int result)) //int 동시 선언해도 상관 없음
            {
                Console.WriteLine($"강화 성공! {result} 을(를) 획득했다..!");
            }
            else
            {
                Console.WriteLine($"강화 실패! 아이템이 파괴되었다..");
            }

            // ref 키워드 : 변수의 참조 전달, 이미 초기화 되어있는 변수의 값을 업데이트 해야할때 사용
            int a = 3;
            int b = 4;
            Swap(ref a, ref b);
            Console.WriteLine($"a : {a}, b : {b}");

            Factorial(5);
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        /*
         * 함수 오버로딩 (같은 이름의 함수를 정의할수있는 기능)
         * 이름이 같아도 파라미터가 다르면 다른 함수임.
         */
        static long AddOfLong(long x, long y)
        {
            return x + y;
        }

        /// <summary>
        /// 난수확률 시도함수
        /// </summary>
        /// <param name="percent"> 강화 성공 확률 0 ~ 100%, 성공시 +1 </param>
        /// <param name="greatPercent"> 강화 대성공 확률 0 ~ 100%, 대성공시 +2 </param>
        /// <param name="target"> 강화할 숫자 </param>
        /// <param name="result"> 강화된 후 결과 숫자 </param>
        /// <returns> 강화 성공여부, 강화실패시 숫자는 0으로 파괴됨 </returns>
        static bool TryReinforce(double percent, double greatPercent, int target, out int result)
        {
            Random random = new Random();

            // 강화 성공
            if (random.NextDouble() * 100 < percent)
            {
                // 강화 대성공
                if (random.NextDouble() * 100 < greatPercent)
                {
                    result = target + 2;
                }
                else
                {
                    result = target + 1;
                }

                return true;
            }
            // 강화 실패
            else
            {
                result = 0;
                return false;
            }
        }

        static void Swap(ref int a, ref int b) //ref : 참조전달, 함수내에서 a, b를 변경하면 원본도 변경됨
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
