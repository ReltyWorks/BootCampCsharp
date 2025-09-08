namespace _0908_BST_My {
    class BstNode {
        public int Key;
        public BstNode Left;
        public BstNode Right;

        public BstNode(int _key) { this.Key = _key; }
    }

    class BinarySearchTree {
        BstNode root;

        // 삽입
        public void Insert(int _key) {
            root = InsertRec(root, _key);
        }

        BstNode InsertRec(BstNode _node, int _key) {
            if (_node == null) return new BstNode(_key);

            if (_key < _node.Key) _node.Left = InsertRec(_node.Left, _key);

            if (_key > _node.Key) _node.Right = InsertRec(_node.Right, _key);

            return _node;
        }

        // 탐색
        public bool Contains(int _key) {
            var now = root;
            while (now != null) {
                if (_key == now.Key) return true;

                now = (_key < now.Key) ? now.Left : now.Right;
            }

            return false;
        }

        // 삭제
        public void Remove(int _key) {
            root = RemoveRec(root, _key);
        }

        BstNode RemoveRec(BstNode _node, int _key) {
            if (_node == null) return null;

            if (_key < _node.Key) _node.Left = RemoveRec(_node.Left, _key);

            else if (_key > _node.Key) _node.Right = RemoveRec(_node.Right, _key);

            else {
                // 1. 리프
                if (_node.Left == null && _node.Right == null) return null;

                // 2. 자식 1개
                if (_node.Left == null) return _node.Right;
                if (_node.Right == null) return _node.Left;

                // 3. 자식 2개
                BstNode min = FindMin(_node.Right);
                _node.Key = min.Key;
                _node.Right = RemoveRec(_node.Right, min.Key);
            }

            return _node;
        }

        BstNode FindMin(BstNode _node) {
            while (_node.Left != null) _node = _node.Left;

            return _node;
        }

        // 출력
        public void PrintInorder() {
            Console.WriteLine("===== 중위 순회 결과 =====");
            InorderRec(root);
            Console.WriteLine("\n========================");
        }

        private void InorderRec(BstNode _node) {
            if (_node == null) return;

            // 1. 왼쪽 자식으로 끝까지 간다.
            InorderRec(_node.Left);

            // 2. 자기 자신을 출력한다.
            Console.Write(_node.Key + " ");

            // 3. 오른쪽 자식으로 간다.
            InorderRec(_node.Right);
        }


    }
    internal class Program {


        static void Main(string[] args) {
            var bst = new BinarySearchTree();
            int[] data = { 16, 14, 78, 31, 90, 5, 15, 1, 10, 87 };

            foreach (var x in data) {
                bst.Insert(x);
            }

            Console.WriteLine("삭제 전:");
            bst.PrintInorder(); // 삭제 전 상태 출력

            Console.WriteLine("\n루트 노드인 16을 삭제합니다...\n");
            bst.Remove(16);

            Console.WriteLine("삭제 후:");
            bst.PrintInorder(); // 삭제 후 상태 출력

            Console.WriteLine($"\n14가 트리에 있나요? {bst.Contains(14)}");
            Console.WriteLine($"16이 트리에 있나요? {bst.Contains(16)}");
        }
    }
}
