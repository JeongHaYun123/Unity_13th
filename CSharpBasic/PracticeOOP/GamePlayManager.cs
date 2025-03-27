using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class GamePlayManager
    {
        private Map _map;
        private PC _player;
        private MapTile _playerTile;
        private MapTile _nullTile;

        public void PlayGame()
        {
            initializeLevel();
            GameWorkflow();
        }

        private void initializeLevel()
        {
            CreateMap();
            SpawnGameObjects();
        }

        private void CreateMap()
        {
            _map = Map.CreateDefault(20, 20); // 맵을 기본 값으로 생성
        }

        private void SpawnGameObjects()
        {
            MapTile mapTile;
            GameObject spawnedObject;
            Coord[] coords = _map.GetShuffledEmptyCoords();
            int coordIndex = 0;

            // 이장님 소환 및 배치
            spawnedObject = new TownNPC_VillageChief("마을이장", int.MaxValue);
            mapTile = _map.GetTile(coords[coordIndex]);
            mapTile.GameObject = spawnedObject;
            _map.SetTile(mapTile);
            coordIndex++;

            /*// 촌장님 소환
            if (_map.TryGetEmptyRandomMapTile(out mapTile))
            {
                spawnedObject = new TownNPC_VillageChief("마을이장", int.MaxValue);
                //1  mapTile.GameObject = spawnedObject; //여기다 이장님 넣어봤자 함수 끝나면 이장님 사라진다, Heap에 있는 함수를 복사해서 쓰는 거기 때문에 함수 끝나면 사라짐(값 타입이기 때문이다)
                //2  _map.TrySetGameObject(mapTile.Coord.X, mapTile.Coord.Y, spawnedObject);
                mapTile.GameObject = spawnedObject;
                //3  _map[mapTile.Coord.Y, mapTile.Coord.X] = mapTile;
                //4  _map[mapTile.Coord] = mapTile;
                _map.SetTile(mapTile);
                int[] a = new int[20];
                a[4] = 4;
                Console.WriteLine(a[5]);
            }*/

            // 슬라임 10마리 생성
            for (int i = 0; i < 10; i++)
            {
                spawnedObject = new Slime("슬라임", 50);
                mapTile = _map.GetTile(coords[coordIndex]);
                mapTile.GameObject = spawnedObject;
                _map.SetTile(mapTile);
                coordIndex++;
                /*if (_map.TryGetEmptyRandomMapTile(out mapTile))
                {
                    spawnedObject = new Slime("슬라임", 50);
                }*/
            }

            // 버섯 5마리 생성
            for (int i = 0; i < 5; i++)
            {
                spawnedObject = new Mushroom("버섯", 100, 5);
                mapTile = _map.GetTile(coords[coordIndex]);
                mapTile.GameObject = spawnedObject;
                _map.SetTile(mapTile);
                coordIndex++;
                /*if (_map.TryGetEmptyRandomMapTile(out mapTile))
                {
                    spawnedObject = new Slime("슬라임", 50);
                }*/
            }

            // 플레이어 캐릭터 생성 (전사)
            spawnedObject = _player = new Warrior("나는전사", 200, 20);
            mapTile = _map.GetTile(coords[coordIndex]);
            _playerTile = _map.GetTile(coords[coordIndex]);
            _nullTile = _map.GetTile(coords[coordIndex]);
            _playerTile.GameObject = spawnedObject;
            //mapTile.GameObject = spawnedObject;
            //_map.SetTile(mapTile);
            _map.SetTile(_playerTile);
            coordIndex++;            
        }


        private void GameWorkflow()
        {
            //return;

            while (IsGameOver() == false &&
                   IsGameClear() == false)
            {
                Console.Clear();
                _map.Display();
                HandleInput();
            }
        }

        private bool IsGameOver()
        {
            // TODO : 플레이어 체력이 0 이하인지
            return _player.Hp <= 0;
        }

        private bool IsGameClear()
        {
            // TODO : 소탕딘 적이 더이상 남아있지 않은지
            // 
            return false;
        }

        private void HandleInput()
        { 
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            _map.SetTile(_nullTile);
            // TODO : 방향키로 플레이어 이동 (경계를 벗어나거나, 타일위에 다른 GameObject 있으면 이동 불가)

            // Hint. key 입력 방향으로 이동하려할때
            // 해당위치가 유효한지, 비어있는지 확인해서
            // 플레이어를 다른타일로 옮김
            if (key == ConsoleKey.UpArrow)
            {
                if (_playerTile.Coord.Y  > 0 &&  _map.IsValid(_playerTile.Coord.X, _playerTile.Coord.Y - 1) == true)
                {
                    _playerTile.Coord.Y -= 1;
                    _nullTile.Coord.Y -= 1;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (_playerTile.Coord.Y + 1 < 20 && _map.IsValid(_playerTile.Coord.X, _playerTile.Coord.Y + 1) == true)
                {
                    _playerTile.Coord.Y += 1;
                    _nullTile.Coord.Y += 1;
                }
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                if (_playerTile.Coord.X  > 0 &&  _map.IsValid(_playerTile.Coord.X - 1, _playerTile.Coord.Y) == true)
                {
                    _playerTile.Coord.X -= 1;
                    _nullTile.Coord.X -= 1;
                }
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if (_playerTile.Coord.X + 1 < 20 && _map.IsValid(_playerTile.Coord.X + 1, _playerTile.Coord.Y) == true)
                {
                    _playerTile.Coord.X += 1;
                    _nullTile.Coord.X += 1;
                }
            }

            _map.SetTile(_playerTile);

        }
    }
}
