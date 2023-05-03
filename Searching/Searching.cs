using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Searching
    {
        // 선형 자료구조의 탐색

        // <순차 탐색>
        // 앞에서부터 순차적으로 탐색
        // 시간 복잡도는 O(n)
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IEquatable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }

        // <이진 탐색>
        // 찾으려는 데이터와 중간점위치에 있는 데이터를 반복적으로 비교하여 데이터를 탐색
        // 데이터가 많을수록 효율 극대화
        // 시간 복잡도는 O(log n)
        // BinarySerach는 사용 전 반드시 정렬을 하고 사용해야 함
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;

            while(low <= high)
            {
                // int middle = (low + high) >> 1;        컴퓨터의 연산은 나눗셈이 다른 연산에 비하여 비교적 느리고 비트 연산이 가장 빠름,
                //                                        따라서 나눌려는 수가 2, 2의 제곱들일 경우 비트 연산을 활용하면 효율적임
                 
                int middle = (int)((low + high) * 0.5f);    // 나누기 2
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                    low = middle + 1;
                else if (compare > 0)
                    high = middle - 1;
                else
                    return middle;
            }
            return -1;
        }

        // 비선형 자료구조의 탐색

        // 그래프 서치 알고리즘 DFS, BFS

        // <깊이 우선 탐색>(Depth first search)
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤, 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 탐색한 여부를 체크해주는 visited, 어떤 경로를 통하여 갔는지 parent
        // 스택을 활용
        // 백트래킹(분할정복)
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }
            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i ] &&         // 연결되어 있는 정점이며
                    !visited[i])                // 방문한 적 없는 정점
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }


        // <너비 우선 탐색>(Breadth first search)
        // 그래프의 분기를 만났을 때 모든 분기를 하나씩 저장하고, 저장한 분기를 한 번씩 거치면서 탐색
        // 큐를 활용
        // 동적계획과 유사
        public static void BFS(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while(bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[start, i] &&         // 연결되어 있는 정점이며
                        !visited[i])                // 방문한 적 없는 정점
                    {
                        parents[i] = start;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}
