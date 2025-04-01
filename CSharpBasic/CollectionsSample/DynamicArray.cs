using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsSample
{
    class DynamicArray : IEnumerable //반복 읽기가 가능한
    {
        public DynamicArray(int capactity) //capacity : 용량
        {
            _data = new object[capactity]; //보통은 4개부터 시작
        }

        public object this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();

                return _data[index];
            }
            set
            {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();

                _data[index] = value;
            }
        }

        public int Count => _count;

        public int Capacity
        {
            get => _data.Length;
            set
            {
                if (_count > value)
                    throw new Exception("현재 아이템 수 보다 작은 용량으로 설정할수 없습니다.");

                object[] temp = new object[value];

                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _data[i];
                }

                _data = temp;
            }
        }

        private object[] _data;
        private int _count;


        public void Add(object item)
        {
            // 용량이 부족할때
            if (_count == _data.Length)
            {
                object[] temp = new object[_count * 2]; // 크기 2배짜리 배열 생성
                
                // 기존 데이터 복사
                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _data[i];
                }

                _data = temp;
            }

            _data[_count++] = item;
        }

        /// <summary>
        /// index 의 아이템 삭제를 위해 이후 아이템들을 모두 한칸씩 앞으로 당김
        /// </summary>
        /// <param name="index"> 삭제하려는 아이템 위치 </param>
        /// <exception cref="IndexOutOfRangeException"> 인덱스 범위 초과 </exception>
        public void RemoveAt(int index)
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            _count--;
        }


        //public delegate bool Predicate2<in T>(T value); //자주 쓰니 아래처럼 C# 자체적으로 사용할 수 있게 만듬

        public int FindIndex(Predicate<object> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindLastIndex(Predicate<object> match)
        {
            for (int i =_count - 1; i >=0; i--)
            {
                if (match(_data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(Predicate<object> match)
        {
            int index = FindIndex(match);

            if (index < 0 )
                return false;

            RemoveAt(index);
            return true;
        }

        public bool RemoveLast(Predicate<object> match)
        {
            int index = FindLastIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        //현실적으로 모든 변수의 함수를 만드는 것은 불가능
        /* public int FindIndexBiggerThan90()
         {
             for (int i = 0; i < _count; i++)
             {
                 if (_data[i] > 90)
                 {
                     return i;
                 }

             }
         }*/

        /// <summary>
        /// Enumerator 를 반환하는 함수
        /// 즉 IEnumerator 의 구현이 필요하다
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
           return new Enumerator(this);
        }

        struct Enumerator : IEnumerator //Dynamic 용 IEnumerator
        {
            public Enumerator(DynamicArray list)
            {
                _list = list;
                _index = 0;
                _current = default;
            }


            public object Current => _current;


            DynamicArray _list; // 원본 데이터가 있는 객체 참조
            int _index; // 현재 데이터를 가리키는 위치 인덱스
            object _current; // 현재 데이터



            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index];
                    _index++;
                    return true;
                }

                _current = default;
                return false;
            }

            public void Reset()
            {
                _index = 0;
                _current = default;
            }
        }
    }
}
