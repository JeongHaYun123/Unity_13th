/*
 * 작성일 : 2025-03-17
 * 작성자 : 정하윤
 * 설명 : 첫 프로젝트.
 */

using System; //생략가능한 부분(원래는 생략됨) // using 키워드 : 특정 namespace를 현재 파일에 사용하겠다.

namespace FirstProject
{
    /// <summary>
    /// 프로그램 기본 정의
    /// </summary>
    internal class Program
    {
        // 키워드(예약어) : 시스템에 사용되기위해 예약된 단어로, 개발자가 임의로 사용할 수 없는 이름들이다. (파란색 단어)

        // static : 정적 키워드(예약어)
        // 런타임 중에 동적으로 할당 할 수 없다.
        // 변수를 선언할때는 얼마만큼의 메모리공간을 어떤 형태로 할당해서 사용할 것인지 명시를 해줘야 CPU 가 연산할 수 있다.

        // 352 = 10^2 * 3 + 10^1 * 5 + 10^0 +(*가 맞을 듯?) 2 = 352_10
        // 4 = 2^2 * 1 + 2^1 * 0 + 2^0 * 0 = 100_2 = 00000100_2
        // 3 =           2^1 * 1 + 2^0 * 1 = 011_2 = 00000011_2
        // 4 + 3 =                         = 111_2 = 7_10

        //char 'P' = 80_10 = 2^6 * 1 + 2^4 * 1 = 00000000 01010000_2

        // bit : 0 과 1의 2진수 표현 단위
        // byte : 정보 처리의 최소 단위. (8bit)

        // C#의 자료형들 : 
        static int _num1 = -4; // 4byte 부호 있는 정수형
        static uint _num2 = 2; // 4byte 부호 없는 정수형
        static short _num3; // 2byte 부호 있는 정수형
        static ushort _num4; // 2byte 부호 없는 정수형
        static long _num5; // 8byte 부호 있는 정수형
        static ulong _num6; // 8byte 부호 없는 정수형
        static float _num7; // 4byte 실수형
        static double _num8; // 8byte 실수형
        static bool _num9; // 1byte 논리형
        static char _char1; // 2byte 문자형 (ASCII 코드표에 따른 정수 취급)
        static string _string1; // 문자열형, 문자갯수 * 2byte + 1byte(null byte, 문자열의 끝을 명시)
        static object _object1; // 객체형, C#의 모든 자료형의 기반 타입.
        static byte _byte1; // 1byte

        // 이름 규칙
        // PascalCase
        // camelCase
        // snake_case
        // UPPER_SNAKE_CASE

        // 상수 이름 규칙은 공식 문서에서는 보통 PascalCase 권장. 근데 보통 UPPER_SNAKE_CASE 를 사용하여 가독성을 높힘
        // 정답은 없으나, 프로젝트 시작전에 정해놓고 모두가 그 규칙을 따라서 작성하면됨.
        const int MAX_CLIENTS = 10; //어퍼스네이크케이스
        static readonly float MaxHp; //static를 안하면 Main 함수 사용 불가능

        /// <summary>
        /// 프로그램 실행시 첫 진입점 함수
        /// </summary>
        /// <param name="args"> 프로그램 시작 옵션 </param>
        static void Main(string[] args)
        {
            _num1 = MAX_CLIENTS;
            _num1 = 1_000_000;
            _num7 = MaxHp;
            Console.Write("\'1\'\r");
            Console.Write("2\n");
            Console.WriteLine("Hello\t, World!"); // 출력문, 끝에 줄바꾸기 함
            Console.Write("3");
            Console.WriteLine("{1} {3} {2} {0} {0}", "정하윤", "My", "is", "name"); // 자리표시자
            Console.WriteLine(@"\'1\'\r"); // Verbatim 문자열 리터럴 (이스케이프시퀀스 무시)
            Console.WriteLine($"Max clients : {MAX_CLIENTS}"); // 문자열 보간 리터럴 (중괄호로 중간에 데이터 삽입)

            // 형변환
            // - 명시적 형변환 : 다른 자료형으로 취급해야한다고 명시해서 변환 (컴파일러가 안전하지 않다고 판단하는 경우)
            // 취급하는 값 종류는 동일하나 크기가 다를 경우에 큰 값을 작은 공간에 넣으려고한다면 이것은 데이터 소실 위험이 있으므로 명시적 변환 해야함.
            // 취급하는 값 종류가 다를경우도 데이터 소실 위험이 있음.
            int a = (int)314L; // 8byte 정수 데이터를 4byte 정수 공간에 대입하면 
            int b = (int)3.14f; // 4byte 실수데이터를 4byte 정수 공간에 대입하려면 소수부분 소실 위험 있음.
            // - 암시적 형변환 : 개발자가 따로 명시하지 않아도 연산과정에서 형변환이 일어나는 변환 (컴파일러가 안전하다고 판단하는 경우)
            // 취급하는 값 종류가 동일하고, 작은 값을 큰 공간에 넣으려고할때 <- 데이터의 승격(Promotion)
            long c = 14;
            double d = 3.14f;
        }
    }
}
