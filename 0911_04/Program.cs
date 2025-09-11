namespace _0911_04 {
    internal class Program {

        static void TransArrCW(int[,] arr) {
            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++) {
                    Console.Write($"{arr[j, i]}, ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args) {
            int[,] arr = new int[3, 3] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };
            TransArrCW(arr);

        }
    }
}
