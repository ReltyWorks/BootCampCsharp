using System.Text;
/*
캡슐화 (은닉성)
보안레벨 == 은닉성
접근지정자(접근제한자)
public - 가장 개방적인 형태
private - 가장 비개방적인(안전한) 형태
protected - 상속받은 애들만 가능

은닝성 개념의 캡슐화
기능 + 데이터를 묶는 개념의 캡슐화 > 중요하지 않음
목적 : 관련된 데이터와 그 데이터를 다루는 메서드를 한 클래스 안에 묶어서 하나의 "기능 단위"로 만들기
 */

namespace _0813_01 {
    class Player {
        public int hp = 100;
    }

    class Knight : Player {
        public void HitMe(int dmg) {
            hp -= dmg;               // (L1) ← 접근 가능
        }
    }

    class Program {
        static void Main() {
            Knight k = new Knight();
            k.HitMe(30);
            Console.WriteLine(k.hp); // (L2) ← 접근 불가
        }
    }
}
