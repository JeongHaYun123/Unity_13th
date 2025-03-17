/*
 * 작성일 : 2025-03-17
 * 작성자 : 정하윤
 * 설명 : 첫 프로젝트.
 */

using System; //생략가능한 부분(원래는 생략됨)

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

        /// <summary>
        /// 프로그램 실행시 첫 진입점 함수
        /// </summary>
        /// <param name="args"> 프로그램 시작 옵션 </param>
        static void Main(string[] args)
        {
            Console.Write("\'1\'\r");
            Console.Write("2\n");
            Console.WriteLine("Hello\t, World!"); // 출력문, 끝에 줄바꾸기 함
            Console.Write("3");
            Console.WriteLine("{1} {3} {2} {0} {0}", "정하윤", "My", "is", "name"); // 자리표시자
        }
    }
}
