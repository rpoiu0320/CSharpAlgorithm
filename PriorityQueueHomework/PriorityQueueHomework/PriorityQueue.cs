using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueHomework
{
    // 완전이진트리(이진트리에 구멍이 없는, 배열내에 데이터들이 순차적으로 들어가 있는 이진트리)
    internal class PriorityQueue<TElement>  // 각 노드의 우선순위를 비교하기위해 TElement 사용
    {
        private struct Node
        {
            public TElement element;        // 인덱스의 요소
            public int priority;            // 우선순위 값
        }

        private List<Node> nodes;           // 이진트리로 만들 리스트 생성

        public PriorityQueue()              // 생성자
        {
            this.nodes = new List<Node>();
        }

        public int Count { get {  return nodes.Count; } }   // 인덱스의 개수

        public void Enqueue(TElement elemnt, int priority)  // 개체를 끝부분에 추가하는 함수
        {
            Node newNode = new Node() { element = elemnt, priority = priority };    // 인덱스의 요소, 우선순위를 저장할 노드

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);                                     // nodes리스트에 데이터 추가
            int newNodeIndex = nodes.Count;                         // index의 수 갱신

            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while(newNodeIndex > 0)
            {
                // 2-1. 부모 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);     // 해당 노드의 부모 노드의 인덱스를 구하고
                Node parentNode = nodes[parentIndex];               // 부모 노드를 변수에 저장

                // 2-2. 자식 노드가 부모 노드보다 우선순위가 높으면 교체
                if (newNode.priority < parentNode.priority)
                {
                    nodes[newNodeIndex] = parentNode;               // 부모 노드와 자식 노드를 서로 교체
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else                                                // 더이상 자식 노드가 부모 노드보다 우선순위가 높지 않으면 반복문 정지
                    break;
            }
        }

        public TElement Dequeue()                                   // 최상위의 노드를 제거 후 반환
        {
            Node rootNode = nodes[0];                               // 최상위 노드를 저장

            // 1. 가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1];                 // 현 이진트리서 가장 마지막에 위치한 노드 저장
            nodes[0] = lastNode;                                    // 마지막 노드를 최우선자리에 지정
            nodes.RemoveAt(nodes.Count - 1);                        // 마지막 노드의 요소를 제거

            int index = 0;                                          // 마지막 노드가 현재 최상단에 위치해 있으므로
                                                                    // 힙을 정상적으로 만들기 위하여 index를 최상위 노드로 지정

            // 2. 자식 노드들과 비교하여 우선순위가 더 작은(우선순위가 더 높은) 자식과 교체 반복
            while(index < nodes.Count)                              // 모든 노드를 포함하는 반복문 지정
            {
                int leftChildIndex = GetLeftChildIndex(index);      // 부모노드의 좌, 우측 자식노드를 저장
                int rightChildIndex = GetRightChildIndex(index);

                // 2-1. 자식이 둘 다 있는 경우
                if (rightChildIndex < nodes.Count)                   // 완전이진트리서 자식 노드가 둘 다 있을 때
                                                                     // 즉 우측 자식 노드가 존재하고 그 노드의 index가 nodes.Count보다 작을 때
                {
                    // 2-1-1. 좌측과 우측 자식 노드를 비교하여 우선순위가 더 높은 노드를 선정
                    int biggerChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority
                        ? leftChildIndex : rightChildIndex;         // 좌측이 우선순위가 더 높으면(priority 가 더 작으면) 좌측을, 아니면 우측을 저장(같을때도 우측)
                                                                    // 삼항연산자
                                                                    // 2-1-2. 더 우선순위가 높은 자식과 부모 노드를 비교하여
                                                                    //        부모가 우선순위가 더 낮은 경우 바꾸기
                    if (leftChildIndex < nodes.Count)
                    {
                        if (nodes[biggerChildIndex].priority < nodes[index].priority)   // 좌,우측 자식 노드 중 더 큰 노드를 부모노드와 비교
                        {
                            nodes[index] = nodes[biggerChildIndex];                     // 부모 노드와 자식 노드를 서로 교체
                            nodes[biggerChildIndex] = lastNode;
                            index = biggerChildIndex;
                        }
                    }
                }
                // 2-2. 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildIndex < nodes.Count)                          // 좌측 자식노드가 정상적으로존재 할 경우
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority) // 부모노드와 자식노드 비교
                    {
                        nodes[index] = nodes[leftChildIndex];                   // 부모 노드와 자식 노드를 서로 교체
                        nodes[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else                                                        // 부모노드가 더 크면 break
                        break;
                }
                // 자식이 없는 경우
                else
                    break;
            }

            return rootNode.element;                                // 최상위 노드의 요소를 반환
        }

        public TElement Peek()                       // 개체를 제거하지 않고 반환
        {
            return nodes[0].element;                 // 개체반환
        }

        private int GetParentIndex(int childIndex)   // 매개변수 노드의 부모 노드를 확인하는 함수
        {
            return (childIndex - 1) / 2;             // 배열로 저장되기에 이진트리에서 부모 노드를 구하는 공식을 사용 후 반환
        }                                            // 소숫점 제외

        private int GetLeftChildIndex(int parentIndex)  // 매개변수 노드의 좌측 자식 노드를 확인하는 함수
        {
            return parentIndex * 2 + 1;              // 부모 노드 * 2 + 1 을 하여 배열상에 부모노드 + 1의 깊이를 가지는 좌측 자식노드 반환 
        }

        private int GetRightChildIndex(int parentIndex) // 매개변수 노드의 우측 자식 노드를 확인하는 함수
        {
            return GetLeftChildIndex(parentIndex) + 1;  // 좌측을 구하는 함수에서 배열서 + 1 을 추가하여 우측의 자식노드 반환
        }


    }
}
