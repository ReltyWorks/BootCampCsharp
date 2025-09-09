namespace _0909_BJ1012 {
    internal class Program {
        static int[] deltaY = { -1, 0, 1, 0 };
        static int[] deltaX = { 0, -1, 0, 1 };

        static int M, N;

        static void DFS(int[,] _farm, bool[,] _visited, int _y, int _x) {
            _visited[_y, _x] = true;

            for (int i = 0; i < 4; i++) {
                int nextY = _y + deltaY[i];
                int nextX = _x + deltaX[i];

                if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= M)
                    continue;

                if (_farm[nextY, nextX] == 1 && !_visited[nextY, nextX]) {
                    DFS(_farm, _visited, nextY, nextX);
                }
            }
        }


        static int Quest() {

            int[] rule = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            M = rule[0];
            N = rule[1];

            int[,] farm = new int[rule[1], rule[0]];

            for (int i = 0; i < rule[2]; i++) {
                int[] seed = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                farm[seed[1], seed[0]] = 1;
            }

            int worm = 0;

            bool[,] visited = new bool[rule[1], rule[0]];


            for (int i = 0; i < rule[1]; i++) {
                for (int j = 0; j < rule[0]; j++) {
                    if (farm[i, j] == 1 && !visited[i, j]) {
                        worm++;
                        DFS(farm, visited, i, j);
                    }
                }
            }

            return worm;
        }

        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) Console.WriteLine(Quest());
        }
    }
}