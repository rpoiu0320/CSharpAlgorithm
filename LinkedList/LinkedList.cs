using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;     // 이전 위치
        internal LinkedListNode<T> next;     // 다음 위치
        private T item;                      // 데이터

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return item; } set { item = value; } }

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get {  return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T> (this, value); // this 키워드가 클래스의 현재 인스턴스의 obj를 참조

            // 2. 연결구조 변경
            if (head != null)   // 2-1. Head 노드가 있었을 때
            {
                newNode.next = head;
                head.prev = newNode;
            }
            else                // 2-2. Head 노드가 없었을 때  (처음 생성할 때)
            {
                head = newNode;
                tail = newNode;
            }

            // 3. 갯수 늘리기
            count++;
            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            if (node.list != this)     // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우
                throw new InvalidOperationException();
            if (node.list == null)     // 예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));

            // 1. 새로운 노드 만들기
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev = newNode;

            if (node.prev != null)
                node.prev.next = newNode;
            else
                head = newNode;

            // 3. 갯수 증가
            count++;

            return newNode;
        }

        public void Remove(LinkedListNode<T> node)
        {       
            if ( node.list != this)     // 예외1 : 노드가 연결리스트에 포함된 노드가 아닌 경우
                throw new InvalidOperationException();
            if ( node.list == null)     // 예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));

            // 0. 지웠을 때 head나 tail이 변경되는 경우 적용
            if (head == node)
                head = node.next;
            if(tail == node)
                tail = node.prev;

            // 1. 연결구조 바꾸기
            if (node.prev != null)
                node.prev.next = node.next;

            if (node.next != null)
                node.next.prev = node.prev;

            count--;                    // 갯수 줄이기
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> findNode = Find(value);     // = 찾기
            if (findNode != null)
            {
                Remove(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            while (target != null)
            {
                if (comparer.Equals(value, target.Value))
                    return target;
                else
                    target = target.next;
            }

            return null;
        }
    }
}
