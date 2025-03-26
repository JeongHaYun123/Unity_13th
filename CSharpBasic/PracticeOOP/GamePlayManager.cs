using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class GamePlayManager
    {
        private Map _map;

        public void PlayGame()
        {
            initializeLevel();
            GameWorkflow();
        }

        private void initializeLevel()
        {
            CreateMap();
            SpawnNPCs();
            SpawnPlayer();
        }

        private void CreateMap()
        {
            _map = Map.CreateDefault(20, 20);
            _map.Display();
        }

        private void SpawnNPCs()
        {
            MapTile mapTile;
            GameObject spawnedObject;

            // 촌장님 소환
            if (_map.TryGetEmptyRandomMapTile(out mapTile))
            {
                spawnedObject = new TownNPC_VillageChief("마을이장", int.MaxValue);
                //mapTile.GameObject = spawnedObject; //여기다 이장님 넣어봤자 함수 끝나면 이장님 사라진다, Heap에 있는 함수를 복사해서 쓰는 거기 때문에 함수 끝나면 사라짐(값 타입이기 때문이다)
                _map.TrySetGameObject(mapTile.Coord.X, mapTile.Coord.Y, spawnedObject);
            }
        }

        private void SpawnPlayer()
        {

        }

        private void GameWorkflow()
        {
            return;

            while (IsGameOver() == false &&
                   IsGameClear() == false)
            {

            }
        }

        private bool IsGameOver()
        {
            // TODO : 플레이어 체력이 0 이하인지
            return false;
        }

        private bool IsGameClear()
        {
            // TODO : 소탕딘 적이 더이상 남아있지 않은지
            // 
            return false;
        }
    }
}
