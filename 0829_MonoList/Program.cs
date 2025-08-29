namespace _0829_MonoList {
    class Node {
        public int Data;
        public Node Next;
        public Node Prev;
    }

    class MonoList {
        public Node Head = null;
        public Node Tail = null;
        public int Count { get; private set; }

        public Node AddLast(int data) {
            Node newNode = new Node();
            newNode.Data = data;

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

        public void Remove(Node node) {
            if (node == Head) Head = Head.Next;
            if (node == Tail) Tail = Tail.Prev;
            if (node.Next != null) node.Next.Prev = node.Prev;
            if (node.Prev != null) node.Prev.Next = node.Next;
            Count--;
        }

        public Node Find(int data) {
            Node inspectNode = Head;
            while (inspectNode != null) {
                if (inspectNode.Data == data) break;
                else inspectNode = inspectNode.Next;
            }
            return inspectNode;
        }

        public Node LastFind(int data) {
            Node inspectNode = Tail;
            while (inspectNode != null) {
                if (inspectNode.Data == data) break;
                else inspectNode = inspectNode.Prev;
            }
            return inspectNode;
        }

        public void Reverse() {
            while (true) { // A, B, C, D, E, F, G
                if (Head == Tail) break;
                else if (Head.Next == Tail) {
                    Head.Prev = Tail;
                    Head.Next = null;
                    Tail.Next = Head;
                    Tail.Prev = null;
                    Head = Tail;
                    Tail.Prev = Head;
                    break;
                }
                else {
                    Tail.Prev = Tail;
                    Tail.Next.Next = Head;
                    Head.Prev = Tail.Next;
                    Head = Tail.Next;
                    for (int i = 0; i < Count - 1; i++) {
                        Tail = Tail.Prev;
                        Tail.Next.Prev = Head;
                        Tail.Next.Next = Head.Next;
                        Head.Next = Tail.Next;
                        Head.Next.Prev = Tail.Next;
                        Tail.Next = null;
                    }
                }
            }
        }
    }

    internal class Program {
        static void Main(string[] args) {

        }
    }
}