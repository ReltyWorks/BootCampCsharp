/*
선형 자료 구조 - 배열, 리스트, 연결리스, 스택, 큐
비선형 자료 구조 - 그래프, 트리, 딕셔너리, 헤시셋

스택
    원칙 LIFO(last in first out) = 후입선출
    삽입 (push) : 맨 뒤 (Top)에만 가능
    삭제 (pop) : 맨 뒤 (Top)에서만 가능
    즉, 마지막에 넣은 것만 꺼낼 수 있음
    ex) UI 팝업
큐
    원칙 FIFO(first in first out) = 선입선출
    삽입 (enqueue) : 맨 뒤(Rear)에만 가능
    삭제 (dequeue) : 맨 앞(Front)에서만 가능
    즉, 먼저 들어간 것 부터 꺼낼 수 있음
    ex) 네트워크 패킷 핸들링

스택, 큐 : 고정되어 있는 사용방식을 자료구조로 만들어 둠
*/
namespace _0829_01 {
    internal class Program {
        static void Main(string[] args) {
            int num = -1; // -1 확인

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack.Pop()); // 5, 뽑아옴
            Console.WriteLine(stack.Peek()); // 4, 반환
            Console.WriteLine(stack.TryPop(out num)); // True
            Console.WriteLine(num); // 4 TryPop이 실패했으면 0이됨

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue.Dequeue()); // 1, 뽑아옴
            Console.WriteLine(queue.Peek()); // 2, 반환
            Console.WriteLine(queue.Dequeue()); // 2, 뽑아옴
        }
    }
}
