# 트리

![tree](https://user-images.githubusercontent.com/90877724/163961164-dfe6f8dc-f935-4fa7-8568-2daab6d9e048.png)

```c#
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
```
## 트리 구현
```c#
static void PrintTree(TreeNode<string> root)
        {
            // 접근
            Console.WriteLine(root.Data);
            // 재귀
            foreach (TreeNode<string> child in root.Children)
                PrintTree(child);
        }
```

<img width="227" alt="20220419_171501" src="https://user-images.githubusercontent.com/90877724/163959424-d9de1860-64c1-40d1-b3bd-db402c002a74.png">


## 트리의 높이 구현
```c#
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
```

<img width="186" alt="20220419_172207" src="https://user-images.githubusercontent.com/90877724/163959695-2b56a8db-e3aa-44a8-a89f-a78681e9acbb.png">



