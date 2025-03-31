using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollectionsSample
{
    class DynamicArray_1<T>
    {
        public DynamicArray_1(int capactity)
        {
            _data = new T [capactity];
        }

        public T this[int index]
        {
            get
            {
                if(index >= _count ||  index < 0)
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

        public int Capactity
        {
            get => _data.Length;
            set
            {
                if (_count > value)
                    throw new Exception("현재 아이템 수보다 작은 공간으로 만들 수 없습니다.");

                T [] temp = new T [value];

                for (int i = 0; i < _count; i++)
                {
                    temp [i] = _data [i];
                }

                _data = temp;
            }
        }

        public T[] _data;

        public int _count;

        public void Add(T[] item)
        {
            if (_count == _data.Length)
            {
                T[] temp = new T[_count * 2];


                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _data [i];
                }

                _data = temp;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0  || index >= _count) throw new IndexOutOfRangeException();

            for (index = 0;  index < _count - 1; index++)
            {
                _data[index] = _data[index + 1];
            }

            _count--;
        }

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

        public bool Remove(Predicate<T> match)
        {
            int index = FindIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index); return true;
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

        public bool RemoveLast(Predicate<T> match)
        {
            int index = FindLastIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index); return true;
        }

    }
}
