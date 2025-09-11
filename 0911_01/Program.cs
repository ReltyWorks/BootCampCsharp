namespace _0911_01 {

    class Quiz {
        public void Swap(ref int _x, ref int _y) {
            int temp = _x;
            _x = _y;
            _y = temp;
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Quiz quiz = new Quiz();

            int x = 10;
            int y = 20;
            quiz.Swap(ref x, ref y);

            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
