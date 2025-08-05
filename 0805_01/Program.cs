namespace _0805_01 {
    public class Player {
        public int hp = 100;
        public int atk = 50;
    }
    internal class Program {
        static void Main(string[] args) {

            Player playerA = new Player();
            Player playerB = new Player();

            playerA.hp = 110;
            playerA.atk = 60;
            
            playerB = playerA;

            playerB.hp = 200;
            playerB.atk = 40;

            Console.WriteLine($"{playerA.hp} {playerA.atk}");
            // 200, 40이 출력된다.
            // 클래스는 참조전달(주소복사)을 하기 때문에,
            // playerB = playerA;를 한 순간
            // playerA.hp와 playerB.hp는 같은걸 가리키게 된다.

            //  [Stack]             [Heap]
            //------------------------------
            //playerA(주소)-------->객체 주소
            //                     hp : 110
            //                     atk : 60
            //              ~
            //playerB(주소)-------->객체 주소
            //                     hp : 100
            //                     atk : 50

            // ※ playerB = playerA; 실행됨

            //  [Stack]             [Heap]
            //------------------------------
            //playerA(주소)-------->객체 주소
            //playerB(주소)--┘      hp : 110
            //                     atk : 60
            //              ~
            //    (얘들은 유기됨)    객체 주소
            //                     hp : 100
            //                     atk : 50

            // ※ 유기된 친구들은 GC가 치운다.
        }
    }
}