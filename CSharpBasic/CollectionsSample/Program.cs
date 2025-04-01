using System.Collections;

namespace CollectionsSample
{
    internal class Program
    {
        Action<int> action; // 파라미터 0~ 16개 까지, 반환형 void 인 함수 참조 체이닝을 위한 C# 기본 대리자
        Func<int, bool> func; // 파라미터 0~ 16 까지, 반환형 제네릭타입인 함수 참조 체이닝을 위한 C# 기본 대리자
        Predicate<int> predicate; // 파라미터 1개, 반환형 bool 인 함수 참조체이닝을 위한 C# 기본 대리자 (보통 조건 확인용)

        static void Main(string[] args)
        {
            /*DynamicArray dynamicArray = new DynamicArray(4); //박싱 언박싱으로 인해 제네릭보다 비용 증가(위에가 더 느림)
            dynamicArray.Add(1);
            dynamicArray.Add(4);
            dynamicArray.Add(2);
            dynamicArray.Add(5);
            dynamicArray.Add(3);
            dynamicArray.Add("Luke");
            dynamicArray.RemoveAt(4);
            //dynamicArray.FindLastIndex(x => (int)x > 3);

            //dynamicArray[2] = 3;
            for (int i = 0; i < dynamicArray.Count; i++)
            {
                dynamicArray[i] = 1;
            }*/

            DynamicArray dynamicArray = new DynamicArray(4); //박싱 언박싱으로 인해 제네릭보다 비용 증가(위에가 더 느림)
            dynamicArray.Add(1);
            dynamicArray.Add(4);
            dynamicArray.Add(2);
            dynamicArray.Add(5);
            dynamicArray.Add(3);
            dynamicArray.RemoveAt(4);
            dynamicArray.FindLastIndex(x => (int)x > 3);

            Predicate<object> match = x => (int)x > 3;

            IEnumerator enumerator = dynamicArray.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            enumerator.Reset();

            for (; enumerator.MoveNext();)
            {
                Console.WriteLine(enumerator.Current);
            }

            DynamicArray<int> numbers1 = new DynamicArray<int>(4);
            numbers1.Add(1);
            numbers1.Add(2);

            DynamicArray<int> numbers2 = new DynamicArray<int>(4);
            numbers2.Add(1);
            numbers2.Add(2);

            DynamicArray<string> rewards = new DynamicArray<string>(4);
            rewards.Add("HP Potion");
            rewards.Add("MP Potion");
            rewards.Add("Basic sword");
            //int index = rewards.FindIndex(x => x.Length > 4);

            TreasureChest treasureChest = new TreasureChest(rewards);
            Console.WriteLine($"보상 받음 : {treasureChest.GetRandomReward()}");

            for (int i = 0; i < rewards.Count; i++)
            {
                Console.Write($"{rewards[i]}, ");
            }

            // using 구문 : IDisposable 객체에 대한 Dispose() 호출 보장 구문
            // 개발자가 관리되지않는 리소스해제를 깜빡하고 안하는것을 방지하기위한 구문(메모리 누수 방지)
            using (IEnumerator<int> eNumbers = numbers1.GetEnumerator()) // 책 읽어주는 사람 고용
            {
                while (eNumbers.MoveNext())
                {
                    // 책 읽어주는 사람에게 현재 페이지 나한테 넘겨주세요
                    Console.WriteLine(eNumbers.Current);
                }
            }
            //IEnumerator<int> eNumbers = numbers1.GetEnumerator(); // 책 읽어주는 사람 고용

            // 책 읽어주는 사람에게 현재 페이지 읽고 다음장 넘겨주세요
            // 현재 페이지 읽는데 성공했으면 true, 아니면 false.
            //while (eNumbers.MoveNext())
            //{
            //    // 책 읽어주는 사람에게 현재 페이지 나한테 넘겨주세요
            //    Console.WriteLine(eNumbers.Current);
            //}

            //eNumbers.Dispose(); // 이 책을 읽기위해서 사용했던 관리되지 않는 리소스를 해제

            IEnumerator<int> e1 = numbers1.GetEnumerator();
            IEnumerator<int> e2 = numbers2.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext()) //2개가 아니면 foreach를 사용해도 된다. (순회)
            {

            }

            // foreach 구문
            // IEnumerable 에 대해서 GetEnumerator() 호출하여
            // Enumeration 을 수행하는 구문
            foreach (int item in numbers1) //IEnumerator 이해하고 써야한다.
            {
                Console.WriteLine(item);
            }

            // List - C#의 제네릭 동적배열
            //----------------------------------------------------------
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(4);
            list.Add(2);
            list.RemoveAt(2);

            foreach (int item in list)
            {

            }

            // ArrayList - C# 의 논-제네릭(object 기반) 동적배열
            //----------------------------------------------------------
            ArrayList arrList = new ArrayList();
            arrList.Add("Hi");
            arrList.Add(3.5f);
            arrList.Add('a');
        }
    }
}
