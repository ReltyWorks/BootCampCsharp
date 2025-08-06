// static 에 대한 사용례
namespace _0806_04 {
    class Knight {
        public static int count = 0;

        public int hp;
        public int id;

        public Knight() { // 기본 생성자 수정.
            hp = 100;
            id = count++;
        }

        public void Info() {
            Console.WriteLine($"기사 ID : {id}, 체력 : {hp}");
        }

    }
    internal class Program {
        static void Main(string[] args) {
            Knight knight0 = new Knight();
            Knight knight1 = new Knight();
            knight0.Info();
            knight1.Info();

            Console.WriteLine($"현재 Knight 수: {Knight.count}");
            ResetCount();
            Console.WriteLine($"현재 Knight 수: {Knight.count}");
        }

        public static void ResetCount() {
            Knight.count = 0;
            Console.WriteLine("Knight 수 초기화!");
        }
    }
    // [실행 결과]
    // 기사 ID: 0, 체력: 100
    // 기사 ID: 1, 체력: 100
    // 현재 Knight 수: 2
    // Knight 수 초기화!
    // 현재 Knight 수: 0
}
