/*
연결리스트에 대하여
열결리스트는 노드를 리스트로 들고 있다.
연결리스트 노드는 연결리스트의 하나의 요소이다.

*/
using System.Collections.Generic;

namespace _0827_01 {
    class Node {
        public int Data;

        public Node Next;
        public Node Prev;
    }

    class MyLinkedList {
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
            //             <---[3]--->  
            // [1] <-> [2] <---------> [4] <-> [5]
            // Head                              Tail
            // 이하, 지우려는 노드를 Y라 칭함
            // Y의 Prev 노드를 X라 칭함
            // Y의 Next 노드를 Z라 칭함

            // Y가 첫노드라면
            if (Head == node) {
                // Z를 첫노드로
                Head = Head.Next;
            }
            // Y가 끝노드라면
            if (Tail == node) {
                // X를 끝노드로
                Tail = Tail.Prev;
            }
            // X가 있다면,
            if (node.Prev != null) {
                // X노트의 Next를 Z노트로
                (node.Prev).Next = node.Next;
            }
            // Z가 있다면,
            if (node.Next != null) {
                // Z노트의 Prev를 X노트로
                (node.Next).Prev = node.Prev;
            }
            count--;
        }
    }

    internal class Program {
        static void Main(string[] args) {
        }
    }
}
