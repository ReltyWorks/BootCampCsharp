namespace _0828_TrainList {

    class Node {
        public int Data;
        public Node Next;
        public Node Prev;
    }

    class TrainList {
        public Node Head = null;
        public Node Tail = null;
        public int count = 0;

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

            count++;
            return newNode;
        }

        public void Remove(Node node) {
            if (node == Head) Head = Head.Next;
            if (node == Tail) Tail = Tail.Prev;
            if (node.Next != null) node.Next.Prev = node.Prev;
            if (node.Prev != null) node.Prev.Next = node.Next;
            count--;
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
            Node inspectFirst = Head;
            Node inspectLast = Tail;
            Node tmpIF = null;
            Node tmpIL = null;

            while (true) { // A, B, C, D
                if (inspectFirst == inspectLast) break;
                if (inspectFirst.Next == inspectLast) {
                    tmpIF = inspectFirst;
                    tmpIL = inspectLast;

                    inspectFirst.Next = tmpIL.Next;
                    inspectFirst.Prev = tmpIL;
                    inspectLast.Prev = tmpIF.Prev;
                    inspectLast.Next = tmpIF;
                    break;
                }
                tmpIF = inspectFirst;
                tmpIL = inspectLast;


                inspectFirst.Next = tmpIL.Next;
                inspectFirst.Prev = tmpIL.Prev;
                inspectLast.Next = tmpIF.Next;
                inspectLast.Prev = tmpIF.Prev;

                inspectFirst = tmpIF.Next;
                inspectLast = tmpIL.Prev;
                // GG 왜?
            }
        }
    }

    internal class Program {
        static void Main(string[] args) {

        }
    }
}