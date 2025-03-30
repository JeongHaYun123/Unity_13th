using Fraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction_
{
    class Program
    {
        static void Main(string[] args)
        {
            FractionCalculator fractioncalculator = new FractionCalculator();

            while (true)
            {
                Console.WriteLine("1 : 새 분수 입력,  2 : 연산 수행, 3 : 분수 비교, 4 : 비트 연산 데모, 5 : 저장된 모든 분수 출력, 6 : 프로그램 종료");
                Console.Write("메뉴를 입력하세요 : ");
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        fractioncalculator.Make();
                        Console.WriteLine("아무 키나 입력하시면 원래 메뉴로 되돌아갑니다.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        fractioncalculator.PerformOperationValue();
                        Console.WriteLine("아무 키나 입력하시면 원래 메뉴로 되돌아갑니다.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        fractioncalculator.PerformEqual();
                        Console.WriteLine("아무 키나 입력하시면 원래 메뉴로 되돌아갑니다.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        fractioncalculator.PerformBit();
                        Console.WriteLine("아무 키나 입력하시면 원래 메뉴로 되돌아갑니다.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        fractioncalculator.PrintAll();
                        Console.WriteLine("아무 키나 입력하시면 원래 메뉴로 되돌아갑니다.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("종료하겠습니다.");
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
