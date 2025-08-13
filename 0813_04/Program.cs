// => 화살표 함수 (람다식)
// 함수를 짧게 표현
// ()=> 람다 메서드
// 

namespace _0813_04 {
    internal class Program {

        static public int hp = 100;
        static public int GetA() {
            return hp;
        } // 이게 일반적인 함수

        static public int GetB() => hp;
        // 이게 람다식

        static void Main(string[] args) {
            // startButton.onClick.AddListener(() => Debug.Log("게임 시작!"));
            // 람다 메서드
            Console.WriteLine(GetA());
            Console.WriteLine(GetB());
        }
    }
}
