/*
생성자(Constructor)
new [변수명]()



*/
namespace _0806_01 {

    class Knight {
        public int hp;
        public int atk;

        // 기본생성자(클래스만 만들어두면 (안보이지만)자동으로 생김)
        // public Knight() { // 클래스랑 같은이름
        // 
        // Knight 타입의 객체를 힙에 생성
        // 힙 메모리에 아래처럼
        // [0000 0000 0000 0000 0000 0000 0000 0000][0000 0000 0000 0000 0000 0000 0000 0000]
        // 공간생성
        // hp = default;
        // atk = default;
        // return Knight 타입의 객체

        public Knight() {
            Console.WriteLine("응애 나 기본생성자");
        } // 이 경우 기본생성자를 수정한것, new Knight() 하면 콘솔 출력됨

        public Knight(int hp, int atk) : this(10) { // 생성자도 오버로딩 가능
            this.hp = hp; // this는 클래스 주인을 이야기함
            this.atk = atk; // 즉, Knight 클래스의 hp, atk
        }

        public Knight(int hp) : this() { // 생성자도 오버로딩 가능
            Console.WriteLine("응애 나 커스텀 생성자");
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Knight knight = new Knight(200, 10);
            // knight.hp = 200; knight.atk = 10;
            Console.WriteLine($"기사: HP {knight.hp}, ATK {knight.atk}");
            /*
             출력값 :
             응애 나 기본생성자
             응애 나 커스텀 생성자
             강한 기사: HP 100, ATK 10
            */
        }
    }
}
