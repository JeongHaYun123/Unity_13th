using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class FractionCalculator
    {
        private Fraction[] fractions = new Fraction[4];
        private int count = 0;

        public void Make()
        {
            Console.Write("분자를 입력하세요 : ");
            int numberator = int.Parse(Console.ReadLine());
            Console.Write("분모를 입력하세요 : ");
            int dominator = int.Parse(Console.ReadLine());

            Fraction fraction = new Fraction(numberator, dominator);

            fraction = fraction.Reduce();
            Add(fraction);
            fraction.PrintInfo();
        }

        public void Add(Fraction fraction)
        {
            if (count >= fractions.Length)
            {
                throw new Exception("배열 허용량을 초과하였습니다.");
            }

            fractions[count] = fraction;
            count++;
        }

        public void PrintAll()
        {
            int arraycount = 0;
            while (arraycount < count)
            {
                fractions[arraycount].PrintInfo();
                arraycount++;
            }
        }

        public void PerformOperationValue()
        {
            Fraction fraction1 = new Fraction();
            Fraction fraction2 = new Fraction();

            Console.WriteLine("첫 번째 분수를 입력하세요.");
            Console.Write("분자 : ");
            int numberator = int.Parse(Console.ReadLine());
            Console.Write("분모 : ");
            int dominator = int.Parse(Console.ReadLine());
            Fraction fraction = new Fraction(numberator, dominator);
            fraction1 = fraction.Reduce();

            Console.WriteLine("두 번째 분수를 입력하세요.");
            Console.Write("분자 : ");
            numberator = int.Parse(Console.ReadLine());
            Console.Write("분모 : ");
            dominator = int.Parse(Console.ReadLine());
            fraction = new Fraction(numberator, dominator);
            fraction2 = fraction.Reduce();

            Console.WriteLine($"첫 번째 분모 : {fraction1._numberator}/{fraction1._dominator}");
            Console.WriteLine($"두 번째 분모 : {fraction2._numberator}/{fraction2._dominator}");

            PerformOperations(fraction1, fraction2);
        }
        public void PerformOperations(Fraction fraction1,  Fraction fraction2)
        {
            Console.WriteLine("연산자 +, -, *, / 중에서 하나를 입력해 주세요.");
            string op = Console.ReadLine();
            Fraction fraction = new Fraction();
            switch (op)
            {
                case "+":
                     fraction = fraction1 + fraction2;
                    Console.WriteLine($"두 분수의 합은 {fraction._numberator}/{fraction._dominator}입니다.");
                    break;
                case "-":
                    fraction = fraction1 - fraction2;
                    Console.WriteLine($"두 분수의 뺼셈은 {fraction._numberator}/{fraction._dominator}입니다.");
                    break;
                case "*":
                    fraction = fraction1 * fraction2;
                    Console.WriteLine($"두 분수의 곱셈은 {fraction._numberator}/{fraction._dominator}입니다.");
                    break;
                case "/":
                    fraction = fraction1 / fraction2;
                    Console.WriteLine($"두 분수의 나눗셈은 {fraction._numberator}/{fraction._dominator}입니다.");
                    break;
                default:
                    break;
            }
        }

        public void PerformEqual()
        {
            Fraction fraction1 = new Fraction();
            Fraction fraction2 = new Fraction();

            Console.WriteLine("첫 번째 분수를 입력하세요.");
            Console.Write("분자 : ");
            int numberator = int.Parse(Console.ReadLine());
            Console.Write("분모 : ");
            int dominator = int.Parse(Console.ReadLine());
            Fraction fraction = new Fraction(numberator, dominator);
            fraction1 = fraction.Reduce();

            Console.WriteLine("두 번째 분수를 입력하세요.");
            Console.Write("분자 : ");
            numberator = int.Parse(Console.ReadLine());
            Console.Write("분모 : ");
            dominator = int.Parse(Console.ReadLine());
            fraction = new Fraction(numberator, dominator);
            fraction2 = fraction.Reduce();

            Console.WriteLine($"첫 번째 분모 : {fraction1._numberator}/{fraction1._dominator}");
            Console.WriteLine($"두 번째 분모 : {fraction2._numberator}/{fraction2._dominator}");

            Console.Write("연산자 ==, != 중에서 하나를 입력해 주세요 : ");
            string op = Console.ReadLine();
            switch (op)
            {
                case "==":
                    if (fraction1 == fraction2)
                        Console.WriteLine("두 분수는 같습니다.");
                    else
                        Console.WriteLine("두 분수는 같지 않습니다.");
                        break;
                case "!=":
                    if (fraction1 != fraction2)
                        Console.WriteLine("두 분수는 다릅니다.");
                    else
                        Console.WriteLine("두 분수는 다르지 않습니다.");
                        break;
                default:
                    break;
            }
        }

        public void PerformBit()
        {
            Console.WriteLine("분수를 입력하세요.");
            Console.Write("분자 : ");
            int numberator = int.Parse(Console.ReadLine());
            Console.Write("분모 : ");
            int dominator = int.Parse(Console.ReadLine());
            Fraction fraction = new Fraction(numberator, dominator);
            fraction = fraction.Reduce();
            fraction = ~fraction;
            Console.WriteLine($"분자 비트 반전 : {fraction._numberator}/{fraction._dominator} 입니다.");
        }
    }
}
