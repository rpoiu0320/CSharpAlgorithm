using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>     // 비교가 가능한 자료형만
    {
        private Node root;                                  // 가장 높은 노드

        public BinarySearchTree()
        {
            this.root = null;                               // 가장 높은 노드는 처음 만들 때 null
        }

        public void Add(T item)                             // 데이터 추가하는 함수
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)                               // 처음으로 데이터를 넣을 때
            {
                root = newNode;                             // 가장 높은 노드에 새로운 노드를 넣어줌
                return;
            }

            Node current = root;                            // 현재노드
            while (current != null)                         // 배열에 데이터가 하나 이상 있을 때
            {
                // 비교해서 더 작은 경우 좌측으로 감
                if (item.CompareTo(current.item) < 0)
                {
                    // 비교 노드가 좌측 자식이 있는 경우
                    if(current.left != null)
                        current = current.left;             // 좌측 자식과 또 비교하기 위해 currnt 좌측자식으로 설정
                    // 비교 노드가 좌측 자식이 없는 경우
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.left = newNode;             // 새로운 노드를 좌측 자식에 넣어줌
                        newNode.parent = current;           // 새로운 노드의 부모 노드는 현재 노드를 가리키게 됨
                        return;
                    }
                }
                // 비교해서 더 큰 경우 오른쪽으로 감
                else if (item.CompareTo(current.item) > 0)
                {
                    // 비교 노드가 우측 자식이 있는 경우
                    if (current.right != null)
                        current = current.right;            // 우측 자식과 또 비교하기 위해 current 우측 자식으로 설정
                    // 비교 노드가 우측 자식이 없는 경우
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.right = newNode;            // 새로운 노드를 우측 자식에 넣어줌
                        newNode.parent = current;           // 새로운 노드의 부모 노드는 현재 노드를 가리키게 됨
                        return;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                    return;     // 아무것도 안함
            }
        }
        public bool TryGetValueUseFindNode(T item, out T outValue)  // FindNode함수를 이용한 탐색
        {
            if (root == null)                               // 배열에 개체가 아무것도 없을 때
            {
                outValue = default(T);                      // 기본값 지정하고
                return false;                               // false 반환
            }

            Node findNode = FindNode(item);                 // FindNode로 탐색 중인 item 확인

            // item 이 없으면
            if (findNode == null)           
            {
                outValue = default(T);                      // 기본값 지정하고
                return false;                               // false 반환
            }
            // item 이 있으면 
            else
            {
                outValue = findNode.item;                   // outValue에 찾은 item 넣어주고
                return true;                                // ture 반환
            }
        }

        public bool TryGetValue(T item, out T outValue)     // FindNode함수 없이 탐색
        {
            if(root == null)                                // 배열에 개체가 아무것도 없을 때
            {
                outValue = default(T);                      // 기본값 지정하고
                return false;                               // false 반환
            }

            Node current = root;                            // 배열에 뭐라도 들어있을 때
            while(current != null)      
            {
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                    current = current.left;                 // 좌측 자식부터 다시 찾기 시작
                // 현재 노드의 값이 찾고자 하는 값보다 큰 경우
                else if( item.CompareTo(current.item) > 0)
                    current = current.right;                // 우측 자식부터 다시 찾기 시작
                // 찾았을 때
                else  
                {
                    outValue = current.item;                // 찾은 개체 outValue에 넣어주고
                    return true;                            // ture 반환
                }
            }

            // 못 찾았을 때
            outValue = default(T);                          // 기본값 지정하고
            return false;                                   // false 반환
        }

        private Node FindNode(T item)   
        {
            if (root == null)                               // 배열에 개체가 아무것도 없을 때
                return null;                                // false 반환

            Node current = root;                            // 배열에 뭐라도 들어있을 때
            while (current != null)
            {
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                    current = current.left;                 // 좌측 자식부터 다시 찾기 시작
                // 현재 노드의 값이 찾고자 하는 값보다 큰 경우
                else if (item.CompareTo(current.item) > 0)
                    current = current.right;                // 우측 자식부터 다시 찾기 시작
                // 찾았을 때
                else
                    return current;                         // ture 반환
            }
            // 못 찾았을 때
            return null;                                    // false 반환
        }

        public bool Remove(T item)          // 제거
        {
            Node findNode = FindNode(item);                 // 제거할 item을 찾고

            // 제거할게 없으면
            if (findNode == null)                            
            {
                return false;                               // false 반환
            }
            // 제거할게 있으면
            else
            {
                ErageNode(findNode);                        // 제거 함수 사용
                return true;
            }
        }

        private void ErageNode(Node node)   // Remove에서 사용할 제거 처리 함수
        {
            // 자식노드가 없는 경우
            if(node.HasNoChild)
            {
                // 지울 노드가 좌측 자식 노드일 경우
                if (node.IsLeftChild)
                    node.parent.left = null;
                // 지울 노드가 우측 자식 노드일 경우
                else if (node.IsRightChild)
                    node.parent.left = null;
                else // else if (node.IsRoonNode)
                    root = null;
            }

            // 자식노드가 하나만 있는 경우
            else if (node.HasLeftChild ||  node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;

                // 지울 노드가 좌측 자식 노드일 경우
                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                // 지울 노드가 우측 자식 노드일 경우
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                // 지울 노드가 루트 노드일 경우
                else // else if (node.IsRootNode)
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 자식노드가 둘 있는 경우
            // 좌측 노드 중 가장 큰 값과 데이터를 교환한 후, 그 노드를 지워주는 방식으로 대체
            else // else if (node.HasBothChild) 
            {
                Node replaceNode = node.left;
                while (replaceNode.right != null)
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                ErageNode(replaceNode);

                /*
                Node replaceNode = node.right;
                while (replaceNode.left != null)
                {
                    replaceNode = replaceNode.left;
                }
                node.item = replaceNode.item;
                ErageNode(replaceNode); 
                */
            }

        }

        public void Print()
        {
            Print(root);
        }

        public void Print(Node node)
        {
            if(node.left != null) Print(node.left);
            Console.WriteLine(node.item);
            if(node.right != null) Print(node.right);
        }

        public class Node
        {
            internal T item;                                // 데이터
            internal Node parent;                           // 부모노드
            internal Node left;                             // 좌측 자식노드
            internal Node right;                            // 우측 자식노드


            public Node(T item, Node parent, Node left, Node right)     // 생성자로 변수들 지정
            {
                this.item = item;       
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            // 해당 노드가 좌측 자식 노드일 경우
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }

            // 해당 노드가 우측 자식 노드일 경우
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            // 해당 노드가 가장 높은, RootNode일 경우
            public bool IsRootNode { get { return parent == null; } }

            // 자식 노드가 없는 경우
            public bool HasNoChild { get { return left == null && right == null; } }

            // 자식 노드가 좌측만 있는 경우
            public bool HasLeftChild { get { return left != null && right == null; } }

            // 자식 노드가 우측만 있는 경우
            public bool HasRightChild { get { return left == null && right != null; } }

            // 자식 노드가 둘 다 있는 경우
            public bool HasBothChild { get { return left != null && right != null; } }
        }

    }
}
