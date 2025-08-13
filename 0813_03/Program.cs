// 문자열 문제!
// 메인함수 호출부를 보고 CheckId 함수를 만들어주세요!
// 입력으로 새 아이디(newId)와 기존 아이디(oldId)가 주어진다.
// 두 아이디를 대소문자 구분 없이 비교해서 같으면 "중복" 출력, 다르면 "사용 가능" 출력

// 조건
// 공백은 무조건 문자열 안에 0개 또는 1개만 들어온다고 가정
// 사용할 수 있는 문자열 함수: Contains, IndexOf, ToLower, ToUpper, Replace

// 메인함수 호출
// Console.WriteLine(CheckId("Hong GilDong", "hong gildong"));
// Console.WriteLine(CheckId("Kim", "lee"));

// 출력예시
// 중복
// 사용 가능
namespace _0813_03 {

    internal class Program {
        public static string CheckId(string newId, string oldId) {
            string[] checkNewId = newId.ToUpper().Split();
            string[] checkOldId = oldId.ToUpper().Split();
            bool check = true;
            for (int i = 0; i < checkNewId.Length; i++) {
                if (checkNewId[i] == checkOldId[i]) check = true;
                else {
                    check = false;
                    break;
                }
            }
            if (check) return "중복";
            else return "사용가능";
        }
        static void Main(string[] args) {
            Console.WriteLine(CheckId("Hong GilDong", "hong gildong"));
            Console.WriteLine(CheckId("Kim", "lee"));
        }
    }
}