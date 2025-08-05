namespace _0805_02 {

    class Knight { // 나이트는 클래스
        public int hp;
        public int atk;
    }

    struct Mage { // 메이지는 구조체
        public int hp;
        public int atk;
    }

    class Program {
        // 매개변수는 Mage 형식의 변수를 요구함
        static void KillMage(Mage mage) {
            mage.hp = 0;
        }

        // 매개변수는 Knight 형식의 변수를 요구함
        static void KillKnight(Knight knight) {
            knight.hp = 0;
        }

        static void Main(string[] args) // 함수
        {
            Mage mage = new Mage(); // 구조체
            mage.hp = 100;
            mage.atk = 50;
            KillMage(mage); // Mage 형식 변수를 전달함
            // Mage는 구조체기에 값 복사만 일어남
            // 값만 전달되었기에 원본(?)mage.hp는 변화하지 않음

            Knight knight = new Knight(); // 클래스
            knight.hp = 100;
            knight.atk = 50;
            KillKnight(knight); // Knight 형식 변수를 전달함
            // Knight는 클래스 이기에 주소 복사가 일어남
            // 주소가 전달되었기에 원본 knight.hp가 직접 변경됨

            Console.WriteLine($"Mage HP {mage.hp}\nKnight HP {knight.hp}"); //100 //0
        } // KillMage(Mage mage) 부분을 KillMage(ref Mage mage)로 바꾸고
    } // KillMage(mage) 부분을 KillMage(ref mage)로 바꾸면 메이지도 뒤짐
}