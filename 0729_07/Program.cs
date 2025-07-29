namespace _0729_07 { // 포문 복습
    internal class Program {
        static void Main(string[] args) {
            // 구구단
            int num = int.Parse(Console.ReadLine());
            for(int i = 1; i < 10; i++) {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
            Console.WriteLine("");

            // 별찍기
            for (int i = 5; i > 0; i--) {
                for (int ii = 0; ii < i - 1; ii++) {
                    Console.Write("*");
                }
                Console.WriteLine("*");
            }
            Console.WriteLine("");
            for (int i = 0; i < 5; i++) {
                for (int ii = 0; ii < i; ii++) {
                    Console.Write("*");
                }
                Console.WriteLine("*");
            }
        }
    }
}
