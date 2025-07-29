namespace _0729_04 { // 메서드의 활용
    internal class Program {

        static public bool closeSign = false;

        /// <summary>
        /// 어허 이런 좋은 기능이?
        /// </summary>
        /// <param name="n">이건또 무언고</param>
        /// <returns>무엇에 쓰는 물건이고</returns>
        static string Quiz(int n) {

            int inputN = int.Parse(Console.ReadLine());

            if (inputN == n) {
                closeSign = true;
                return "정답입니다.";
            }
            else return "";

        }
        static void Main(string[] args) {

            const int answer = 3;

            Console.WriteLine("1~7 사이에 범인이 있습니다!");
            Console.WriteLine("10번 안에 정답을 입력하세요.");

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(Quiz(answer));
                if (closeSign) break;
            }

            if (!closeSign) Console.WriteLine("틀렸습니다.");
        }
    }
}
