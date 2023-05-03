using ShortestPath;

namespace _12._ShortestPath
{
    internal class Program
    {
        const int INF = 99999;

        static void Main(string[] args)
        {
            int[,] graph = new int[9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };

            int[] distance;
            int[] path;
            Dijkstra.SortestPath(in graph, 0, out distance, out path);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, path);

            Console.WriteLine();

            int[,] costTable;
            int[,] pathTable;
            FloydWarshall.ShortestPath(graph, out costTable, out pathTable);
            Console.WriteLine("<Floyd-Warshall>");
            PrintFloydWarshall(costTable, pathTable);

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

        private static void PrintFloydWarshall(int[,] costTable, int[,] pathTable)
        {
            Console.WriteLine("Cost table");
            for (int y = 0; y < costTable.GetLength(0); y++)
            {
                for (int x = 0; x < costTable.GetLength(1); x++)
                {
                    if (costTable[y, x] >= INF)
                        Console.Write("INF ");
                    else
                        Console.Write("{0,3} ", costTable[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Path table");
            for (int y = 0; y < pathTable.GetLength(0); y++)
            {
                for (int x = 0; x < pathTable.GetLength(1); x++)
                {
                    if (pathTable[y, x] < 0)
                        Console.Write("  X ");
                    else
                        Console.Write("{0,3} ", pathTable[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}