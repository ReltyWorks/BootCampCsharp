namespace _0911_03 {
    internal class Program {
        static void CountingStar(string s) {
            int[] cs = new int[26];

            foreach(char c in s) {
                cs[c - 'a']++;
            }

            Console.WriteLine(string.Join(" ", cs));
        }
        
        static void Main(string[] args) {
            CountingStar("helloworld");
        }
    }
}
