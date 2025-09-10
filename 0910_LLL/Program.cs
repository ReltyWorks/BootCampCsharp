namespace _0910_LLL {
    class MyList<T> {
        T[] Arr = new T[1];
        public int Count { get; private set; }
        public int Length { get { return Arr.Length; } }

        public void Add(T _elem) {
            EnsureCapacity(1);
            Arr[Count] = _elem;
            Count++;
        }

        public void RemoveAt(int _index) {
            if (0 <= _index && _index < Count) {
                for (int i = _index; i < Count - 1; i++) {
                    Arr[i] = Arr[i + 1];
                }
                Count--;
            }
        }

        void EnsureCapacity(int _needSize) {
            if (Length - Count < _needSize) {
                T[] newArr = new T[Length * 2];
                for (int i = 0; i < Count; i++) newArr[i] = Arr[i];
                Arr = newArr;
            }
        }
    }

    class Node {
        public int Data;
        public Node Next;
        public Node Prev;
    }

    class MyLinkedList {
        public Node Head = null;
        public Node Tail = null;
        public int Count = 0;

        public Node AddLast(int _data) {
            Node newNode = new Node();
            newNode.Data = _data;

            if (Head == null) {
                Head = newNode;
                Tail = newNode;
            }
            else {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }

            Count++;
            return newNode;
        }

        public void Remove(Node _node) {
            if (_node == Head) Head = Head.Next;
            if (_node == Tail) Tail = Tail.Prev;
            if (_node.Next != null) _node.Next.Prev = _node.Prev;
            if (_node.Prev != null) _node.Prev.Next = _node.Next;
            Count--;
        }

    }

        internal class Program {
            static void Main(string[] args) {

            
        }
    }
}
