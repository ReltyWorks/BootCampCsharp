namespace _0910_BJ2979 {
    internal class Program {
        static void Main(string[] args) {
            int[] rule = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            byte[] carPark = new byte[101];
            int maxnum = 0;

            for (int i = 0; i < 3; i++) {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                if (maxnum < input[0])
                    maxnum = input[0];
                if (maxnum < input[1])
                    maxnum = input[1];

                for (int j = input[0]; j < input[1]; j++) {
                    carPark[j]++;
                }
            }
            
            int answer = 0;

            for (int i = 0; i < maxnum + 1; i++) {
                if (carPark[i] == 1) {
                    answer += rule[0];
                }
                else if (carPark[i] == 2) {
                    answer += rule[1] * 2;
                }
                else if (carPark[i] == 3) {
                    answer += rule[2] * 3;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
