/*
//========================
//문제 1) 합계와 평균 구하기
//========================
//- 정수 배열 a = { 5, 8, 12, -3, 7 }가 있다.
//- 배열의 합계와 평균(소수 첫째 자리까지)을 출력하라.

//[출력결과]
//Sum = 29
//Avg = 5.8

//========================
//문제 2) 최대값과 최소값 찾기
//========================
//- 정수 배열 a = { 15, 3, 9, 27, -5, 8 }이 있다.
//- 배열에서 가장 큰 값과 가장 작은 값을 찾아라.

//[출력결과]
//Max = 27
//Min = -5


//=====================================
//문제 3) 빈도수 세기(작은 히스토그램)
//=====================================
//- 0, 1, 2만 들어있는 정수 배열 nums = { 1,0,2,2,1,0,0,2,1,1 }의
//  각 숫자(0,1,2)가 몇 번 나오는지 출력하라.

//[출력결과]
//0:3 1:4 2:3


//=====================================
//문제 4) 배열 뒤집기(제자리 반전)
//=====================================
//- 정수 배열 a = { 1, 2, 3, 4, 5, 6 }을
//  추가 배열 없이 제자리에서 뒤집어 출력하라.

//[출력결과]
//6 5 4 3 2 1


//========================
//문제 5) 배열 오름차순 정렬
//========================
//- 정수 배열 a = { 42, 17, 8, 99, 23 }가 있다.
//- 배열을 오름차순으로 정렬하여 출력하라.
//- 단, Array.Sort()는 사용하지 말고 직접 알고리즘을 구현

//[출력결과]
//8 17 23 42 99
*/

namespace _0821_01 {
    internal class Program {
        static string Quiz1() { // 창작
            int[] q1Arr = { 5, 8, 12, -3, 7 };
            int q1Sum = 0;
            for (int i = 0; i < q1Arr.Length; i++) {
                q1Sum += q1Arr[i];
            }
            return $"Q1)\nSum = {q1Sum}\nAvg = {(float)((float)q1Sum / q1Arr.Length)}\n";
        }
        static string Quiz2() { // 창작
            int[] q2Arr = { 15, 3, 9, 27, -5, 8 };
            int q2min = 0;
            int q2max = 0;
            for (int i = 0; i < q2Arr.Length; i++) {
                if (q2min > q2Arr[i]) q2min = q2Arr[i];
                if (q2max < q2Arr[i]) q2max = q2Arr[i];
            }
            return $"Q2)\nMax = {q2max}\nMin = {q2min}\n";
        }

        static string Quiz3_a() { // 처음 푼거
            int[] q3Arr = { 1, 0, 2, 2, 1, 0, 0, 2, 1, 1 };
            int q3c0 = 0;
            int q3c1 = 0;
            for (int i = 0; i < q3Arr.Length; i++) {
                if (q3Arr[i] == 0) q3c0++;
                if (q3Arr[i] == 1) q3c1++;
            }
            return $"Q3)\n0 : {q3c0}\n1 : {q3c1}\n2 : {q3Arr.Length - q3c0 - q3c1}\n";
        }
        static string Quiz3_b() { // 강사님꺼
            int[] q3Arr = { 1, 0, 2, 2, 1, 0, 0, 2, 1, 1 };
            int[] count = new int[3];

            for (int i = 0; i < q3Arr.Length; i++) {
                count[q3Arr[i]]++;
            }

            return $"Q3)\n0 : {count[0]}\n1 : {count[1]}\n2 : {count[2]}\n";
        }

        static string Quiz4_a() { // 처음 푼거
            int[] temp = { 1, 2, 3, 4, 5, 6 };
            int[] q4Arr = new int[temp.Length];
            int num = -int.MaxValue;
            int breakNum = -1;
            for (int i = 0; i < q4Arr.Length; i++) {
                for (int j = 0; j < temp.Length; j++) {
                    if (num < temp[j]) {
                        num = temp[j];
                        breakNum = j;
                    }
                }
                temp[breakNum] = -int.MaxValue;
                q4Arr[i] = num;
                num = -int.MaxValue;
            }
            return $"Q4)\n{string.Join(" ", q4Arr)}\n";
            Console.WriteLine();
        }
        static string Quiz4_b() { // 5번 영감으로 다시품
            int[] q4Arr = { 1, 2, 3, 4, 5, 6 };
            if (q4Arr.Length % 2 == 0) {
                for (int i = 0; i < q4Arr.Length / 2; i++) {
                    int temp = q4Arr[i];
                    q4Arr[i] = q4Arr[q4Arr.Length - 1 - i];
                    q4Arr[q4Arr.Length - 1 - i] = temp;
                }
            }
            else {
                for (int i = 0; i < (q4Arr.Length / 2) - 1; i++) {
                    int temp = q4Arr[i];
                    q4Arr[i] = q4Arr[q4Arr.Length - 1 - i];
                    q4Arr[q4Arr.Length - 1 - i] = temp;
                }
            }
            return $"Q4)\n{string.Join(" ", q4Arr)}\n";
        }
        static string Quiz4_c() { // 강사님꺼
            int[] q4Arr = { 6, 5, 4, 3, 2, 1 };

            int left = 0;
            int right = q4Arr.Length - 1;

            while (left < right) {
                int tmp = q4Arr[left];
                q4Arr[left] = q4Arr[right];
                q4Arr[right] = tmp;

                left++;
                right--;
            }

            return $"Q4)\n{string.Join(" ", q4Arr)}\n";
        }

        static string Quiz5_a() { // 처음 푼거
            int[] temp = { 42, 17, 8, 99, 23 };
            int[] q5Arr = new int[temp.Length];
            int num = int.MaxValue;
            int breakNum = -1;
            for (int i = 0; i < q5Arr.Length; i++) {
                for (int j = 0; j < temp.Length; j++) {
                    if (num > temp[j]) {
                        num = temp[j];
                        breakNum = j;
                    }
                }
                temp[breakNum] = int.MaxValue;
                q5Arr[i] = num;
                num = int.MaxValue;
            }
            return $"Q5)\n{string.Join(" ", q5Arr)}";
        }
        static string Quiz5_b() { // 다른 학생꺼
            int[] q5Arr = { 42, 17, 8, 99, 23 };
            for (int i = 0; i < q5Arr.Length; i++) {
                for (int j = i + 1; j < q5Arr.Length; j++) {
                    if (q5Arr[j] < q5Arr[i]) {
                        int temp = q5Arr[i];
                        q5Arr[i] = q5Arr[j];
                        q5Arr[j] = temp;
                    }
                }
            }
            return $"Q5)\n{string.Join(" ", q5Arr)}";
        }
        static string Quiz5_c() { // 강사님꺼
            int[] q5Arr = { 42, 17, 8, 99, 23 };
            for (int i = 0; i < q5Arr.Length; i++) {
                int minIndex = i;

                for (int j = i + 1; j < q5Arr.Length; j++) {
                    if (q5Arr[j] < q5Arr[minIndex])
                        minIndex = j;
                }

                int temp = q5Arr[i];
                q5Arr[i] = q5Arr[minIndex];
                q5Arr[minIndex] = temp;
            }
            return $"Q5)\n{string.Join(" ", q5Arr)}";
        }

        static void Main(string[] args) {
            Console.WriteLine(Quiz1());
            Console.WriteLine(Quiz2());
            Console.WriteLine(Quiz3_b());
            Console.WriteLine(Quiz4_c());
            Console.WriteLine(Quiz5_c());
        }
    }
}