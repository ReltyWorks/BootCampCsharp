/*
// 문제1
// 추상 클래스 Monster 만들기
// - 이동 기능을 하는 일반 메서드 하나 작성
//  > 콘솔에 "몬스터가 한 칸 이동합니다." 출력
// - 공격 기능을 하는 추상 메서드 하나 작성
//  > 자식 클래스에서 반드시 구현하도록 할 것

// 자식 클래스 구현
// Orc 클래스 (Monster 상속)
// 공격 시 "오크가 몽둥이로 공격!" 출력
// Skeleton 클래스 (Monster 상속)
// 공격 시 "스켈레톤이 화살을 발사!" 출력

// Main에서
// Orc, Skeleton 객체를 각각 생성
// 각 객체의 이동 메서드 호출 후, 공격 메서드 호출

// [출력예시]
// 몬스터가 한 칸 이동합니다.
// 오크가 몽둥이로 공격!
// 몬스터가 한 칸 이동합니다.
// 스켈레톤이 화살을 발사!
*/
namespace _0822_03 {
    abstract class Monster {
        public void Move() {
            Console.WriteLine("몬스터가 한 칸 이동합니다.");
        }

        public abstract void Attack();
    }

    class Orc : Monster {
        public override void Attack() {
            Console.WriteLine("오크가 몽둥이로 공격!");
        }
    }

    class Skeleton : Monster {
        public override void Attack() {
            Console.WriteLine("스켈레톤이 화살을 발사!");
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Orc orc = new Orc();
            Skeleton skeleton = new Skeleton();
            orc.Move();
            orc.Attack();
            skeleton.Move();
            skeleton.Attack();
        }
    }
}
