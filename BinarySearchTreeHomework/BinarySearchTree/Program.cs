namespace BinarySearchTree
{
    internal class Program
    {
        internal class BinarySearchTree<T> where T : IComparable<T>     // 비교가 가능한 자료형만
        {
            private Node root;                                  // 가장 높은 노드

            public BinarySearchTree()
            {
                this.root = null;                               // 가장 높은 노드는 처음 만들 때 null
            }

            public void Add(T item)         // 데이터 추가하는 함수
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
                        if (current.left != null)
                            current = current.left;             // 좌측 자식과 또 비교하기 위해 currnt 좌측자식으로 설정
                        // 비교 노드가 좌측 자식이 없는 경우
                        else
                        {
                            // 그 자리에 새로 추가해줌
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
                            // 그 자리에 새로 추가해줌
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
                if (root == null)                               // 배열에 개체가 아무것도 없을 때
                {
                    outValue = default(T);                      // 기본값 지정하고
                    return false;                               // false 반환
                }

                // 배열에 뭐라도 들어있을 때
                Node current = root;                            // 가장 높은 노드를 기준으로 시작

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
                    {
                        outValue = current.item;                // 찾은 개체 outValue에 넣어주고
                        return true;                            // ture 반환
                    }
                }

                // 못 찾았을 때
                outValue = default(T);                          // 기본값 지정하고
                return false;                                   // false 반환
            }

            private Node FindNode(T item)       // item이 있는 노드를 찾는 함수
            {
                if (root == null)                               // 배열에 개체가 아무것도 없을 때
                    return null;                                // false 반환

                // 배열에 뭐라도 들어있을 때
                Node current = root;                            // 가장 높은 노드를 기준으로 시작

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

            public bool Remove(T item)          // item이 있는 노드를 제거
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
                    ErageNode(findNode);                        // 제거 함수 사용 후
                    return true;                                // true 반환
                }
            }

            private void ErageNode(Node node)   // Remove에서 사용할 제거 처리 함수
            {
                // 자식노드가 없는 경우
                if (node.HasNoChild)
                {
                    // 지울 노드가 좌측 자식 노드일 경우
                    if (node.IsLeftChild)
                        node.parent.left = null;                // 자식 노드를 지워줌
                    // 지울 노드가 우측 자식 노드일 경우
                    else if (node.IsRightChild)
                        node.parent.left = null;                // 자식 노드를 지워줌
                    else // else if (node.IsRootNode)
                         // 가장 높은 노드일 경우
                        root = null;                            // 해당 노드, 즉 가장 높은 노드를 지워줌
                }

                // 자식노드가 하나만 있는 경우
                else if (node.HasLeftChild || node.HasRightChild)
                {
                    Node parent = node.parent;                                      // 부모 노드를 지정 
                    Node child = node.HasLeftChild ? node.left : node.right;        // 존재하는 자식 노드를 지정

                    // 지울 노드가 좌측 자식 노드일 경우
                    if (node.IsLeftChild)
                    {
                        parent.left = child;                    // 지울 노드의 부모 노드와 자식 노드를 서로 연결시켜서
                        child.parent = parent;                  // 이중탐색트리서 제거와 동일한 효과를 나타내게 함
                    }
                    // 지울 노드가 우측 자식 노드일 경우
                    else if (node.IsRightChild)
                    {
                        parent.right = child;                   // 지울 노드의 부모 노드와 자식 노드를 서로 연결시켜서
                        child.parent = parent;                  // 이중탐색트리서 제거와 동일한 효과를 나타내게 함
                    }
                    // 지울 노드가 가장 높은 노드일 경우
                    else // else if (node.IsRootNode)
                    {
                        root = child;                           // 자식 노드를 가장 높은 노드로 만들어주고
                        child.parent = null;                    // 지울 노드를 제거
                    }
                }
                // 자식노드가 둘 있는 경우
                // 힙 상태가 깨지지 않기 위해
                // 지울 노드의 좌측 노드 중 가장 큰 값과 데이터를 교환한 후, 그 노드를 지워주는 방식으로 대체
                else // else if (node.HasBothChild) 
                {
                    Node replaceNode = node.left;               // 지울 노드의 좌측 자식 노드로 이동 후

                    while (replaceNode.right != null)           // 우측 자식 노드가 더이상 없을 때 까지 반복           
                        replaceNode = replaceNode.right;        // 우측 자식 노드가 있으면 우측으로 이동

                    node.item = replaceNode.item;               // 지울 노드의 가장 큰 자식 노드를 지울 노드의 위치에 덮어써줌, 이중탐색트리 상 지울 노드가 제거됨
                    ErageNode(replaceNode);                     // 덮어쓰는데 사용한, 지울 노드의 가장 큰 자식 노드의 원래 위치에 있는 노드를 제거

                    /*  // 지울 노드의 우측 노드 중 가장 작은 값과 데이터를 교환하는 방식일 때
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
}