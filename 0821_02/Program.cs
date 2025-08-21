/*
문제 1)
-10×10 맵을 2차원 배열로 정의하라.
- 1은 벽, 0은 빈칸으로 간주하고, 벽은 '■', 빈칸은 '·' 문자로 출력하라.
- 각 행은 줄바꿈으로 구분한다.

[출력결과]
■ ■ ■ ■ ■ ■ ■ ■ ■ ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ · · · · · · · · ■
■ ■ ■ ■ ■ ■ ■ ■ ■ ■


========================
문제 2) 전치(Transpose) 출력
========================
- 3×3 배열을 전치하여 출력하라.
- 전치란 a[r,c]를 aT[c,r]로 바꾸는 것이다.

int[,] a = new int[3, 3]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

[출력결과]
1 4 7
2 5 8
3 6 9
*/
namespace _0821_02 {


    internal class Program {

        static void Quiz1() {
            Console.WriteLine("Q1)");
            int[,] q1Arr = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
            };
            for (int i = 0; i < q1Arr.GetLength(0); i++) {
                for (int j = 0; j < q1Arr.GetLength(1); j++) {
                    if (q1Arr[i, j] == 1) Console.Write('■');
                    else Console.Write('·');                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Quiz2() {
            Console.WriteLine("Q2)");

            int[,] temp = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] q2Arr = new int[3, 3];

            for (int i = 0; i < q2Arr.GetLength(0); i++) {
                for(int j = 0; j < q2Arr.GetLength(1); j++) {
                    q2Arr[i, j] = temp[j, i];
                }
            }
            for (int i = 0; i < q2Arr.GetLength(0); i++) {
                for (int j = 0; j < q2Arr.GetLength(1); j++) {
                    Console.Write($"{q2Arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args) {
            Quiz1();
            Quiz2();
        }
    }
}
