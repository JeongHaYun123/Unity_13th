﻿namespace GenericSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 5;
            Swap(ref a, ref b);
            Console.WriteLine($"{a}, {b}");

            Vector3 pos1 = new Vector3 { X = 4f, Y = 2f, Z = 3.5f };
            Vector3 pos2 = new Vector3 { X = 2f, Y = 6f, Z = 4f};
            Swap<Vector3>(ref pos1, ref pos2);
            Console.WriteLine($"post1:{pos1}, pos2:{pos2}");
            Swap(ref pos1, ref pos2); // 파라미터에 Vector3 타입을 넣었기때문에 컴파일러가 제네릭 형식에 Vector3 타입을 사용한다는것을 알수있다.

            Box<int> boxOfInt = new Box<int>();
            boxOfInt.Item = 4;

            Box<Vector3> boxOffVector3 = new Box<Vector3>();
            boxOffVector3.Item = pos1;

            Box<int, string> boxOfIntAndString = new Box<int, string>();
            boxOfIntAndString.PrintItems();

            boxOfIntAndString.Dummy<int[], Vector3>();

            object obj1 = 1;
            object obj2 = 1;
            Console.WriteLine(obj1 == obj2);
            Console.WriteLine(obj1.Equals(obj2));
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }

        static void Swap<T>(ref T a, ref T b) //제네릭 클래스 형식
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    internal struct Vector3
    {
        public float X, Y, Z;

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}, Z:{Z}";
        }
    }
}
