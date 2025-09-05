/*
트리 - 계층적인 구조를 갖는 데이터를 표현하기 위한 자료 구조
트리는 무조건 당방향으로 뻗음
부모에 해당하는 아이는 딱 하나만 있어야 함
트리는 재귀 적인 속성을 갖고 있다.
트리의 연산의 재귀함수가 애용됨

*/

using System.Xml.Linq;

namespace _0905_Tree {
    class TreeNode<T> {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    class Program {

        

        static TreeNode<String> MakeTree() {
            TreeNode<String> root = new TreeNode<string>() { Data = "A" };
            {
                TreeNode<String> nodeB = new TreeNode<string>() { Data = "B" };
                {
                    TreeNode<String> nodeD = new TreeNode<string>() { Data = "D" };
                    {
                        nodeD.Children.Add(new TreeNode<string>() { Data = "H" });
                        nodeD.Children.Add(new TreeNode<string>() { Data = "I" });
                    }
                    TreeNode<String> nodeE = new TreeNode<string>() { Data = "E" };

                    nodeB.Children.Add(nodeD);
                    nodeB.Children.Add(nodeE);
                }
                TreeNode<String> nodeC = new TreeNode<string>() { Data = "C" };
                {
                    nodeC.Children.Add(new TreeNode<string>() { Data = "F" });
                    nodeC.Children.Add(new TreeNode<string>() { Data = "G" });
                }

                root.Children.Add(nodeB);
                root.Children.Add(nodeC);
            }

            return root;
        }

        // 트리 순회 - 문제
        static void Print(TreeNode<String> _node) {
            Console.WriteLine(_node.Data);
            foreach (TreeNode<String> child in _node.Children) Print(child);
        }

        // 트리 높이
        //static int GetHeight(TreeNode<String> _node) {
        //    int height = 0;
        //    int childHeight = 0;
        //    if (_node.Children.Count == 0) return 0;

        //    foreach (TreeNode<String> child in _node.Children) {
        //        childHeight = GetHeight(child);
        //        if (childHeight > height) height = childHeight;
        //    }

        //    return 1 + height;
        //} 아래로 수정
        static int GetHeight(TreeNode<String> _node) {
            int height = 0;
            if (_node.Children.Count == 0) return 0;

            foreach (TreeNode<String> child in _node.Children) {
                if (GetHeight(child) > height) height = GetHeight(child);
            }

            return 1 + height;
        }
        static void Main() {
            TreeNode<String> root = MakeTree();
            Console.WriteLine(GetHeight(root));            
        }
    }
}