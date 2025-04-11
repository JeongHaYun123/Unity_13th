namespace PathfindSample
{
    internal class Program
    {
        static Coord _start;
        static Coord _end;
        const int MAP_SPAWN_TRY_COUNT = 3;

        static void Main(string[] args)
        {
            Map map = null;
            Pathfinder pathfinder = null ;
            int tryCount = 0;

            while (tryCount < MAP_SPAWN_TRY_COUNT)
            {
                tryCount++;
                map = SpawnMap();
                pathfinder = new Pathfinder(map);

                if (pathfinder.TryFindPath(Pathfinder.AlgoType.BFS, _start, _end, out IEnumerable<Coord> path))
                {
                    foreach (Coord coord in path)
                    {
                        MapTile mapTile = map.GetTile(coord);
                        mapTile.FloorType = FloorType.Dirt;
                        map.SetTile(mapTile);
                    }

                    break;
                }

                tryCount++;
            }

            if (tryCount > MAP_SPAWN_TRY_COUNT)
            {
                Console.WriteLine("맵 생성세 실패하였습니다. 게임을 다시 시작해주세요.");
                return;
            }

            map.Display();

        }

        static Map SpawnMap()
        {
            Map map = Map.CreateDefault(30, 20);
            Coord[] shuffledEmptyCoords = map.GetShuffledEmptyCoords();
            int i = 0;

            // 갈수없는 길 생성 (물)
            while (i < 100)
            {
                map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Water));
                i++;
            }

            // 갈수없는 길 생성 (돌)
            while (i < 150)
            {
                map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Stone));
                i++;
            }

            // 플레이어 생성
            _start = shuffledEmptyCoords[i];
            map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Grass, '㉿'));
            i++;

            // 목표 생성
            _end = shuffledEmptyCoords[i];
            map.SetTile(new MapTile(shuffledEmptyCoords[i], FloorType.Grass, '★'));
            i++;

            return map;
        }
    }
}
