using System.Text;
/*
다형성(Polymorphism) - 여러가지 형태를 가지는 성질
OOP 의 다형성 - 같은 이름의 메서드나 인터페이스를 통해
여러 다른 형태를 구현하는것
[스택]                       [힙] > [메서드힙(메서드영역)]
player ────────────────▶    ┌─────────────────┐
 (Player 타입 참조변수)       │Knight 객체(실체) │
Player k = new Knight의 경우 │-----------------│
 k는 Player.Move()에만       │  Player.Move()  │  ← A에서 상속받은 메서드
 접근 할 수 있다.             │  Knight.Move()  │  ← B에서 새로 정의한 메서드
 Knight.Move()에 접근하기     └─────────────────┘
 위해선 Move()를 버츄얼로 지정해줘야한다.
 이때, 오버라이드한 Knight.Move()는 Player.Move()를 바꾸는게 아닌
 Knight.Move()에 접근할 수 있게 되는 것 뿐.
*/
namespace _0813_02 {
    class Player {
        public virtual void Move() {
            Console.WriteLine("Player.Move");
        }
    }

    class Knight : Player {
        public override void Move() {
            Console.WriteLine("Knight.Move");
        }
    }

    class Mage : Player {
        public override void Move() {
            Console.WriteLine("Mage.Move");
        }
    }

    class Program {
        static void Main() {
            Player p1 = new Knight();
            Player p2 = new Mage();
            p1.Move(); // "Knight.Move"
            p2.Move(); // "Mage.Move"
        }
    }
}