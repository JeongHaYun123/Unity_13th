using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollectionsSample
{
    class DynamicArray<T> : IEnumerable<T>
    {
        //public DynamicArray_1(int capactity)
        //{
        //    _data = new T [capactity];
        //}

        //public T this[int index]
        //{
        //    get
        //    {
        //        if(index >= _count ||  index < 0)
        //            throw new IndexOutOfRangeException();

        //        return _data[index];
        //    }
        //    set
        //    {
        //        if (index >= _count || index < 0)
        //            throw new IndexOutOfRangeException();

        //        _data[index] = value;
        //    }
        //}

        //public int Count => _count;

        //public int Capactity
        //{
        //    get => _data.Length;
        //    set
        //    {
        //        if (_count > value)
        //            throw new Exception("현재 아이템 수보다 작은 공간으로 만들 수 없습니다.");

        //        T [] temp = new T [value];

        //        for (int i = 0; i < _count; i++)
        //        {
        //            temp [i] = _data [i];
        //        }

        //        _data = temp;
        //    }
        //}

        //public T[] _data;

        //public int _count;

        //public void Add(T[] item)
        //{
        //    if (_count == _data.Length)
        //    {
        //        T[] temp = new T[_count * 2];


        //        for (int i = 0; i < _count; i++)
        //        {
        //            temp[i] = _data [i];
        //        }

        //        _data = temp;
        //    }
        //}

        //public void RemoveAt(int index)
        //{
        //    if (index < 0  || index >= _count) throw new IndexOutOfRangeException();

        //    for (index = 0;  index < _count - 1; index++)
        //    {
        //        _data[index] = _data[index + 1];
        //    }

        //    _count--;
        //}

        //public int FindIndex(Predicate<T> match)
        //{

        //    for (int i = 0; i < _count; i++)
        //    {
        //        if (match(_data[i]))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //public bool Remove(Predicate<T> match)
        //{
        //    int index = FindIndex(match);

        //    if (index < 0)
        //        return false;

        //    RemoveAt(index); return true;
        //}

        //public int FindLastIndex(Predicate<T> match)
        //{

        //    for (int i = _count - 1; i >= 0; i--)
        //    {
        //        if (match(_data[i]))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //public bool RemoveLast(Predicate<T> match)
        //{
        //    int index = FindLastIndex(match);

        //    if (index < 0)
        //        return false;

        //    RemoveAt(index); return true;
        //}

        public DynamicArray(int capactity) //capacity : 용량
        {
            _data = new T[capactity]; //보통은 4개부터 시작
        }

        public T this[int index]
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

                T[] temp = new T[value];

                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _data[i];
                }

                _data = temp;
            }
        }

        private T[] _data;
        private int _count;


        public void Add(T item)
        {
            // 용량이 부족할때
            if (_count == _data.Length)
            {
                T[] temp = new T[_count * 2]; // 크기 2배짜리 배열 생성

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
            _data[_count] = default(T); // 요거 안해주면 젤 마지막에 있던애들 가지비컬렉션 안됨
        }


        //public delegate bool Predicate2<in T>(T value); //자주 쓰니 아래처럼 C# 자체적으로 사용할 수 있게 만듬

        public int FindIndex(Predicate<T> match)
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

        public int FindLastIndex(Predicate<T> match)
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                if (match(_data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(Predicate<T> match)
        {
            int index = FindIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public bool RemoveLast(Predicate<T> match)
        {
            int index = FindLastIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() //상위 모든 인터페이스를 상속받았기에 쓰지 않아도 구현해야한다.
        {
            return GetEnumerator();
        }

        struct Enumerator : IEnumerator<T>
        {
            public Enumerator(DynamicArray<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T);
            }


            public T Current => _current;

            object IEnumerator.Current => Current; //쓸 일이 없지만 인터페이스를 상속받았기 때문에 어쩔 수 없이 구현했다.


            DynamicArray<T> _list;
            int _index;
            T _current;


            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index];
                    _index++;
                    return true;
                }

                _current = default(T);
                return false;
            }

            public void Reset()
            {
                _current = default(T);
                _index = 0;
            }

            public void Dispose() //상속받는 순간 아무것도 구현을 안 해도 무조건 해야한다, 메모리가 터질 수가 있다.
            {
            }
        }
    }
}
