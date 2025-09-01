namespace _0901_01 {

    class Graph {
        int[,] adj = new int[6, 6] {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };
        bool[] visited = new bool[6];

        public void DFS(int _now) {
            // 1. _now 부터 방문 후 방문 체크
            Console.WriteLine($"방문 : {_now}");
            visited[_now] = true;

            // 2. _now 와 연결된 정점들을 하나씩 확인,
            //    아직 방문하지 않은 정점을 방문
            for (int next = 0; next < adj.GetLength(1); next++) {
                if (adj[_now, next] == 0) continue;
                if (visited[next] == true) continue;
                DFS(next);
            }
        }

        public void SearchAll() {
            for (int i = 0; i < visited.Length; i++) {
                if (!visited[i]) DFS(i);
            }
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Graph graph = new Graph();
            graph.SearchAll();
        }
    }
}