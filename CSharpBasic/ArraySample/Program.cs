namespace ArraySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new 키워드 : 새로 어떤 데이터가 초기화가 되었다는 뜻 //동적할당을 하기위한 키워드
            // 배열 생성 방법 : new 자료형[크기]
            // 배열은 참조 형식
            //int[] arr = new int[5]; // 모든 요소 0 초기화
            //int[] arr = { 3, 4, 2, 7, 1 }; // 요소별 초기값 주고싶을때
            int[] arr = new int[5] { 3, 4, 2, 7, 1 }; // 이렇게도 쓸수 있음 //배열이 몇 개인지 보기 쉽게 하고, 초기 값 줄 수 있음

            // 배열의 인덱서
            // 배열에서 특정 번째 요소에 접근할 수 있도록 하는 기능
            // arr[i] , 배열의 첫번째 주소에서부터
            //          i * 요소의 자료형크기 만큼 뒤로가서 
            //          해당 주소부터 자료형크기만큼 읽거나 쓰기 함.
            arr[0] = 5;
            arr[1] = 4;
            arr[2] = 3;
            arr[3] = 2;
            arr[4] = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }

            Console.WriteLine();

            // Array 클래스
            // 배열관련 편의 기능들이 있음
            Array.Sort(arr); //오름차순 정렬

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }

            Array.Reverse(arr); //내림차순 정렬
            int indexOf2 = Array.IndexOf(arr, 2); //2가 있는 인덱스 반환
            int[] arr2 = { 6, 2, 3, 4, 1, 2 };
            Array.Copy(arr, 2, arr2, 0, 3); //arr의 2번째 인덱스부터 3개를 arr2의 0번째 인덱스부터 복사

            // 2차원 배열
            // 다차원 배열이라고해서 힙메모리영역에 다차원으로 할당하는게 아니고 그냥 연속적인 데이터로 할당을 한 다음
            // 차원 인덱서를 통해 알맞는 위치에 접근하는 방식.
            // ----------------------------------------------

            // 0 : 길
            // 1 : 벽
            // 2 : 도착지점
            // 3 : 플레이어
            int[ , ] map = new int[6, 5] // 0차원이 y 축, 1차원이 x축 //6행 5열
            {
                { 0, 0, 0, 0, 1},
                { 0, 1, 1, 1, 1},
                { 0, 0, 0, 1, 1},
                { 1, 1, 0, 1, 1},
                { 1, 1, 0, 1, 1},
                { 1, 1, 0, 0, 2},
             };

            MapNode[,] map2 = new MapNode[6, 5]
            {
                { MapNode.Path, MapNode.Path, MapNode.Path, MapNode.Path, MapNode.Wall},
                { MapNode.Path, MapNode.Wall, MapNode.Wall, MapNode.Wall, MapNode.Wall},
                { MapNode.Path, MapNode.Path, MapNode.Path, MapNode.Wall, MapNode.Wall},
                { MapNode.Wall, MapNode.Wall, MapNode.Path, MapNode.Wall, MapNode.Wall},
                { MapNode.Wall, MapNode.Wall, MapNode.Path, MapNode.Wall, MapNode.Wall},
                { MapNode.Wall, MapNode.Wall, MapNode.Path, MapNode.Path, MapNode.Goal},
            };
        }

        enum MapNode
        {
            None,
            Path,
            Wall,
            Goal,
            User
        }
    }
}
