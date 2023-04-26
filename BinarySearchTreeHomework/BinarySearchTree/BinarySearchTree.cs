using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BinarySearchTree.Program.BinarySearchTree<string>;

namespace BinarySearchTree
{
    // <이진탐색트리의 시간복잡도>
    // 접근			탐색			삽입			삭제
    // O(log n)		O(log n)	O(log n)	O(log n)

    /* <이진탐색트리의 한계점과 극복방법>
     * 
     * 완전이진트리를 보장하지 않음
     * 개체가 들어오는 순서에 따라 모양이 달라짐
     * LinkedList처럼 노드를 사용하기에 c#에서는 대규모 데이터 탐색 외에는 잘 사용되지 않음
     * 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능! 중요
     * 불균형이 발생하면 탐색영역이 절반으로 줄여지지 않기 때문에 
     * O(logn)이 보장되지 않아 O(n)에 근접하게 시간복잡도가 증가하게됨
     * 
     * 불균형 현상을 막기 위해 자가균형기능이 추가된 Red-Black Tree, AVL Tree 등을 사용하게됨
     * 자가균형기능은 최악의 경우에도 균형이 잘 유지되도록 도와줌
     * 즉 삽입, 삭제 시 높이를 가능한 낮게 만들어줌
     * 자가균형기능이 추가되어 효율성이 증가하지만 그만큼 삽입과 삭제 연산이 복잡해지게됨
     * 불균형이 되면 노드들을 좌회전 혹은 우회전하며 불균형을 해결함
     * 
     * Red-Black Tree
     * 모든 노드들을 Red, Black으로 구분하고 규칙에 따라 노드들을 정리하여 
     * 균형성을 보장해줌
     * 
     * AVL Tree
     * Red-Black Tree에서 균형조건을 더 강화시킨 트리
     * 균형인수(좌측 자식노드의 높이에서 우측 자식노드의 높이를 뺀 값)을 이용하여 불균형을 해결함
     * 각 노드에서 좌측 자식노드와 우측 자식노드의 높이 차이가 1을 넘지 않도록 해줌
     * 즉 균형 인수가 -1, 0 , 1 중 하나여야만 함
     */

    /* <트리기반 자료구조의 순회>
     * 트리 순회란 그래프 순회의 한 형태로 트리 자료 구조에서 각 노드를 정확히 한 번 방문하는 과정
     * 1. 전위(Pre-Order) 순회 (NLR): 노드, 좌측, 우측
     * 현재 노드를 순회한 후 좌측, 우측 자식노드 순으로 순회
     * 
     * 2. 중위(In-Order)순회 (LNR): 좌측, 노드, 우측		<- 이진탐색트리의 순회 : 오름차순 정렬
     * 좌측 자식노드를 순회 후 현재 노드, 우측 자식노드 순으로 순회
     * 
     * 3. 후위(Post-Order)순회 (LRN) : 좌측, 우측, 노드 
     * 좌측, 우측 자식노드 순으로 순회 후 현재 노드를 순회
     * 
     * 순회 방식 별 트리 순회 예시
     * 
     *                      [F]
     *                  /         \
     *             [B]               [I]
     *            /   \            /     \
     *        [A]       [D]     [H]        [M]
     *                 /   \       \      /   \
     *               [C]   [E]     [G]  [J]   [L]
     *                                           \
     *                                          [K]       
     * 
     * 전위순휘(NLR) : F, B, A, D, C, E, I, H, G, M, J, L, K
     * 중위순회(LNR) : A, B, C, D, E, F, G, H, I, J, K, L, M
     * 후위순회(LRN) : A, C, E, D, B, G, H, J, K, L, M ,I, F
     */
    internal class BinarySearchTree
    {

        public void NLR(Node node)  // 전위순휘
        {
            Console.WriteLine(node.item);
            if (node.left != null)
                Console.WriteLine((node.left));
            if (node.right != null)
                Console.WriteLine((node.right));
        }
        public void LNR(Node node)  // 중위순회
        {
            if (node.left != null)
                Console.WriteLine((node.left));
            Console.WriteLine(node.item);
            if (node.right != null)
                Console.WriteLine((node.right));
        }
        public void LRN(Node node)  // 후위순회
        {
            if (node.left != null)
                Console.WriteLine((node.left));
            if (node.right != null)
                Console.WriteLine((node.right));
            Console.WriteLine(node.item);
        }
    }
}
