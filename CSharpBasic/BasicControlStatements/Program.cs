namespace BasicControlStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // if 문 (조건에 논리값이 들어감)
            // ---------------------------------------------------------------

            // if 의 조건이 참일 경우에만 구현부 실행.
            //if (조건1)
            //{
            //    // 조건1이 참일때 실행할 내용
            //}
            //else if (조건2)
            //{
            //    // 조건1이 거짓이고 조건 2가 참일떄 실행할 내용
            //}
            //else
            //{
            //    // 상위 조건드링 모두 거짓일때 실행할 내용
            //}

            int a = 3;

            // 주석 여기쓰는거임
            if (a == 3) // 주석 여기쓰는거아님
                Console.WriteLine("a 가 3이라는데요?");

            // if 문의 구현부는 라인이 하나라면 중괄호 생략가능 하지만
            // 만약 else if / else 문이 따라 붙으면서 중괄호로 구현부가 정의되었다면 라인이 하나라도 중괄호 생략하지 않는게 원칙

            // 다음처럼 쓰지 말라는거임. else 문은 중괄호 썼잖음? //제3자가 봤을 때 깔끔하게
            if (a < 3)
                Console.WriteLine("a 가 3보다 작다는데요?");
            else
            {
                if (a > 3)
                {
                    Console.WriteLine("a 가 3보다 크다는데요?");
                }
                else
                {
                    Console.WriteLine("a 가 3이라는데?");
                }
            }

            int b = 4;

            // Switch 문
            // ---------------------------------------------------------------

            string food = Console.ReadLine();

            switch (food)
            {
                case "Pizza":
                    {
                        Console.WriteLine($"{food} (은)는 20분 가량 소요됩니다.");
                        break; // break 믄 : 현재 구문을 빠져나오는 구문
                    }
                case "Hamburger":
                case "Pasta":
                    {
                        Console.WriteLine($"{food} (은)는 주문 가능합니다.");
                        break; // break 믄 : 현재 구문을 빠져나오는 구문
                    }
                default:
                    {
                        Console.WriteLine($"{food} (은)는 주문 불가능합니다.");
                        break;
                    }
            }


            // for 반복문
            // ---------------------------------------------------------------

            //for (반복 시작전에 실행할 연산; 반복구문을 실행하기위한 조건; 반복구문 완료후 실행할 연산)
            //{
            //
            //}

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"카운팅.. {i}");
            }

            // 무한반복문
            //for (;;)
            //{
            //
            //}

            for (int j = 2; j <= 9; j++)
            {
                Console.Write($"   {j} 단  \t");
            }

            Console.WriteLine();

            for (int i = 1; i <= 9; i++)
            {

                for (int j = 2; j <= 9; j++)
                {
                    Console.Write($"{j} * {i} = {j * i}\t");
                }

                Console.WriteLine();
            }

            int sum = 0;

            // 3의 배수 제외한 합
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    continue;
                }

                sum += i;
            }

            // while 반복문
            // 조건이 참일경우 반복
            // ---------------------------------------------------------------

            int count = 0;
            while (count < 5)
            {
                Console.WriteLine($"카운팅.. {count}");
                count++;
            }

            int evenSum = 0;
            count = 1;

            while (count <= 100)
            {
                // 짝수 검증
                if (count % 2 == 0)
                {
                    evenSum += count;
                }

                count++;
            }

            Console.WriteLine($"1 ~ 100 짝수합 : {evenSum}");

            // 피보나치 수열 : n = (n - 1) + (n - 2)
            //컨트롤 + R 2번누르면 변수 전체 바꾸기 가능

            int n = 1;
            int n_1 = 0;
            Console.Write("피보나치수열 : ");

            while (n <= 20)
            {
                Console.Write($"{n},");
                int next = n + n_1;
                n_1 = n;
                n = next;
            }

            // 일단 한번 실행하고 반복 조건 체크하여 반복함
            // 가독성이 좋은편은 아니고 대부분 그냥 while 문으로 해결 가능하므로, 특수한 알고리즘을 작성해야하는 경우들 말고는 잘 안씀
            do
            {

            } while (false);

        N003:
            int errorCode = int.Parse(Console.ReadLine()); //문자열 정수형으로  변환

            if (errorCode == -1)
            { 
                goto N001;
            }
            else if (errorCode == -2)
            {
                goto N002;
            }
            else
            {
                goto N003;
            }

        N001:
            Console.WriteLine("Error 1");

        N002:
            Console.WriteLine("Error 2");
        }
    }
}
