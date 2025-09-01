namespace _0901_03 {
    class Graph {
        int[,] adj = new int[6, 6] {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };
        bool[] found = new bool[6];
        int[] parant = new int[6]; // parant[0] => 0번 정점의 부모가 누구야?
        int[] distance = new int[6]; // distance[0] 해당 정점까지 걸린 길이 몇개야? 

        public void BFS(int _start) {
            // 예약 목록
            Queue<int> queue = new Queue<int>();
            // 예약 목록에 예약하기
            queue.Enqueue(_start);
            // 방문 처리하기
            found[_start] = true;
            parant[_start] = _start;
            distance[_start] = 0;

            while (queue.Count > 0) {
                // 예약 목록에서 예약을 꺼내와서
                int now = queue.Dequeue();
                Console.WriteLine($"방문 : {now}");
                // 아직 예약 안한애들 전부 예약하기
                for (int next = 0; next < 6; next++) {
                    // 연결이 안되어있으면 넘기고
                    if (adj[now, next] == 0) continue;
                    // 연결이 되어있으면 이미 예약이 되어있는지 확인
                    if (found[next]) continue;

                    // 예약하기
                    queue.Enqueue(next);
                    // 예약한놈을 찾은 놈으로 설정
                    found[next] = true;
                    // 찾은놈의 부모는 now
                    parant[next] = now;
                    // 찾은놈의 거리는 = 부모 + 1을 해주면 됨
                    distance[next] = distance[now] + 1;
                }
            }
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Graph graph = new Graph();
            graph.BFS(0);
        }
    }
}