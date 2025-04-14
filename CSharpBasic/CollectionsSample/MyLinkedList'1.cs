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
    class MyLinkedListNode<T>
    {
        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        public T Value;
        public MyLinkedListNode<T> Prev; // 이전 노드 참조
        public MyLinkedListNode<T> Next; // 다음 노드참조
    }

    /// <summary>
    /// 양방향 연결리스트
    /// </summary>
    class MyLinkedList<T> : IEnumerable<T>
    {
        public MyLinkedListNode<T> First => _first;
        public MyLinkedListNode<T> Last => _last;

        public int Count => _count;

        private MyLinkedListNode<T> _first;
        private MyLinkedListNode<T> _last;
        private int _count;


        /// <summary>
        /// 아이템을 특정 노드 앞에 삽입
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입하려는 값 </param>
        public void AddBefore(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);
            MyLinkedListNode<T> prev = node.Prev;

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
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);

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

        public void AddAfter(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);

            if (node.Next != null)
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
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);

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
        public MyLinkedListNode<T> Find(Predicate<T> match)
        {
            MyLinkedListNode<T> current;
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

            /* 강사님 꺼
             * 첫번째 노드부터 시작
             * Node<T> current = _first;
             * 
             * 다음 노드가 없을때까지 계속 다음 드로 넘어가면서 반속
             * while (current != null)
             * {
             *    찾으려는 조건 확인
             *    if(match.Invoke(current.Value))
             *       return cureent;
             *       
             *    current = current.Next;
             * }
             * 
             * return null;
             */

        }

        /// <summary>
        /// Last 부터 처음까지 순회하면서 노트를 찾음
        /// </summary>
        /// <param name="match"> 찾으려는 노트의 값 조건 </param>
        /// <returns> 찾은 노트, 못찾으면 null </returns>
        public MyLinkedListNode<T> FindLast(Predicate<T> match)
        {
            MyLinkedListNode<T> current;
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

            /* 강사님 꺼
            * 마지막 노드부터 시작
            * Node<T> current = _last;
            * 
            * 다음 노드가 없을때까지 계속 다음 드로 넘어가면서 반속
            * while (current != null)
            * {
            *    찾으려는 조건 확인
            *    if(match.Invoke(current.Value))
            *       return cureent;
            *       
            *    current = current.Prev;
            * }
            * 
            * return null;
            */
        }

        /// <summary>
        /// 이 노드를 현재 연결리스트에서 삭제
        /// </summary>
        /// <param name="node"> 삭제하려는 노드 참조 </param>
        public void Remove(MyLinkedListNode<T> node)
        {
            if (node.Prev != null && node.Next != null)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            else if (node.Prev != null && node.Next == null)
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

            /* 강사님 꺼
             * 1. 지우려는게 null 이 아닌지 확인
             * 2. 이전노드가 null 이 아닌지 확인
             *       null 이 아니라면
             *          node 의 prev의 next 가 node 의 next
             * 3. 이전노드가 null 이면 first 를 지우는것이므로
             *       first 를 node 의 next
             * 4. 다음노드가 null 이 아닌지 확인
             *       null 이 아니라면
             *          node의 next의 prev 가 node 의 prev
             * 5. 다음노드가 null 이면 last 를 지우는것이므로
             *       last 를 node 의 prev
             * 6. node 삭제 완료하였으므로 size 감소
             * 
             * if (node == null)
             *    throw new ArgumentException("지우려는 node 참조가 null 입니다.");
             * 
             * if (node.Prev != null)
             *    node.Prev.Next = node.Next;
             * else
             *    _first = node.Next;
             * 
             * if (node.Next != null)
             *    node.Next.Prev = node.Prev;
             * else
             *    _last = ndeo.Prev;
             * 
             * _count--;
             * 연결리스트에서 제외하는 것이지 노드의 값을 지운다는 개념이 아니다.
             * 참조하는 얘가 없으면 갈비지 컬렉터가 알아서 없앤다.
             */
        }

        public bool Remove(T value)
        {
            MyLinkedListNode<T> node = Find(x => x.Equals(value));

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
            MyLinkedListNode<T> _next;
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


//public class Test
//{

//    public void A()
//    {
//        Action action;

//        action = () => Console.WriteLine("B"); // 인라인 함수 //이 위치의 함수가 들고 있다는 거다.

//        action = B; // 일반 함수

//        action.Invoke();
//    }

//    public void B()
//    {
//        Console.WriteLine("B");
//    }
//}