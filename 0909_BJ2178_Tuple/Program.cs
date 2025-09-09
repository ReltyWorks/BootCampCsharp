using System;
using System.Collections.Generic;

namespace _0909_BJ2178_Tuple {

    public class Program {
        public static void Main(string[] args) {
            int[] rule = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = rule[0];
            int M = rule[1];

            int[,] maze = new int[N, M];

            for (int i = 0; i < N; i++) {
                string line = Console.ReadLine();
                for (int j = 0; j < M; j++) {
                    maze[i, j] = line[j] - '0';
                }
            }

            int[,] distance = BFS(N, M, maze);

            Console.WriteLine(distance[N - 1, M - 1]);
        }

        // BFS 메서드 내부에서 Pos 대신 (int, int) 튜플을 사용하도록 수정
        public static int[,] BFS(int _n, int _m, int[,] _maze) {
            int[] deltaY = { -1, 1, 0, 0 };
            int[] deltaX = { 0, 0, -1, 1 };

            int[,] distance = new int[_n, _m];

            // ▼▼▼ 1. Queue의 타입을 튜플로 변경 ▼▼▼
            // Queue<Pos> -> Queue<(int Y, int X)>
            Queue<(int Y, int X)> queue = new Queue<(int, int)>();

            // ▼▼▼ 2. 시작점을 튜플로 Enqueue ▼▼▼
            queue.Enqueue((0, 0));
            distance[0, 0] = 1;

            while (queue.Count > 0) {
                // ▼▼▼ 3. Dequeue 할 때 튜플 분해(Deconstruction)로 바로 변수에 할당 ▼▼▼
                (int nowY, int nowX) = queue.Dequeue();

                for (int i = 0; i < 4; i++) {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];

                    if (nextY < 0 || nextY >= _n || nextX < 0 || nextX >= _m)
                        continue;

                    if (_maze[nextY, nextX] == 0 || distance[nextY, nextX] != 0)
                        continue;

                    distance[nextY, nextX] = distance[nowY, nowX] + 1;

                    // ▼▼▼ 4. 다음 위치도 튜플로 Enqueue ▼▼▼
                    queue.Enqueue((nextY, nextX));
                }
            }

            return distance;
        }
    }
}
