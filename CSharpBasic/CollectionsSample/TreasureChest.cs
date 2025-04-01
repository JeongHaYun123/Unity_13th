using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsSample
{
    class TreasureChest
    {
        public TreasureChest(DynamicArray<string>rewards ) //읽는 기능만
        {
            rewards.Add("Basic bow");
            rewards.Remove(x => x.Contains("sword"));
            _rewards = new string[rewards.Count];

            for ( int i = 0; i < rewards.Count; i++)
            {
                _rewards[i] = rewards[i];
            }
        }

        string[] _rewards;

        public string GetRandomReward()
        {
            Random random = new Random();
            int reandomIndex = random.Next(0, _rewards.Length);
            return _rewards[reandomIndex];
        }
    }
}
