/*
 문제
 인벤토리 라는 이름의 제네릭 클래스를 만들고, 아래 3개의 함수를 구현하세요.

  int Count() → 현재 인벤토리에 들어있는 아이템 개수를 반환
  void Add(T item) → 인벤토리에 아이템을 추가
  T Get(int index) → 인벤토리에서 해당 위치(index)의 아이템을 가져오기

  그리고 Main 함수에서 아래와 같이 사용해 보세요.
  Inventory<int>를 만들어 10, 20을 추가한 뒤, 개수와 인덱스 1의 값을 출력
  Inventory<string>을 만들어 "Sword", "Potion"을 추가한 뒤, 개수와 인덱스 0의 값을 출력

 출력결과
  Count:Int = 2
  Item: Int[1] = 20
  Count: String = 2
  Item: String[0] = Sword
*/
namespace _0822_02 {
    class Inventory<T> {
        List<T> invenList = new List<T>();

        public int Count() {
            return invenList.Count;
        }

        public void Add(T item) {
            invenList.Add(item);
        }

        public T Get(int index) {
            return invenList[index];
        }

    }
    internal class Program {
        static void Main(string[] args) {
            Inventory<int> intIV = new Inventory<int>();
            intIV.Add(10);
            intIV.Add(20);
            Inventory<string> stringIV = new Inventory<string>();
            stringIV.Add("Sword");
            stringIV.Add("Potion");

            Console.WriteLine($"Count:Int = {intIV.Count()}");
            Console.WriteLine($"Item: Int[1] = {intIV.Get(1)}");
            Console.WriteLine($"Count: String = {stringIV.Count()}");
            Console.WriteLine($"Item: String[0] = {stringIV.Get(0)}");
        }
    }
}