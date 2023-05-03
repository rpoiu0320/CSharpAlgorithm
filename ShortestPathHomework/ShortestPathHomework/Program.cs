using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace ShortestPathHomework
{
    internal class Program
    {
        const int INF = 99999; // 경로가 단절됐음을 뜻함


        public static void SortesPath(int[,] graph, int start, out int[] distance, out int[] path)
        //                       입력받을 그래프, 기준점으로 지정할 노드, 걸린 총 거리, 원하는 노드를 가기위해 거쳐간 노드
        {
            int size = graph.GetLength(0);                          // 그래프의 행을 size로 설정
            bool[] visited = new bool[size];                        // 해당 노드를 통하여 다른 노드에 방문하였는지 확인할 변수
                                                                    // 모두 false로 저장됌

            distance = new int[size];                               // 노드 간 거리
            path = new int[size];                                   // 바로 이전에 방문한 노드

            for(int i = 0 ; i < size; i++)                          // 초기 설정
            {
                distance[i] = graph[start,i];                       // 기준점의 각 노드 별 거리를 저장
                path[i] = graph[start, i] < INF ? start : -1;       // 기준점과 각 노드가 연결되어 있다면, 연결되어 있지 않다면
                                                                    // 기준점과 각 노드 별 거리를 저장,  -1을 저장하여 연결되지 않음을 뜻해줌(자가회신도 -1) 
            }

            for(int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = 1;           // 
                int minCost = INF;      // 현재 최단경로
                for(int j = 0; j < size; j++)
                {
                    if (!visited[j] &&                              // 해당 노드로 각 노드들을 방문하지 않았고
                        distance[j] < minCost)                      // 연결이 되어 있다면
                    {
                        next = j;                                   // 거쳐갈 노드로 지정
                        minCost = distance[j];                      // 최단 경로로 설정
                    }
                }
                // 2. 직접 연결된 거리보다 다른 노드를 거쳐가는게 더 짧아진다면 갱신
                for (int j = 0; j < size; j++)
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리 
                    if (distance[j] > distance[next] + graph[next, j])  // 기준점과 연결된 노드(distance[next])의 거리 + 연결된 노드에서 해당 노드(graph[next, j])의 거리가 
                                                                        // 기준점에서 해당 노드(distance[j])의 거리보다 낮다면(빠르다면)
                    {
                        distance[j] = distance[next] + graph[next, j];  // 최단 거리를 갱신
                        path[j] = next;                                 // 해당 노드[j]로 가기 위한 최단 경로에서 해당 노드 바로 전 노드를 path[j]에 저장해줌
                    }
                }
                visited[next] = true;                                   // 해당 노드로 각 노드들을 방문하였음을 알려줌
            }
        }

        static void Main(string[] args)
        {

            int[,] graph = new int[8, 8]
            {
                {   0,   8,   3,   2,   5, INF, INF, INF},
                {   8,   0, INF, INF, INF, INF, INF,   9},
                {   3, INF,   0, INF, INF, INF, INF, INF},
                {   2, INF, INF,   0, INF, INF, INF,   9},
                {   5, INF, INF, INF,   0, INF, INF,   3},
                { INF, INF, INF, INF, INF,   0,   5, INF},
                { INF,   2, INF, INF, INF,   5,   0, INF},
                { INF, INF, INF,   9,   3, INF, INF,   0},
            };

            int[] distance;
            int[] path;
            SortesPath(graph, 0, out distance, out path);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, path);


        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("dist");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }
    }
}