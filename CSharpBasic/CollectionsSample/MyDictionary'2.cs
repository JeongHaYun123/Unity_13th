//원리만 이해하면 됨
//MyHash까지만 구현하면 됨
namespace CollectionsSample
{
    struct KeyValuePair<TKey, TValue>
    {
        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key;
        public TValue Value;
    }


    class MyDictionary<TKey, TValue>
    {
        public MyDictionary(int capacity)
        {
            _buckets = new int[capacity];

            for (int i =0; i < _buckets.Length; i++)
            {
                _buckets[i] = EMPTY;
            }

            _entries = new Entry[capacity];

            for (int i = 0; i < _entries.Length; i++)
            {
                _entries[i].HashCode = EMPTY;
            }
        }

        struct Entry
        {
            public bool IsValid => HashCode >= 0; //null로 해도 없는 것처럼 하는게 아니기 때문에 대신 0으로 null 처리

            public int HashCode; //키 비교를 할 때마다 해시코드를 뽑으면 효율이 떨어지기 때문이다. (어차피 한번 뽑아야하니 뽑을 떄 기억)
            public TKey Key;
            public TValue Value;
            public int NextIndex;
        }

        public TValue this[TKey key]
        {
            get
            {
                int hashCode = key.GetHashCode();
                int bucketIndex = hashCode % _buckets.Length;

                // buckets 에서 첫 진입점 인덱스 부터 탐색
                // 유효한 entry 가 있으면 계속 탐색 반복
                // 순회할때마다 충돌이 있다면 현재 Entry 의 Next 로 이동
                // * 이 for 루프때문에 Hashtable 의 시간복잡도 최악은 O(N) 이된다. (평균 O(1))
                for (int entryIndex = _buckets[bucketIndex]; entryIndex >= 0; entryIndex = _entries[entryIndex].NextIndex)
                {
                    // HashCode 가 동일하다면 내가 찾는 Key 일 확률이 엄청높으나 어쨌든 이론적으로 충돌날수도있기때문에
                    // HashCode 비교 이후에 Key 끼리도 비교를 한다.
                    // 바로 Key끼리 비교를 하는 것은 HashCode 끼리 비교하는것보다 비용이 높을 가능성이 높기때문에
                    // 일단 HashCode 끼리 먼저 비교하고 같을때만 확실하게 Key 비교를 한다.
                    if (_entries[entryIndex].HashCode == hashCode &&
                        _entries[entryIndex].Key.Equals(key))
                    {
                        return _entries[entryIndex].Value;
                    }
                }

                throw new KeyNotFoundException();
            }
            set
            {
                int hashCode = key.GetHashCode();
                int bucketIndex = hashCode % _buckets.Length;

                for (int entryIndex = _buckets[bucketIndex]; entryIndex >= 0; entryIndex = _entries[entryIndex].NextIndex)
                {
                    if (_entries[entryIndex].HashCode == hashCode &&
                        _entries[entryIndex].Key.Equals(key))
                    {
                        throw new ArgumentException($"{key} 는 이미 등록되어있음.");
                    }
                }

                // 공간 모자라면 늘림
                if (_count == _entries.Length)
                {

                }

                int availableEntryIndex = EMPTY;

                // 구멍난 Entry 가 있다면 거기부터 채워넣음
                if (_freeCount > 0)
                {
                    availableEntryIndex = _freeFirstEntryIndex;
                    _freeFirstEntryIndex = _entries[_freeFirstEntryIndex].NextIndex;
                    _freeCount--;
                }
                else
                {
                    availableEntryIndex = _count++;
                }


                _entries[availableEntryIndex] = new Entry()
                {
                    HashCode = hashCode,
                    Key = key,
                    Value = value,
                    NextIndex = _buckets[bucketIndex] // 최근 추가된 Entry 에 먼저 접근할수있도록 연결을 역순으로함
                };

                _buckets[bucketIndex] = availableEntryIndex;
            }
        }

        const int EMPTY = -1;

        int[] _buckets; // Entry 를 가리키기위한 인덱스를 담고있는 배열
        Entry[] _entries; // 실제 Key-Value 쌍을 저장하며 다음 Key-Value 쌍을 체이닝할수있는 진입점 배열
        int _count;
        int _freeFirstEntryIndex; // 구멍이난 Entry 배열중 첫번째 Entry의 인덱스
        int _freeCount; // 구멍난 Entry 갯수

        public bool Remove(TKey key)
        {
            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode % _buckets.Length;
            int prevEntryIndex = EMPTY;

            for (int entryIndex = _buckets[bucketIndex]; entryIndex >= 0; entryIndex = _entries[entryIndex].NextIndex)
            {
                if (_entries[entryIndex].HashCode == hashCode &&
                    _entries[entryIndex].Key.Equals(key))
                {
                    // 가리키는 이전 진입점이있으면 연결을 갱신
                    if (prevEntryIndex == EMPTY)
                    {
                        _buckets[bucketIndex] = _entries[entryIndex].NextIndex;
                    }
                    else
                    {
                        _entries[prevEntryIndex].NextIndex = _entries[entryIndex].NextIndex;
                    }

                    _entries[entryIndex].HashCode = EMPTY;
                    _entries[entryIndex].Key = default;
                    _entries[entryIndex].Value = default;
                    _entries[entryIndex].NextIndex = _freeFirstEntryIndex;
                    _freeFirstEntryIndex = entryIndex;
                    _freeCount++;

                    return true;
                }

                prevEntryIndex = entryIndex;
            }

            return false;
        }

/*        void Resize(int capacity)
        {
            int[] newBuckets = new int[capacity];

            // 기존 데이터 복제 및 나머지 Empty
            for (int i = 0; i < capacity; i++)
            {
                if (i < _buckets.Length)
                    newBuckets[i] = _buckets[i];
                else
                    newBuckets[i] = EMPTY;
            }

            Entry[] newEntires = new Entry[capacity];

            //새배열을 만들면 기존 배열은 그대로 두고 리헬싱한다(넘어가면 다른 새로운 배열 사용)
            //기존에 쓰던 버켓인덱스는 그대로 쓰고 넘어간 사람은 넘어간 시점부터 리헬싱 적용
            for(int i = 0;i < capacity; i++)
            {
                if (i < _buckets.Length)
                {
                    if (i < _buckets.Length)
                    {
                        if (_entries[i].IsValid)
                        {
                            newEntires[i] = new Entry
                            {
                                HashCode = _entries[i].HashCode,
                                NextIndex = newBuckets[i]
                            };

                            int bucketIndex = _entries[i].HashCode % capacity;
                            newBuckets[bucketIndex] = i;
                        }
                    }
                }
            }
        }*/

        /*const int DEFAULT_SIZE = 5;
        KeyValuePair<TKey, TValue>[] _data = new KeyValuePair<TKey, TValue>[DEFAULT_SIZE];

        public bool Add(TKey key, TValue value)
        {
            int hashCode = Hash(key);

            // 중복키 허용 x
            if (key.Equals(_data[hashCode]))
                return false;

            _data[hashCode] = new KeyValuePair<TKey, TValue>(key, value);
            return true;
        }

        public bool Contains(TKey key)
        {
            int hashCode = Hash(key);
            KeyValuePair<TKey, TValue> searched = _data[hashCode];
            return searched.Equals(key);
        }

        public bool Remove(TKey key)
        {
            int hashCode = Hash(key);
            if (_data[hashCode].Equals(key))
            {
                _data[hashCode] = default;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 문자열로 변환후 각 문자의 아스키값을 더한 후 크기로 나머지하는 간단한 해시함수
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int Hash(TKey key)
        {
            string str = key.ToString();
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                sum += str[i];
            }

            sum %= DEFAULT_SIZE;
            return sum;
        }*/
    }
}
