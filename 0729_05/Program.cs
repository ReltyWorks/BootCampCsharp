namespace _0729_05 { // ref의 사용처
    internal class Program {
        static void Swap(ref int x, ref int y) {
            int temp = x;
            x = y;
            y = temp;
        }
        static void Main(string[] args) {
            int a = 99;
            int b = 1;

            Swap(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
