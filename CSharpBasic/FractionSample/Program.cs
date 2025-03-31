namespace FractionSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FractionCalculator fractionCalculator = new FractionCalculator(3);

            for (int i = 0; i < fractionCalculator.Capacity; i++)
            {
                Fraction fraction = fractionCalculator.InputFraction(); //분수 입력 정상적으로 될 때까지 반복
                fractionCalculator.AddFraction(fraction);
            }

            fractionCalculator.Print();

            if (fractionCalculator.TryOperation(new Fraction(1, 2), new Fraction(0, 5), '/', out Fraction result))
            {
                Console.WriteLine($"operator test .. result : {result}");
            }
            else
            {
                Console.WriteLine($"Failed to operator test...");
            }

            fractionCalculator.BoxingSimulation(new Fraction(1, 2), new Fraction(1, 2));

            Console.WriteLine($"Bit not of {new Fraction(1, 2)} is : {~new Fraction(1,2)}");
        }
    }
}
