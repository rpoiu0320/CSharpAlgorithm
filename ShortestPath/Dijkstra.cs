using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Dijkstra
    {
        /******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 * 직접 가는 거리보다 거쳐가는 거리가 적은 경우 경로를 대채하여 최단거리로 갱신해줌 
		 ******************************************************/

		// distance를 갱신하며 한 사이클 후 다음 검색의 기준은 방문하지 않은 노드 중 가장 빠른 distance를 기준으로 다시 돌림

		const int INF = 99999;	// max로 하면 오버플로우 가능성이 있어 이를 방지

		public static void SortestPath(in int[,] graph, int start, out int[] distance, out int[] path)		// path == parent
		{
			int size = graph.GetLength(0);
			bool[] visited = new bool[size];	// 방문했던곳
												
												// 처음 시작할 때
			distance = new int[size];			// 시작 노드에서의기본 거리, 바로 연결이 되어있는지
			path = new int[size];				// 단절이 되어있는지, 어디를 거쳐서 가는지

			for(int i = 0; i < size; i++)		// 시작세팅
			{
				distance[i] = graph[start, i];
				path[i] = graph[start, i] < INF ? start : -1;
			}

			for(int i = 0; i < size; i++)
			{
				// 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
				int next = 1;
				int minCost = INF;	// 현재 최단경로
				for(int j = 0; j < size; j++)
				{
					if (!visited[j] &&
						distance[j] < minCost)
					{
						next = j;
						minCost = distance[j];
					}
				}

				// 2. 직접 연결된 거리보다 거쳐서 더 짧아진다면 갱신
				for(int j = 0; j < size; j++)
				{
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리 
                    if (distance[j] > distance[next] + graph[next, j])
					{
						distance[j] = distance[next] + graph[next, j];
						path[j] = next;
                    }
				}
				visited[next] = true;
			}
		}
    }
}
