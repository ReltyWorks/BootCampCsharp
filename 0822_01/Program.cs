/*
Generic_일반화


object 타입은 C#에서 모든 타입의 조상 클래스이다.
var 타입은 내부적으론 받아들이는 값의 형식을 확인해서 값의 형식으로 일치시켜준다.

Generic(일반화) - 타입을 나중에 결정하는 설계도
장점
1. 타입별로 중복되는 코드를 만들 필요 없음
2. Object처럼 박싱/언박싱이 필요 없으니 성능 향상
3. 잘못된 타입을 넣으려 하면 컴파일 시점에서 에러를 잡아줌


T - 관례상 Type 약자 템플릿의 약자, 런타임에 우리가 지정해준 형식으로 치환됨
*/
namespace _0822_01 {
    // T는 반드시 값 형식의 데이터 타입만 가능하게 where T : struct
    // T는 반드시 참조 형식의 데이터 타입만 가능하게 where T : class
    // 클래스 안에 객체를 생성하는 코드가 있을 때 넣어줌 where T : new
    public class MyList<T> where T : class {
        public T[] arr = new T[10];
        
        public T GetItem(int index) {
            return arr[index];
        }
    }

    internal class Program {
        static void Test<T>(T value) {
            Console.WriteLine(value);
        }

        static void Main(string[] args) {
            MyList<string> myList = new MyList<string>();
            myList.arr[3] = "바보";
            Console.WriteLine(myList.GetItem(3));

            Test<int>(7);
            Test<string>("테스트");
            Test<float>(3.14f);
        }
    }
}
