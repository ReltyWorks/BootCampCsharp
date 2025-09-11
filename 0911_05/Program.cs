namespace _0911_05 {
    internal class Program {
        static void Add(int Y, int X) {
            int[,] map = new int[3, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 },
            };

            try {
                map[Y - 1, X]++;
            }
            catch { }

            try {
                map[Y, X - 1]++;
            }
            catch { }

            try {
                map[Y + 1, X]++;
            }
            catch { }

            try {
                map[Y, X + 1]++;
            }
            catch { }

            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    Console.Write($"{map[i, j]}, ");
                }
                Console.WriteLine();
            }
        }
        
        static void Main(string[] args) {
            Add(0, 0);
        }
    }
}
