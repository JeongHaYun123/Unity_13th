using Fraction_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    struct Fraction : IPrintable
    {
        public Fraction(int numberator, int dominator)
        {
            _numberator = numberator;
            if (dominator == 0)
            {
                Console.WriteLine("dominator를 0이 아닌 1로 변경하겠습니다.");
                _dominator = 1;
            }
            else
                _dominator = dominator;
        }

        public int _numberator;
        public int _dominator;


        // 기약분수 메서드
        public Fraction Reduce()
        {
            int gcd = GCD(_numberator, _dominator);
            //Console.WriteLine($"최대공약수 : {gcd}");

            return new Fraction(_numberator / gcd, _dominator / gcd);
        }

        private int GCD(int numberator, int dominator)
        {
            if (dominator == 0)
                return numberator; // 최대 공약수
            else
                return GCD(dominator, (numberator % dominator)); // GDC 재귀함수 반복
        }

        public static Fraction operator +(Fraction op1, Fraction op2)
            => new Fraction(op1._numberator * op2._dominator + op2._numberator * op1._dominator, op1._dominator * op2._dominator).Reduce();
        public static Fraction operator -(Fraction op1, Fraction op2)
            => new Fraction(op1._numberator * op2._dominator - op2._numberator * op1._dominator, op1._dominator * op2._dominator).Reduce();
        public static Fraction operator *(Fraction op1, Fraction op2)
            => new Fraction(op1._numberator * op2._numberator, op1._dominator * op2._dominator);
        public static Fraction operator /(Fraction op1, Fraction op2)
            => new Fraction(op1._numberator * op2._dominator, op1._dominator * op2._numberator);
        public static bool operator ==(Fraction op1, Fraction op2)
            => (op1._numberator == op2._numberator &&op1._dominator == op2._dominator);
        public static bool operator !=(Fraction op1, Fraction op2)
            => (op1._numberator != op2._numberator && op1._dominator != op2._dominator);
        public static Fraction operator ~(Fraction op1)
            => new Fraction(~op1._numberator, op1._dominator);

        public void PrintInfo()
        {
            Console.WriteLine($"분수 : {_numberator}/{_dominator}");
        }
    }
}

