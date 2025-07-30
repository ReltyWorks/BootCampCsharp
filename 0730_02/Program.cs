namespace _0730_02 { // 재귀 함수 구현
    internal class Program {
        static int SumBetween(int a, int b) {
            if (a > b) return 0;

            return a + SumBetween(a + 1, b);
        }
        static void Main(string[] args) {
            int a = 10;
            int b = 20;
            int result = SumBetween(1, 6);
            Console.WriteLine($"결과 : {result}");
        }
    }
}
/*
SumBetween(1, 6)
return = 1 + SumBetween(2, 6)
return = 1 + 2 + SumBetween(3, 6)
return = 1 + 2 + 3 + SumBetween(4, 6)
return = 1 + 2 + 3 + 4 + SumBetween(5, 6)
return = 1 + 2 + 3 + 4 + 5 + SumBetween(6, 6)
return = 1 + 2 + 3 + 4 + 5 + 6 + SumBetween(7, 6)
return = 1 + 2 + 3 + 4 + 5 + 6 + 0 (종료)
→ 결과: 21
/

/
return = 1 + SumBetween(2, 6)
return =     (       2      ) + SumBetween(3, 6)
return =                        (       3      ) + SumBetween(4, 6)
return =                                           (       4      ) + SumBetween(5, 6)
return =                                                              (       5      ) + SumBetween(6, 6)
return =                                                                                 (       6      ) + SumBetween(7, 6)
                                                                                                            (       0      )
*/