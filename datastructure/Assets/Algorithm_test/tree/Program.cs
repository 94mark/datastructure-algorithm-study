using System;
using System.Collections.Generic;

namespace tree
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }
    class Program
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }

                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }

                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }
            }
            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            // 접근
            Console.WriteLine(root.Data);
            // 재귀
            foreach (TreeNode<string> child in root.Children)
                PrintTree(child);
        }

        //트리의 높이
        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach(TreeNode<string> child in root.Children)
            {
                int newheight = GetHeight(child) + 1;
                if (height < newheight)
                    height = newheight;
                // height = Mathf.Max(height, newHeight);
            }

            return height;
        }

        static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();

            //PrintTree(root);

            Console.WriteLine(GetHeight(root));
        }
    }
}
