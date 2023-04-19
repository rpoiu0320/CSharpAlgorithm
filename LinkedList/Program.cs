namespace LinkedList
{
    internal class Program
    {
        /******************************************************
		 * 연결리스트 (Linked List)
		 * 
		 * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
		 * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음 (다음/이전 데이터의 위치를 각 노드가 참조하고 있음)
		 * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
		 * 배열처럼 꽉 차있을 경우가 없음
		 * 힙영역에 연속적으로 두지 않고 따로따로 데이터 저장
		 * 맨 뒤 데이터의 후번 노드는 null
		 * index의 개념은 없음
		 * 
		 * 일발성형 데이터들을 사용할 때 예) 뱀서의 몬스터 생성, 삭제 | 슈팅게임 탄막 | 이펙트들?
		 * 가비지 콜렉터에 부담을 많이 줌, 때문에 C#에서는 노드 기반 자료구조는 잘 사용되지 않음
		 * 삽입, 삭제가 무엇보다 빨라야 할 때 사용
		 * 
		 * 
		 * // <LinkedList의 시간복잡도>
         * 접근		탐색		삽입		삭제
         * O(n)		O(n)	O(1)	O(1)
         *
         * 접근이 O(n)인 이유
         * 데이터들이 파편화 되어있어 배열처럼 데이터의 주소를 계산해서 가는게 아니라 
         * 노드를 따라가 데이터를 찾는 형식이기 때문
		 * 
		 * 
		 * -----------------
		 * | 노 | 데이터 | 노 |
		 * | 드 |       | 드 |
		 * -----------------
		 ******************************************************/

        // <링크드리스트 사용>
        void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제     O(n)
            linkedList.Remove("1번 앞데이터");

            // 링크드리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous;
            LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제     O(1)        이걸 기준으로 삭제
            linkedList.Remove(findNode);
        }

        static void Main(string[] args)
        {
            DataStructure.LinkedList<int> linkedList = new DataStructure.LinkedList<int>();

            linkedList.AddFirst(0);
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);
        }
    }
}