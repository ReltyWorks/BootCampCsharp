namespace _0730_01 { // 함수 구현
    internal class Program {
        static int SumBetween(int a, int b) {
            int n = 0;
            for (int i = a; i <= b; i++) {
                n += i;
            }
            return n;
        }
        static void Main(string[] args) {
            int result = SumBetween(1, 6);
            Console.WriteLine($"결과 : {result}");
        }
    }
}