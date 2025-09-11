namespace _0911_02 {
    internal class Program {
        static void Main(string[] args) {
            int[] a = { 15, 3, 9, 27, -5, 8, 99 };
            int max = 0;
            int min = 100;

            for (int i = 0; i < a.Length; i++) {
                if (a[i] > max)
                    max = a[i];
                if (a[i] < min)
                    min = a[i];
            }

            Console.WriteLine(max);
            Console.WriteLine(min);
        }
    }
}
