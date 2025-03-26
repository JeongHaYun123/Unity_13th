using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class Map
    {
        public Map(int width, int height)
        {
            _tiles = new MapTile[height, width];
        }

        public MapTile[,] tiles => _tiles;
        MapTile[,] _tiles;

        public static Map CreateDefault(int width, int height)
        {
            Map map = new Map(width, height);

            for (int i = 0; i < map._tiles.GetLength(0); i++)
            {
                for (int j = 0; j < map._tiles.GetLength(1); j++)
                {
                    map._tiles[i, j] = new MapTile(coord: new Coord(j, i),
                                                floorType: FloorType.Grass,
                                                gameObject: null);
                }
            }

            return map;
        }

        public bool TryGetEmptyRandomMapTile(out MapTile mapTile)
        {
            Random random = new Random();
            int randomY = random.Next(_tiles.GetLength(0));
            int randomX = random.Next(_tiles.GetLength(1));

            // 타일 비어 있음
            if (_tiles[randomY, randomX].GameObject == null)
            {
                mapTile = _tiles[randomY, randomX];
                return true;
            }

            //mapTile = default; //모든 멤버 변수를 0으로 초기화한 값을 넘기겠다.
            mapTile = MapTile.Invalid;
            return false;
        }

        public bool TrySetGameObject(int x, int y, GameObject gameObject)
        {
            if (!isEmpty(x, y))
                return false;

            _tiles[y, x].GameObject = gameObject;
            return true;
        }

        public bool isEmpty(int x, int y)
        {
            return _tiles[y, x].GameObject == null;
        }

        public void Display()
        {
            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    switch (_tiles[i, j].FloorType)
                    {
                        case FloorType.None:
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case FloorType.Grass:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case FloorType.Stone:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case FloorType.Water:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                        default:
                            break;
                    }

                    if (_tiles[i, j].GameObject == null)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        // TODO : GameObject 의 문자 출력
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
