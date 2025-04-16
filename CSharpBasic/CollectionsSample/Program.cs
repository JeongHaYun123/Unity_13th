using System.Collections;
using System.Text;
using System.Xml.Schema;

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

            //CountRoutineEnumerator countRoutineEnumerator = new CountRoutineEnumerator();
            IEnumerator<int> countRoutineEnumerator = new CountRoutineEnumerator();

            while (countRoutineEnumerator.MoveNext())
            {
                Console.WriteLine($"{countRoutineEnumerator.Current}");
            }

            IEnumerator<int> countRoutineEnumerator2 = CountRoutine();

            while (countRoutineEnumerator2.MoveNext())
            {
                Console.WriteLine($"{countRoutineEnumerator2.Current}");
            }

            IEnumerator dummyEnumerator = DummyRoutinable().GetEnumerator();

            while (dummyEnumerator.MoveNext())
            {
                Console.WriteLine($"{dummyEnumerator.Current}");
            }

            foreach(object item in DummyRoutinable())
            {
                
            }

            //Stack
            //----------------------------------------------------------------------

            MyStack<int> myStack = new MyStack<int>(5);
            myStack.Push(1);
            myStack.Push(4);
            myStack.Push(1);
            myStack.Pop();
            myStack.Push(5);
            Console.WriteLine(myStack.Peek());

            Stack<int> stack = new Stack<int>(6);
            stack.Push(1);
            stack.Push(4);
            stack.Push(1);
            stack.Pop();
            Console.WriteLine(stack.Peek());

            // Queue
            //-----------------------------------------------------------------

            MyQueue<string> myQueue = new MyQueue<string>(3);
            myQueue.Enqueue("Luke");
            myQueue.Enqueue("Carl");
            myQueue.Enqueue("David");
            myQueue.Enqueue("Ben");
            myQueue.Dequeue();
            myQueue.Enqueue("Tobi");
            myQueue.Dequeue();
            myQueue.Enqueue("Shun");
            myQueue.Enqueue("Tom");

            Console.WriteLine("대기열 : ");
            while (myQueue.Count > 0)
            {
                Console.Write($"{myQueue.Dequeue()}, ");
            }

            Queue<string> queue = new Queue<string>(4);
            queue.Enqueue("HI");
            queue.Enqueue("Bye");
            queue.Dequeue();
            queue.Peek();

            // LinkedList
            //-------------------------------------------------------------------

            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            myLinkedList.AddLast(1);
            myLinkedList.AddFirst(2);
            MyLinkedListNode<int> myLinkedListNode = myLinkedList.FindLast(x => x > 0);

            myLinkedList.AddAfter(myLinkedListNode, 4); // 2, 1, 4

            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(1);

            foreach (var value in myLinkedList)
            {
            }

            foreach (int item in linkedList)
            {
            }

            // Trie
            // -----------------------------------------------------------------------

            Trie trie = new Trie();

            List<string> inputWords = new List<string>()
            {
                "apple", "App", "application", "apex", "apt",
                "banana", "band", "bandage", "bandit", "ban",
                "cat", "cater", "caterpillar", "cattle",
                "dog", "dodge",
                "elephant", "elegant", "element", "elevator",
                "zebra", "zephyr", "zealous", "zeppelin",
                "xylophone", "xenon",
                "quantum", "quarrel", "queen"
            };

            foreach (string word in inputWords)
            {
                trie.Add(word);
            }

            StringBuilder inputBuilder = new StringBuilder(20);
            //string inputText = string.Empty;

            Console.Clear();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.Backspace)
                {
                    /*if (inputText.Length > 0)
                        inputText = inputText.Substring(0, inputText.Length - 1);*/
                    if (inputBuilder.Length > 0)
                        inputBuilder.Remove(inputBuilder.Length - 1, 1); //새로운 인스턴스 할당되고 가비지 컬렉션 없어지는 게 없어진다.
                        //inputBuilder.Length -= 1;
                }
                else if ((char)key >= 'A' && (char)key <= 'Z')
                {
                    inputBuilder.Append(char.ToLower((char)key));
                    //inputText += (char)Key;
                }
                else
                {
                    Console.WriteLine("알파벳만 입력 가능합니다.");
                }



                //char c = Convert.ToChar(input); //단어 아스키 코드를 캐릭터 타입으로 변경해서 사용
                //inputText += c;
                string input = inputBuilder.ToString();
                Console.WriteLine($"검색 : {input}");

                List<string> startsWith = trie.StartsWith(input);

                foreach (string word in startsWith)
                {
                    Console.WriteLine(word);
                }

                Console.SetCursorPosition(7 + input.Length, 0);
            }

            // Dictionary (Gener ic Hashtable)
            //----------------------------------------------------------------------
            //원하는 키로 밸류 검색
            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores.Add("Luke", 50);
            scores.Add("Carl", 70);
            scores["Jason"] = 40;

            int scoreOfLuke = scores["Luke"];
            scores.Remove("Lule");

        }

        static IEnumerator BaristaRoutin()
        {
            // TODO -> 주문 들어올때까지 기다리는 로직
            yield return null;
            // TODO -> 주문들어온거 제조하고 제조 될때까지 기다리는 로직
            yield return null;
        }

        static IEnumerator<int> CountRoutine()
        {
            yield return 1; // yield 키워드 : IEnumerable 혹은 IEnumerator 의 MoveNext 구현을 작성할때 사용
            Random random = new Random();
            int number = random.Next(0, 5);
            yield return number;
            //yield return 2;
            yield return 3;
            //yield break;
        }

        static IEnumerable DummyRoutinable()
        {
            yield return "Luke"; // yield 키워드 : IEnumerable 혹은 IEnumerator 의 MoveNext 구현을[삭제 : 및 Current 에 값을 리턴하는 내용을] 작성할때 사용
            yield return 3.5f;
            yield return 'A';
            //yield break;
        }

        class CountRoutineEnumerator : IEnumerator<int>
        {
            public int Current => _current;

            object IEnumerator.Current => Current;
            int _index;
            int _current;

            public bool MoveNext()
            {
                if (_index == 0)
                    _current = 1;
                else if (_index == 1)
                    _current = 2;
                else if (_index == 2)
                    _current = 3;
                else
                    return false;

                _index++;
                return true;
            }

            public void Reset()
            {
                _index = 0;
                _current = default(int);
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
