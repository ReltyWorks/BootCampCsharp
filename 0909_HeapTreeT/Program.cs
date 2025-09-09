﻿namespace _0909_HeapTreeT {
    class PriorityQueue<T> where T : IComparable<T> {
        List<T> _heap = new List<T>();

        // 삽입
        public void Push(T data) {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0) {
                int next = (now - 1) / 2;

                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }

        public T Pop() {
            T ret = _heap[0];

            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true) {
                int left = 2 * now + 1;

                int right = 2 * now + 2;

                int next = now;
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                if (next == now)
                    break;


                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;


            }

            return ret;
        }

        public int Count() {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight> {
        public int id { get; set; }

        public int CompareTo(Knight other) {
            if (id == other.id) return 0;

            return id < other.id ? 1 : -1;
        } // 아이디 뒤에 꺽쇠 함 바꿔보셈
    }

    class Program {
        static void Main() {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() { id = 20 });
            q.Push(new Knight() { id = 10 });
            q.Push(new Knight() { id = 30 });
            q.Push(new Knight() { id = 90 });
            q.Push(new Knight() { id = 40 });

            while (q.Count() > 0) {
                Console.WriteLine(q.Pop().id);
            }
        }
    }
}
