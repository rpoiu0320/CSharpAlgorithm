using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLiskHomework
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;     // 이전 위치
        internal LinkedListNode<T> next;     // 다음 위치
        private T data;                      // 데이터

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return data; } set { data = value; } }

        public LinkedListNode(T value)                      // 각 함수에 사용될 LinkedListNode 생성자 오버로딩
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.data = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.data = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.data = value;
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;     // 리스트의 첫번째 노드
        private LinkedListNode<T> tail;     // 리스트의 마지막 노드
        private int count;                  // 리스트의 현재 갯수

        public LinkedList()                 // 생성자
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)       // 리스트의 맨 앞에 새 데이터 추가
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (head == null || tail == null)    // 데이터,노드가 없을 때
            {
                head = newNode;                 // head, tail 새로 지정
                tail = newNode;
            }
            else
            {
                newNode.next = head;            // 기존 헤드와 새로운 노드가 서로 쌍방향으로 가리키기됨
                head.prev = newNode;
            }

            count++;                            // 개수 증가

            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)       // 리스트의 맨 뒤에 새 데이터 추가
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (head == null || tail == null)   // 데이터,노드가 없을 때
            {
                head = newNode;                 // head, tail 새로 지정
                tail = newNode;
            }
            else
            {
                newNode.prev = tail;            // 기존 테일과 새로운 노드가 서로 쌍방향으로 가리키기됨
                tail.next = newNode;
            }

            count++;                            // 개수 증가

            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)  // 지정한 기존 노드 앞에 지정한 값이 포함된 새 노드를 추가
        {
            if (node.list != this)     // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우
                throw new InvalidOperationException();
            if (node.list == null)     // 예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            newNode.next = node;                // node3을 node2의 next로 지정
            newNode.prev = node.prev;           // node3의 prev == node1을 node2의 prev로 지정
            node.prev = newNode;                // node2를 node3의 prev == node1로 지정

            // node1    node2   node3

            // node1.next == node2

            // node2.prev == node1
            // node2.next == node3

            if (node.prev != null)              // head 검사
                node.prev.next = newNode;       // 기존 노드의 이전 노드의 next를 newNode로 지정, newNode의 prev,next 쌍방향 지정 완성
            else
                head = newNode;                 // 맨 앞이면 head로 지정

            count++;

            return newNode;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)  // 지정한 기존 노드 다음에 지정한 새 노드를 추가
        {
            if (node.list != this)     // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우
                throw new InvalidOperationException();
            if (node.list == null)     // 예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            newNode.prev = node;
            newNode.next = node.next;
            node.next = newNode;

            if (node.next != null)              // tail 검사
                node.next.prev = newNode;
            else
                tail = newNode;                 // 맨 앞이면 head로 지정

            count++;

            return newNode;
        }

        public void Remove(LinkedListNode<T> node) // 지정된 노드를 제거
        {
            if (node.list != this)     // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우
                throw new InvalidOperationException();
            if (node.list == null)     // 예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));

            if (head == node)          // 지울게 head, tail 일 경우 재지정
                head = node.next;
            if (tail == node)
                tail = node.prev;

            if (node.prev != null)              // 맨 뒤가 아닐 때
                node.prev.next = node.next;

            if (node.next != null)              // 맨 앞이 아닐 때
                node.next.prev = node.prev;
                                                // node에 연결되어 있는 체인을 모두 끊어줌
            count--;
        }

        public bool Remove(T value)     // 맨 처음 발견되는 지정된 값을 제거
        {
            LinkedListNode<T> findNode = Find(value);   // 지울 대상 탐색

            if(findNode != null)
            {
                Remove(findNode);                       // 맞다면 지우고 true 반환
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedListNode<T> Find(T value)      // 지정한 값이 포함된 첫 번째 노드를 찾기
        {
            LinkedListNode<T> target = head;        // 첫번째 노드부터 시작해서 

            while (target != null)                  // 반복문으로 모든 노드 탐색
            {
                if(target.Value.Equals(value))      // 같다면 반환
                    return target;
                else                                // 아니면 다음 노드로 이동
                    target = target.next;
            }

            return null;
        }

        public bool Contains(T value)               // 값이 LinkedList<T>에 있는지 여부를 확인
        {
            LinkedListNode<T> target = head;        // 첫번째 노드부터 시작해서 

            while (target != null)                  // 반복문으로 모든 노드 탐색
            {
                if (target.Value.Equals(value))     // 같다면 true 반환
                    return true;
                else                                // 아니면 다음 노드로 이동
                    target = target.next;
            }

            return false;                           // 없으면 false 반환
        }
    }
}
