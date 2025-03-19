namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //stack 영역에 메모리 할당
            int a = 14;
            int b = 6;
            int c = 0;

            // 산술 연산자
            // ---------------------------------------------------------------

            c = a + b; // 덧셈
            Console.WriteLine($"{a} + {b} = {c}");
            c = a - b; // 뺼셈
            Console.WriteLine($"{a} - {b} = {c}");
            c = a * b; // 곱셈
            Console.WriteLine($"{a} * {b} = {c}");
            c = a / b; // 나눗셈, 정수끼리 나누기 할경우 몫만 반환.
            Console.WriteLine($"{a} / {b} = {c}");
            c = a % b; // 나머지셈
            Console.WriteLine($"{a} % {b} = {c}");

            // 복합 대입 연산자
            // ---------------------------------------------------------------

            int tempC = c;
            c += a; // c = c + a;
            Console.WriteLine($"{tempC} + {a} = {c}");
            tempC = c;
            c -= a;
            Console.WriteLine($"{tempC} - {a} = {c}");
            tempC = c;
            c *= a;
            Console.WriteLine($"{tempC} * {a} = {c}");
            tempC = c;
            c /= a;
            Console.WriteLine($"{tempC} / {a} = {c}");
            tempC = c;
            c %= a;
            Console.WriteLine($"{tempC} % {a} = {c}");

            // 증감 연산자
            // ---------------------------------------------------------------
            /*
            c = 0;
            
            tempC = c;
            c = c + 1;
            Console.WriteLine(tempC);

            Console.WriteLine(c++);
            */
            c = 0;
            ++c; // c = c + 1, 전위연산, 결과값 반환
            c++; // c = c + 1, 후위연산, 원래값 반환
            --c; // c = c - 1
            c--; // c = c - 1
            // 요즘날에는 하드웨어 성능이 좋기때문에 굳이 후위연산의 성능을 따지지 않지만, 무거운 연산이라면 고려할수도 있다.
            // 보통 가독성때문에 후위 연산을 선호하는 경향이 있다. //기초적인 내용이라 면접 때 물어 보지는 않는다.

            // 관계 연산자
            // 논리값을 반환 (true or false)
            // ---------------------------------------------------------------

            bool result;
            result = a == b; // a 와 b 가 같으면 true, 아니면 false
            Console.WriteLine($"{a} = {b} : {result}");
            result = a != b; // a 와 b 가 다르면 true, 아니면 false
            Console.WriteLine($"{a} ≠ {b} : {result}");
            result = a > b; // a 가 b 보다 크면 true, 아니면 false
            Console.WriteLine($"{a} > {b} : {result}");
            result = a >= b; // a 가 b 보다 크거나 같다면 true, 아니면 false
            Console.WriteLine($"{a} ≥ {b} : {result}");
            result = a < b; // a 가 b 보다 작으면 true, 아니면 false
            Console.WriteLine($"{a} < {b} : {result}");
            result = a <= b; // a 가 b 보다 작거나 같다면 true, 아니면 false
            Console.WriteLine($"{a} ≤ {b} : {result}");

            // 논리 연산자
            // ---------------------------------------------------------------

            bool x1 = true;
            bool x2 = false;

            result = x1 & x2; // and 논리 연산, 둘 다 true 일때만 true 반환
            result = x1 | x2; // or 논리 연산, 둘 중 하나라도 true 이면 true 반환
            result = x1 ^ x2; // xor 논리 연산, 둘 중 한개만 true 이면 true 반환
            result = !x1; // not 논리 연산, 피연산자가 true 면 false, false 면 true 반환
            result = x1 == false; // not 논리 연산자가 가독성이 떨어지기때문에, false 비교연산으로 대체할 수 있다.

            // 조건부 논리 연산자
            // ---------------------------------------------------------------

            result = x1 && x2; // 왼쪽 피연산자 결과가 false 라면 바로 false 반환
            result = x1 || x2; // 왼쪽 피연산자 결과가 true 라면 바로 true 반환

            // 비트 연산자
            // ---------------------------------------------------------------

            // a == 14 == 0b... 00001110
            // b == 6  == 0b... 00000110

            // bit and
            // a & b   == 0b... 00000110 = 6
            c = a & b; //c = 6

            // bit or
            //a | b   == 0b... 00001110 = 14
            c = a | b; //c = 14

            // bit xor
            //a ^ b   == 0b... 00001000 = 8
            c = a ^ b; //c = 8
            //비트 연산자가 유니티 엔진에서 충돌 감지, 특정 레이어 제한에 사용된다. (플레이어 끼리 충돌은 안되지만, 플레이어 지형은 충돌 되게 할 때 사용)

            // bit not
            // ~a      == 0b11111111_11111111_11111111_11110001 = -15
            c = ~a; //c = -15

            // 2의 보수
            // 2진법 숫자 모두 반전후 + 1
            // 16 + (- 14) = 2
            // 0b00000000_00000000_00000000_00010000 = 16

            // 0b00000000_00000000_00000000_00001110 = 14
            // 0b10000000_00000000_00000000_00001110 = -14 // 그냥 젤 뒤에꺼 1로 부호 표현했을 때
            // 0b10000000_00000000_00000000_00011110 = -30
            // 0b11111111_11111111_11111111_11110010 = -14 // 2의 보수로 음수표현 했을때
            // 0b00000000_00000000_00000000_00000010 = 2 //넘어가면 오버플로우로 숫자가 사라짐

            // bit left shift 모든비트를 왼쪽으로 N칸 밀기
            c = a << 2; // 0b... 00111000 = 56
            // bit right shift 모든비트를 오른쪽으로 N칸 밀기
            c = a >> 3; // 0b... 00000001 = 1

            // 삼항 연산자
            // ? 왼쪽 값이 true 면 ':' 왼쪽 값 반환, 아니면 ':' 오른쪽 값 반환
            // 아주 간단한 if 문 대용으로 쓸수있지만
            // 아주아주 간단한내용아니면 가독성이 오히려 안좋아지기때문에 남용 하지 말것
            // ---------------------------------------------------------------

            if (c > 3)
            {
                c = 10;
            }
            else
            {
                c = 0;
            }

            c = c > 3 ? 10 : 0; //c 가 3보다 크면 10, 아니면 0

            // Null 병합 연산자
            // '??' 왼쪽 값이 null 이 아닐 경우 왼쪽값 반환, 아니면 오른쪽 값 반환.
            // ---------------------------------------------------------------

            string name = null;

            string label = name ?? "(Unknown)";
            Console.WriteLine(label);

            // Null Check 연산자
            // 대상이 Null 일경우 참조 호출 하지 않고 Null 반환
            // ---------------------------------------------------------------

            Console.WriteLine($"Length of name is {name?.Length ?? 0}");
        }
    }
}
