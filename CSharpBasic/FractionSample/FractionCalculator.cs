using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FractionSample
{
    class FractionCalculator : IPrintable
    {
        public FractionCalculator(int capacity)
        {
            _fractions = new Fraction[capacity];
        }

        public int Capacity => _fractions.Length;

        private Fraction[] _fractions;
        private int _count;

        public Fraction InputFraction()
        {
            while (true)
            {
                Console.WriteLine("분수를 입력하세요. (분수/분모)");
                string input = Console.ReadLine();
                string[] splits = input.Split('/');

                if (splits.Length != 2)
                    continue;

                if (int.TryParse(splits[0], out int numberator) == false)
                    continue;

                if (int.TryParse(splits[1], out int denominator) == false)
                    continue;

                return new Fraction(numberator, denominator);
            }
        }

        public void AddFraction(Fraction fraction)
        {
            if (_count == _fractions.Length)
                throw new Exception("용량을 초과하였습니다.");

            _fractions[_count++] = fraction;
        }

        public void Print()
        {
            for (int i = 0; i < _count; i++)
            {
                _fractions[i].Print();
            }
        }

        public bool TryOperation(Fraction a, Fraction b, char operatorChar, out Fraction result)
        {
            try //try시 예외적인 상황 발생하면 개발자가 직접 핸들링 할 수 있다.
            {
                switch (operatorChar)
                {
                    case '+':
                        result = a + b;
                        break;
                    case '-':
                        result = a - b;
                        break;
                    case '*':
                        result = a * b;
                        break;
                    case '/':
                        result = a / b;
                        break;
                    default:
                        throw new ArgumentException($"{operatorChar} 는 연산가능한 입력이 아닙니다.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
                result = Fraction.Invalid;
                return false;
            }

            return true;

        }

        public void BoxingSimulation(Fraction a, Fraction b)
        {
            object obj1 = a;
            object obj2 = b;

            Console.WriteLine($"Boxed {a} {(obj1 == obj2 ? "==" : "!=")} Boxed {b}");
            Console.WriteLine($"Boxed {a} {(obj1.Equals(obj2) ? "equals" : "not equals")} Boxed {b}");
        }
    }
}
