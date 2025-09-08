/*
이진 검색 트리
왼쪽값은 다 나보다 작은 값
오른쪽 값은 다 나보다 큰 값
잘 정리되어있다는 기준으로 값을 빠르게 찾기 가능
잘못된 값을 넣을 경우 트리의 균형이 깨질 수 있다.
균형이 깨진 이진 검색 트리는 탐색 속도가 느려진다.

BST 시간 복잡도
평균 : O(log n) 트리가 균형잡혀 있을 때
최악 : O(n) 트리가 한쪾으로 치우쳐서 사실상 연결 리스트가 되었을 때

균형이 깨지는걸 대비하기 위해 스스로 복구하는 균형 트리라는게 있다.
추가적으로 삽입시 스스로 균형을 유지하게끔 만들어진 트리
자가 균형 트리 => AVL, RedBlackTree, B Tree
*/
using _0908_BST;

namespace _0908_BST {

    // 이 아래는 강사님꺼

    class BstNode<T> {
        public int Key;
        public T Value;
        public BstNode<T> Left;
        public BstNode<T> Right;

        public BstNode(int key, T value) {
            Key = key;
            Value = value;
        }
    }

    class BinarySearchTree<T> {
        private BstNode<T> root;

        // 삽입
        public void Insert(int _key, T _value) {
            root = InsertRec(root, _key, _value);
        }

        private BstNode<T> InsertRec(BstNode<T> _node, int _key, T _value) {
            if (_node == null)
                return new BstNode<T>(_key, _value);

            if (_key < _node.Key)
                _node.Left = InsertRec(_node.Left, _key, _value);

            if (_key > _node.Key)
                _node.Right = InsertRec(_node.Right, _key, _value);

            return _node;
        }

        // 탐색 
        public bool Contains(int _key) {
            var now = root;
            while (now != null) {
                if (_key == now.Key)
                    return true;

                now = (_key < now.Key) ? now.Left : now.Right;
            }

            return false;
        }

        // 어떠한 값이 들어있는지 반환하는
        public BstNode<T> Find(int _key) {
            var now = root;
            while (now != null) {
                if (_key == now.Key)
                    return now;

                now = (_key < now.Key) ? now.Left : now.Right;
            }

            return null;
        }

        // 삭제
        public void Remove(int _key) {
            root = RemoveRec(root, _key);
        }

        private BstNode<T> RemoveRec(BstNode<T> _node, int _key) {
            if (_node == null)
                return null;

            if (_key < _node.Key) {
                _node.Left = RemoveRec(_node.Left, _key);
            }
            else if (_key > _node.Key) {
                _node.Right = RemoveRec(_node.Right, _key);
            }
            else {
                // case 1 : 리프
                if (_node.Left == null && _node.Right == null)
                    return null;

                // case 2 : 자식 1개
                if (_node.Left == null)
                    return _node.Right;
                if (_node.Right == null)
                    return _node.Left;

                // case 3 : 자식 2개
                BstNode<T> min = FindMin(_node.Right);
                _node.Key = min.Key;
                _node.Right = RemoveRec(_node.Right, min.Key);
            }

            return _node;
        }

        private BstNode<T> FindMin(BstNode<T> _node) {
            while (_node.Left != null)
                _node = _node.Left;

            return _node;
        }

        // 0 1 2 3 4 5 6 7 8 9  -> ChangeBinary(List<int> ret, int lo, int hi) -> 4 1 0 2 3 7 5 6 8 9
        public List<int> ChangeBinary(List<int> _result) {
            _result.Sort();

            List<int> answer = new List<int>();

            ChangeBinary(_result, ref answer, 0, _result.Count - 1);

            answer.Reverse();
            return answer;
        }

        void ChangeBinary(List<int> _source, ref List<int> _result, int _lo, int _hi) {
            if (_lo > _hi) return;

            int midIndex = (_lo + _hi) / 2;

            ChangeBinary(_source, ref _result, midIndex + 1, _hi);
            ChangeBinary(_source, ref _result, _lo, midIndex - 1);

            _result.Add(_source[midIndex]);
        }
    }

    class Program {
        static void Main(string[] args) {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            List<int> aaa = new List<int>();
            aaa.Add(1);
            aaa.Add(2);
            aaa.Add(6);
            aaa.Add(7);
            aaa.Add(8);
            aaa.Add(9);
            aaa.Add(0);
            aaa.Add(3);
            aaa.Add(4);
            aaa.Add(5);

            List<int> bbb = bst.ChangeBinary(aaa);

            Console.WriteLine(string.Join(" ", bbb));
        }
    }
}