/*
얕은 복사 (Shallow Copy/쉘로우 카피)

깊은 복사 (Deep Copy/깊은 복사)
*/
namespace _0805_04 {
    public class Knight {
        public int hp;
        public int atk;
    }

    public struct Mage {
        public int mana;
    }

    internal class Program {
        static void Main(string[] args) {
            Knight k1 = new Knight();
            k1.hp = 100;

            Knight k2 = k1; // 얕은 복사
            // 스텍의 '주소값'만 복사하는것

            k2.hp = 50;
            Console.WriteLine(k1.hp); // 50 출력
            // 현재 k2는 k1의 주소를 가지고 있다.

            k1.atk = 20;
            Knight k3= new Knight();
            k3.atk = 30;
            k3.atk = k1.atk; // 깊은 복사
            // 힙의 '값'을 복사하는것
            Console.WriteLine(k3.atk);

            Mage mage1 = new Mage();
            mage1.mana = 200;
            Mage mage2 = mage1;
            Console.WriteLine(mage2.mana);
            // 스텍의 '값'을 복사하는 것도, 깊은 복사
        }
    }
}
