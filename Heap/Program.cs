namespace Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap)
		 * 
		 * 이진트리 형태의 자료구조(토너먼트 생각하면 편함)
		 * 우선순위Queue
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 * 
		 * 트리구조 조건
		 * 하나의 부모노드가 여러개의 자식노드를 가질 수 있다.
		 * 자식노드가 부모노드를 가리키는 순환구조(역순)가 아니여야 한다.
		 * 순환구조이면 그래프라고 함
		 * 트리나 그래프들은 순서가 없는 비선형 자료구조
		 * 
		 * 이진트리, 헥사트리, 옥타트리 등 찾아보기
		 * 
		 * 예) 각 상황에 맞는 몬스터의 행동(방어, 공격, 도망 등)
		 ******************************************************/

        static void PriorityQueue()
        {
            // 기본 int 우선순위(오름차순) 적용
            PriorityQueue<string, int> pq1 = new PriorityQueue<string, int>();

            pq1.Enqueue("감자", 3);     // 우선순위와 데이터를 추가
            pq1.Enqueue("양파", 5);
            pq1.Enqueue("당근", 1);
            pq1.Enqueue("토마토", 2);
            pq1.Enqueue("마늘", 4);

            while (pq1.Count > 0) Console.WriteLine(pq1.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력


            // 수정 int 우선순위 적용
            PriorityQueue<string, int> pq2 = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a)); // 내림차순

            pq2.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq2.Enqueue("데이터2", 3);
            pq2.Enqueue("데이터3", 5);
            pq2.Enqueue("데이터4", 2);
            pq2.Enqueue("데이터5", 4);

            while (pq2.Count > 0) Console.WriteLine(pq2.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력
        }

        // 시간복잡도
        // 탐색(가장우선순위높은)     추가      삭제
        // 0(1)                  0(logN)   0(logN)
        static void Main(string[] args)
        {
            PriorityQueue();
        }
    }
}