using System;
using System.Collections.Generic;

namespace _0909_BJ2178 {
    class Pos {
        public int Y { get; }
        public int X { get; }
        public Pos(int y, int x) { Y = y; X = x; }
    }

    public class Program {
        public static void Main(string[] args) {
            int[] rule = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = rule[0];
            int M = rule[1];

            int[,] maze = new int[N, M];

            for (int i = 0; i < N; i++) {
                string line = Console.ReadLine();
                for (int j = 0; j < M; j++) {
                    maze[i, j] = line[j] - '0'; // '1' -> 1, '0' -> 0으로 변환
                }
            }

            // BFS를 통해 각 지점까지의 최단 거리가 기록된 배열
            int[,] distance = BFS(N, M, maze);

            // 목표 지점인 (N-1, M-1)에 저장된 값이 바로 최단 거리
            Console.WriteLine(distance[N - 1, M - 1]);
        }

        public static int[,] BFS(int _n, int _m, int[,] _maze) {
            // 상하좌우 이동을 위한 배열
            int[] deltaY = { -1, 1, 0, 0 };
            int[] deltaX = { 0, 0, -1, 1 };

            // 각 칸까지의 거리를 저장할 int[,] distance 배열
            // 0은 아직 방문하지 않았다는 의미로 사용함
            int[,] distance = new int[_n, _m];

            Queue<Pos> queue = new Queue<Pos>();

            // 시작점 (0, 0)을 큐에 넣고, 거리를 1로 설정.
            queue.Enqueue(new Pos(0, 0));
            distance[0, 0] = 1;

            while (queue.Count > 0) {
                Pos current = queue.Dequeue();
                int nowY = current.Y;
                int nowX = current.X;

                // 상하좌우 4방향 탐색
                for (int i = 0; i < 4; i++) {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];

                    // 1. 미로 범위를 벗어나는지 확인
                    if (nextY < 0 || nextY >= _n || nextX < 0 || nextX >= _m)
                        continue;

                    // 2. 갈 수 없는 벽('0')이거나, 이미 방문한 곳인지 확인
                    // distance가 0이 아니라는 건 이미 더 빠른 경로로 방문했다는 뜻
                    if (_maze[nextY, nextX] == 0 || distance[nextY, nextX] != 0)
                        continue;

                    // 3. 다음 위치까지의 거리 계산 및 큐에 추가
                    // 현재 칸까지의 거리 + 1 을 다음 칸에 기록
                    distance[nextY, nextX] = distance[nowY, nowX] + 1;
                    queue.Enqueue(new Pos(nextY, nextX));
                }
            }

            // 거리가 모두 기록된 배열을 반환
            return distance;
        }
    }
}