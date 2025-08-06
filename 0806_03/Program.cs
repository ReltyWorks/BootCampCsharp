/*
필드(멤버 변수)
    > 클래스 아래 선언된 변수
    > 객체가 생성되었을 때부터 소멸까지 유지
    > 클래스 내부 전체에서 접근 가능
    > 자동 초기화됨(int = 0, bool = false)
지역 변수
    > 특정 메서드, 코드 블록 내에서 선언된 변수
    > 매개변수 또한 지역 변수
    > 메서드가 실행되었을 때부터 종료까지 유지
    > 해당 블록 내부에서만 사용됨
    > 반드시 직접 초기화해야 함(안하면 에러)

멤버 함수
    > 클래스에 속해있는 함수
    > 객체명.함수명()으로 호출
    > 클래스 전체의 필드에 접근 가능
    > 사용 목적 - 객체의 기능을 정의하고 외부에 제공
지역 함수
    > 함수 내부에서 선언된 함수
    > 함수 밖에서는 호출 불가
    > 접근 지정자 붙일 수 없음
    > 지역 함수가 선언된 함수내의 변수까지 사용 가능함
    > 사용 목적 - 특정 함수 내의 복잡한 로직을 분리하여 가독성을 높임
*/
namespace _0806_03 {
    public class Knight {
        public string? name = default;
        public int atk = default;

        public void Attack(Monster target) {
            int damage = this.atk;
            DamageLog(damage);
            target.hp -= damage;

            void DamageLog(int damage) {
                Console.WriteLine($"{this.name}가 {target.name}에게 {damage}의 피해를 입힘");
            }
        }
    }

    public class Monster {
        public string? name = default;
        public int hp = default;
    }

    internal class Program {
        static void Main(string[] args) {
            Knight knight = new Knight();
            knight.name = "아서";
            knight.atk = 30;
            Monster monster = new Monster();
            monster.name = "고블린";
            monster.hp = 100;

            knight.Attack(monster);
            Console.WriteLine($"{monster.name}의 남은 체력 : {monster.hp}");
        }
    }
}
