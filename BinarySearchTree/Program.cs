namespace BinarySearchTree_
{
    internal class Program
    {   /******************************************************
		 * 트리 (Tree)	조직도 생각하면 편함
		 * 
		 * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
		 * 재귀의 톡성을 가짐
		 * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
		 * 순환구조를 가지지 않고, 부모 노드가 하나여야 하며, 루트도 하나여야 함
         ******************************************************/

        /******************************************************
		 * 이진탐색트리 (BinarySearchTree) BST
		 * 
		 * 이진속성과 탐색속성을 적용한 트리
		 * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
		 * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
		 * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
		 * 완전이진트리를 보장하지 않음
		 * 개체가 들어오는 순서에 따라 모양이 달라짐
		 * LinkedList처럼 노드를 사용하기 떄문에 c#에 한해서 잘 사용되지 않음
		 * 
		 * 대규모 데이터 탐색에 사용됌
		 ******************************************************/

        // <이진탐색트리의 시간복잡도>
        // 접근			탐색			삽입			삭제
        // O(log n)		O(log n)	O(log n)	O(log n)

        // <이진탐색트리의 주의점>
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능! 중요
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가!
        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적!
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등이 있음

        // 이진탐색트리의 한계점과 극복법 기술면접

        /* <트리기반 자료구조의 순회>
		 * 1. 전위순회 : 노드, 좌측, 우측
		 * 2. 중위순회 : 좌측, 노드, 우측		<- 이진탐색트리의 순회 : 오름차순 정렬
		 * 3. 후위순회 : 좌측, 우측, 노드
		 */

        void BinarySearchTree()
		{
			// value 이진탐색트리
			SortedSet<int> sortedSet = new SortedSet<int> ();

			// 추가
			sortedSet.Add (0);
			sortedSet.Add (1);
			sortedSet.Add (2);
			sortedSet.Add (3);
			sortedSet.Add (4);
			sortedSet.Add (5);

			// 탐색
			int searchValue1;
			bool find = sortedSet.TryGetValue(3, out searchValue1); // 탐색시도

			// 삭제
            sortedSet.Remove (3);

			// 탐색용 키, 실제 데이터
			// key, value 이진탐색트리
			// 이진탐색트리를 사용할 때는 SortedDictionay를 많이 사용함
			SortedDictionary<int, string> sortedDic = new SortedDictionary<int, string>();
            SortedDictionary<string, Monster> strSortedDic = new SortedDictionary<string, Monster>();

			strSortedDic.Add("피카츄", new Monster() { name = "피카츄", hp = 100 });
            strSortedDic.Add("파이리", new Monster() { name = "파이리", hp = 120 });
            strSortedDic.Add("꼬부이", new Monster() { name = "꼬부기", hp = 80 });

			Monster monster;
			strSortedDic.TryGetValue("파이리", out monster);   // 파이리 탐색 시도
			Monster indexerMonster = strSortedDic["파이리"];   // 인덱서를 통한 탐색

			strSortedDic.Remove("꼬부기");


		}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

		class Monster
		{
			public string name;
			public int hp;
			public int mp;

		}
    }
}