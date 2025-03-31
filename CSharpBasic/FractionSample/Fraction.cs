using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionSample
{
    struct Fraction : IPrintable
    {
        public Fraction(int numberator, int denominator)
        {
            if (denominator == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("분모는 0 이 될 수 없습니다. 분모를 1로 정정합니다.");
                Console.ResetColor();
                denominator = 1;
            }

            Numberator = numberator;
            Denominator = denominator;
        }

        public static Fraction Invalid => new Fraction { Numberator = 0, Denominator = 0 };

        public int Numberator; // 분자
        public int Denominator; // 분모


        public Fraction Reduce()
        {
            int gcd = GCD();

            if (gcd != 0)
                return new Fraction(Numberator / gcd, Denominator / gcd);

            return this;
        }

        /// <summary>
        /// 최대공약수
        /// </summary>
        /// <returns></returns>
        int GCD()
        {
            int a = Math.Abs (Numberator);
            int b = Math.Abs (Denominator);
            int temp;

            if (a < b)
            {
                temp = b;
                a = b;
                b = temp;
            }

            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public void Print()
        {
            Console.WriteLine($"{Numberator}/{Denominator}");
        }

        public override string ToString()
        {
            return $"{Numberator}/{Denominator}";
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int numberator = a.Numberator * b.Denominator + b.Numberator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numberator, denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int numberator = a.Numberator * b.Denominator - b.Numberator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numberator, denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numberator *  b.Numberator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numberator == 0)
            {
                throw new Exception("분자가 0인 분수로 나누기를 시도했습니다..");
            }

            return new Fraction(a.Numberator * b.Denominator, a.Denominator * b.Numberator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            a = a.Reduce();
            b = b.Reduce();
            return (a.Numberator == b.Numberator) && (a.Denominator == b.Denominator);
        }

        public static bool operator !=(Fraction a, Fraction b)
            => !(a == b);

        public static Fraction operator ~(Fraction a)
            => new Fraction(~a.Numberator, a.Denominator);
    }
}
