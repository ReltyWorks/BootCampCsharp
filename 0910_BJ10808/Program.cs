namespace _0910_BJ10808 {
    internal class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            int[] answer = new int[26];

            foreach (char c in input) {
                if (c == 'a') answer[0] += 1;
                if (c == 'b') answer[1] += 1;
                if (c == 'c') answer[2] += 1;
                if (c == 'd') answer[3] += 1;
                if (c == 'e') answer[4] += 1;
                if (c == 'f') answer[5] += 1;
                if (c == 'g') answer[6] += 1;
                if (c == 'h') answer[7] += 1;
                if (c == 'i') answer[8] += 1;
                if (c == 'j') answer[9] += 1;
                if (c == 'k') answer[10] += 1;
                if (c == 'l') answer[11] += 1;
                if (c == 'm') answer[12] += 1;
                if (c == 'n') answer[13] += 1;
                if (c == 'o') answer[14] += 1;
                if (c == 'p') answer[15] += 1;
                if (c == 'q') answer[16] += 1;
                if (c == 'r') answer[17] += 1;
                if (c == 's') answer[18] += 1;
                if (c == 't') answer[19] += 1;
                if (c == 'u') answer[20] += 1;
                if (c == 'v') answer[21] += 1;
                if (c == 'w') answer[22] += 1;
                if (c == 'x') answer[23] += 1;
                if (c == 'y') answer[24] += 1;
                if (c == 'z') answer[25] += 1;
            }

            Console.WriteLine(string.Join(" ", answer));
        }

        //static void Main(string[] args) {
        //    string input = Console.ReadLine();
        //    int[] answer = new int[26];

        //    // 들어온 글자(c)가 몇 번째 알파벳인지 바로 계산해서
        //    // answer 배열의 해당 위치 값을 1 증가시킨다!
        //    foreach (char c in input) {
        //        answer[c - 'a']++;
        //    }

        //    Console.WriteLine(string.Join(" ", answer));
        //}
    }
}
