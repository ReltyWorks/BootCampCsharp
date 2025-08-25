/*
Action
편하게 쓰라고, 반환형이 존재하지 않는 타입의 델리게이트를 미리 만들어둠
Action action; = delegate void action();
Action<int, int> action; = delegate void action(int a, int b);
action.Invoke(); = 액션에 속해있는 모든 함수호출

예외처리(익셉션?)
try, catch, finaliy?

람다식 = 일회용 함수를 만드는 방법
*/
namespace _0825_02 {
    internal class Program {
        

        static void sumF(int a, int b) {
            Console.WriteLine(a + b);
        }

        static void Main(string[] args) {
            Action<int, int> myAction;

            myAction = sumF;
            myAction.Invoke(1, 2);
        }
    }
}
