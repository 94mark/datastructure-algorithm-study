# BinaryTree 미로 생성 알고리즘

<img width="301" alt="20220413_140620" src="https://user-images.githubusercontent.com/90877724/163111613-efde73ac-b8cc-40e8-b746-1e9dffa4fa21.png">

## binarytree 생성 함수 로직
```c#
void GenerateBinaryTree()
        {
            // 일단 길을 다 막는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    // 마지막 출구 막기
                    if (y == _size - 2 && x == _size - 2)
                        continue;

                    // y축 끝에 다다를 경우 무조건 x방향으로 이동 
                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    // x축 끝에 다다를 경우 무조건 y방향으로 이동
                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0) //0 또는 1, 1/2 확률
                    {
                        _tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        _tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }
```
## 렌더링 함수 구현
```c#
public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);

                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty : 
                    return ConsoleColor.Green;
                case TileType.Wall :
                    return ConsoleColor.Red;
                default :
                    return ConsoleColor.Green;
            }
        }
    }
```
