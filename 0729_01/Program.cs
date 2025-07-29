namespace _0729_01 {
    internal class Program {
        static void Main(string[] args) {

            int job = 0;

            Console.WriteLine("===============================");
            Console.WriteLine("     [직업을 선택하세요]");
            Console.WriteLine("===============================");
            Console.WriteLine("   1. 전사, 2. 법사, 3. 도둑");
            Console.Write("번호를 입력하세요 : "); // 요부분이 틀렸다!
            // 틀렸다기보단, 출제자의 의도를 파악하지 못한거지만,
            // 그게 틀린거지!

            while (true) {
                job = int.Parse(Console.ReadLine());
                if (job == 1 || job == 2 || job == 3) break;
                Console.WriteLine("1, 2, 3 중에 선택하세요.");
            } // 아쉽게, 숫자가 아닌 텍스트까지 걸러주진 못했다..
            // 스트링으로 받아서 트라이파스로 거를걸 그랬다.

            if (job == 1) Console.WriteLine("전사를 선택하셨습니다.");
            else if (job == 2) Console.WriteLine("법사를 선택하셨습니다.");
            else Console.WriteLine("도둑을 선택하셨습니다.");
        }
    }
}