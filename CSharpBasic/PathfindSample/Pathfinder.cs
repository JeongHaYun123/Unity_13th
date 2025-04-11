using static System.Net.Mime.MediaTypeNames;

namespace PathfindSample
{
    class Pathfinder
    {
        public enum AlgoType
        {
            None,
            DFS,
            BFS,
        }

        public Pathfinder(Map map)
        {
            _map = map;
            _visits = new bool[_map.Height, _map.Width];
        }

        Map _map;
        bool[,] _visits;


        public bool TryFindPath(AlgoType algoType, Coord start, Coord end, out IEnumerable<Coord> path)
        {
            switch (algoType)
            {
                case AlgoType.DFS:
                    return TryFindPathDFS(start, end, out path);
                case AlgoType.BFS:
                    return TryFindPathBFS(start, end, out path);
                default:
                    throw new ArgumentException("올바르지 않은 알고리즘 종류");
            }
        }

     /*   public bool TryFindPathDFS(Coord start)
        {
            return TryFindPathDFSReculsively(start);
        }

        private bool TryFindPathDFSReculsively(Coord current) //함수오버헤드 함수 찾는 비용 더 지불해야해서 이론적으로는 재귀보단 스택이 더 좋다. (실제로 돌려보면 성능차이가 많이 나는 것은 아니다)
        {
            bool found = false;

            Coord[] directions = new Coord[] { Coord.Up, Coord.Right, Coord.Down, Coord.Left };

            // TODO : if 문으로 current 가 찾는목표인지 확인하고 리턴

            foreach (Coord direction in directions)
            {
                if (TryFindPathDFSReculsively(current + direction))
                {
                    found = true;
                }
            }

            return found;
        }*/

        private bool TryFindPathDFS(Coord start, Coord end, out IEnumerable<Coord> pathResult)
        {
            bool found = false;
            pathResult = default;
            List<(Coord prev, Coord next)> pairs = new List<(Coord prev, Coord next)>();
            Stack<Coord> stack = new Stack<Coord>();
            stack.Push(start);
            _visits[start.Y, start.X] = true;
            pairs.Add((Coord.Invalid, start));

            // 탐색방향
            Coord[] directions = new Coord[] { Coord.Up, Coord.Right, Coord.Down, Coord.Left }; //좌하우상

            while (stack.Count > 0)
            {
                Coord current = stack.Pop();

                // 경로 찾음
                if (current == end)
                {
                    found = true;
                    break;
                }

                // 각 방향 순회
                foreach (Coord direction in directions)
                {
                    Coord next = current + direction;

                    // 맵 범위 넘어가면 이쪽 가면 안됨
                    if (_map.IsValid(next) == false)
                        continue;
                    
                    // 이미 방문했다면 이쪽 가면 안됨
                    if (_visits[next.Y, next.X])
                        continue;

                    // 못걷는곳이면 이쪽 가면안됨
                    if (_map.IsWalkable(next) == false)
                        continue;

                    stack.Push(next);
                    _visits[next.Y, next.X] = true;
                    pairs.Add((current, next));
                }
            }

            if (found)
            {
                List<Coord> path = new List<Coord>();
                int index = pairs.FindLastIndex(pair => pair.next == end); // 젤뒤부터 역으로 탐색
                path.Add(end);

                // 현재 역추적중인 쌍이 시작점으로부터 출발하는거라면 순회중지
                while (index > 0 &&
                       pairs[index].prev != start)
                {
                    path.Add(pairs[index].prev);
                    index = pairs.FindLastIndex(pair => pair.next == pairs[index].prev); // 현재 추적쌍의 출발점을 도착점으로가지는 가장 마지막 좌표 찾음
                }

                path.Add(start);
                path.Reverse();
                pathResult = path;
            }

            return found;
        }

        private bool TryFindPathBFS(Coord start, Coord end, out IEnumerable<Coord> pathResult)
        {
            bool found = false;
            pathResult = default;
            List<(Coord prev, Coord next)> pairs = new List<(Coord prev, Coord next)>();
            Queue<Coord> queue = new Queue<Coord>();
            queue.Enqueue(start);
            _visits[start.Y, start.X] = true;
            pairs.Add((Coord.Invalid, start));

            // 탐색방향
            Coord[] directions = new Coord[] { Coord.Up, Coord.Right, Coord.Down, Coord.Left };
            while (queue.Count > 0)
            {
                Coord current = queue.Dequeue();

                // 경로 찾음
                if (current == end)
                {
                    found = true;
                    break;
                }

                // 각 방향 순회
                foreach (Coord direction in directions)
                {
                    Coord next = current + direction;

                    // 맵 범위 넘어가면 이쪽 가면 안됨
                    if (_map.IsValid(next) == false)
                        continue;

                    // 이미 방문했다면 이쪽 가면 안됨
                    if (_visits[next.Y, next.X])
                        continue;

                    // 못걷는곳이면 이쪽 가면안됨
                    if (_map.IsWalkable(next) == false)
                        continue;

                    queue.Enqueue(next);
                    _visits[current.Y, current.X] = true;
                    pairs.Add((current, next));
                }
            }

            if (found)
            {
                List<Coord> path = new List<Coord>();
                int index = pairs.FindLastIndex(pair => pair.next == end); // 젤뒤부터 역으로 탐색
                path.Add(end);

                // 현재 역추적중인 쌍이 시작점으로부터 출발하는거라면 순회중지
                while (index > 0 &&
                       pairs[index].prev != start)
                {
                    path.Add(pairs[index].prev);
                    index = pairs.FindLastIndex(pair => pair.next == pairs[index].prev); // 현재 추적쌍의 출발점을 도착점으로가지는 가장 마지막 좌표 찾음
                }

                path.Add(start);
                path.Reverse();
                pathResult = path;
            }

            return found;
        }
    }
}
