namespace _0729_06 {
    internal class Program {
        static void OpenSRankBox(out int gold, out int exp, out string item, ref int a, int b) {
            int temp = a;
            gold = 100;
            exp = 50;
            item = "포션";
        }
        static void Main(string[] args) {
            int myGold;
            int myExp;
            string myItem;
            int a = 100;
            int b = 0;
            OpenSRankBox(out myGold, out myExp, out myItem, ref a, b);

            Console.WriteLine($"골드 획득 : {myGold}");
            Console.WriteLine($"경험치 획득 : {myExp}");
            Console.WriteLine($"아이템 획득 : {myItem}");
        }
    }
}
