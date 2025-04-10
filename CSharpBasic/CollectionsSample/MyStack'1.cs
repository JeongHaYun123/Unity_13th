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
    class MyStack<T> : IEnumerable<T>
    {

        public MyStack(int capactity) //capacity : 용량
        {
            _data = new T[capactity]; //보통은 4개부터 시작
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


        public void Push(T item)
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

        public T Pop()
        {
            if (_count == 0)
                throw new IndexOutOfRangeException();

            _count--;
            T item = _data[_count];
            _data[_count] = default;
            return item;
        }

        public T Peek()
        {
            if (_count == 0)
                throw new IndexOutOfRangeException();

            return _data[_count - 1];
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
            public Enumerator(MyStack<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T);
            }


            public T Current => _current;

            object IEnumerator.Current => Current; //쓸 일이 없지만 인터페이스를 상속받았기 때문에 어쩔 수 없이 구현했다.


            MyStack<T> _list;
            int _index;
            T _current;


            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list._data[_index];
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
