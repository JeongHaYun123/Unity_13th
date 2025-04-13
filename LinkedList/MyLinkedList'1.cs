using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsSample
{
    /// <summary>
    /// 연결리스트의 자료저장 단위
    /// </summary>
    class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value;
        public Node<T> Prev; // 이전 노드 참조
        public Node<T> Next; // 다음 노드참조
    }

    /// <summary>
    /// 양방향 연결리스트
    /// </summary>
    class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> First => _first;
        public Node<T> Last => _last;

        public int Count => _count;

        private Node<T> _first;
        private Node<T> _last;
        private int _count;


        /// <summary>
        /// 아이템을 특정 노드 앞에 삽입
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입하려는 값 </param>
        public void AddBefore(Node<T> node, T value)
        {
            Node<T> current = new Node<T>(value);
            Node<T> prev = node.Prev;

            // 기준노드 앞에 다른 노드가 있으면
            // 새 노드 앞에 기준노드의 앞노드를 설정한다.
            if (node.Prev != null)
            {
                prev.Next = current; // 기준노드의 앞 노드의 다음노드는 이제 새로 추가한노드가 된다.
                current.Prev = prev; // 새 노드의 앞노드는 기준노드의 앞노드로 설정한다.
                //node.Prev.Next = current; // 기준노드의 앞 노드의 다음노드는 이제 새로 추가한노드가 된다.
                //current.Prev = node.Prev; // 새 노드의 앞노드는 기준노드의 앞노드로 설정한다.
            }
            // First 앞에 삽입한 경우
            else
            {
                _first = current; // 새 노드가 이제 가장 앞
            }

            node.Prev = current; // 기준 노드 이전노드를 새 노드로
            current.Next = node; // 새 노드의 다음 노드를 기준노드로
            _count++;
        }

        public void AddFirst(T value)
        {
            Node<T> current = new Node<T>(value);

            // 젤 앞 노드가 존재하면 연결 갱신해야함
            if (_first != null)
            {
                _first.Prev = current;
                current.Next = _first;
            }
            // 이 노드가 최초의 노드라면 last 도 갱신
            else
            {
                _last = current;
            }

            _first = current; // 이제 새 노드가 제일 앞
            _count++;
        }

        public void AddAfter(Node<T> node, T value)
        {
            Node<T> current = new Node<T>(value);

            if(node.Next != null)
            {
                node.Next.Prev = current;
                current.Next = node.Next;
            }
            else
            {
                _last = current;
            }

            //ADD 뒤에 특정 노드 연결
            node.Next = current;
            current.Prev = node;
            _count++;
        }

        public void AddLast(T value)
        {
            Node<T> current = new Node<T>(value);

            // 최후가 없다면 최초도 갱신
            if (_last == null)
            {
                _first = current;
            }
            // 최후 노드가 존재하면 연결해야 함
            else
            {
                _last.Next = current;
                current.Prev = _last;
            }

            _last = current; // 이제 새 노드가 제일 뒤
            _count++;
        }

        /// <summary>
        /// First 부터 끝까지 순회하면서 노드를 찾음
        /// </summary>
        /// <param name="match"> 찾으려는 노드의 값 조건 </param>
        /// <returns> 찾은 노드, 못찾으면 null </returns>
        public Node<T> Find(Predicate<T> match)
        {
            Node<T> current;
            current = _first;

            while (current != null)
            {
                if (current == null)
                    return null;

                if (match(current.Value))
                    return current;

                current = current.Next;
            }

            return null;

        }

        /// <summary>
        /// Last 부터 처음까지 순회하면서 노트를 찾음
        /// </summary>
        /// <param name="match"> 찾으려는 노트의 값 조건 </param>
        /// <returns> 찾은 노트, 못찾으면 null </returns>
        public Node<T> FindLast(Predicate<T> match)
        {
            Node<T> current;
            current = _last;

            while (current != null)
            {
                if (current == null)
                    return null;

                if (match(current.Value))
                    return current;

                current = current.Prev;
            }

            return null;
        }

        /// <summary>
        /// 이 노드를 현재 연결리스트에서 삭제
        /// </summary>
        /// <param name="node"> 삭제하려는 노드 참조 </param>
        public void Remove(Node<T> node)
        {
            if (node.Prev != null && node.Next != null)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            else if(node.Prev != null && node.Next == null)
            {
                _last = node.Prev;
                node.Prev.Next = null;
            }
            else if (node.Prev == null && node.Next != null)
            {
                _first = node.Next;
                node.Next.Prev = null;
            }
            else
            {
                _first = null;
                _last = null;
            }

            _count--;
        }

        public bool Remove(T value)
        {
            Node<T> node = Find(x => x.Equals(value));

            if (node != null)
            {
                Remove(node);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            public Enumerator(MyLinkedList<T> list)
            {
                _list = list;
                _next = _list._first;
            }
            public T Current => _current;

            object IEnumerator.Current => Current;

            MyLinkedList<T> _list;
            Node<T> _next;
            T _current;

            public bool MoveNext()
            {
                if (_next != null)
                {
                    _current = _next.Value;
                    _next = _next.Next;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _next = _list._first;
                _current = default;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
