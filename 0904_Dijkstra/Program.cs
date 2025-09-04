namespace _0904_Dijkstra {
    class Graph {
        // -1 은 연결되지 않음, 양수는 연결된 정점의 가중치
        int[,] adjacent = new int[8, 8] {
            { -1, 10, -1, 18, -1, -1, -1, -1 },
            { 10, -1, 05, 06, -1, -1, -1, -1 },
            { -1, 05, -1, -1, -1, -1, -1, -1 },
            { 18, 06, -1, -1, 13, -1, -1, -1 },
            { -1, -1, -1, 13, -1, 14, 08, -1 },
            { -1, -1, -1, -1, 14, -1, -1, 17 },
            { -1, -1, -1, -1, 08, -1, -1, 26 },
            { -1, -1, -1, -1, -1, 17, 26, -1 },
        };

        public void Dijkstra(int _start) {
            int arrayLength = 8;

            bool[] visited = new bool[arrayLength];
            int[] distance = new int[arrayLength];
            Array.Fill(distance, Int32.MaxValue);
            int[] parent = new int[arrayLength];

            distance[_start] = 0;
            parent[_start] = _start;

            while (true) {
                // 제일 좋은 후보 찾기 (최단 거리 후보)

                // 가장 유력한 후보의 거리와 번호를 저장
                int closest = Int32.MaxValue;
                int now = -1;

                // 각 정점을 순회 하면서 애당초 얘가 후보가 맞는지(연결이 되어있는지) 확인
                for (int i = 0; i < arrayLength; i++) {
                    // 이미 방문한 정점은 스킵
                    if (visited[i]) continue;

                    // 아직 발견(예약)된 적이 없거나, 기존 후보보다 멀면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue;
                    
                    closest = distance[i];
                    now = i;
                }

                // 후보군이 없는 경우
                if (now == -1) break;

                // 제일 좋은 후보 방문
                visited[now] = true;

                // 방문한 정점의 인접점을 확인해서 최단거리를 갱신해야함
                for(int next = 0; next < arrayLength; next++) {
                    // 연결이 되어있지 않은 정점 스킵
                    if (adjacent[now, next] == -1) continue;

                    // 이미 방문한 정점도 스킵
                    if (visited[next] == true) continue;
                    
                    // 새로 조사된 인접 정점의 최단거리 계산
                    int nextDist = distance[now] + adjacent[now, next];
                    // 위의 인접 정점의 최단거리를 갱신
                    if (nextDist < distance[next]) {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                    

                }
               
            }
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Graph graph = new Graph();
            graph.Dijkstra(0);

        }
    }
}