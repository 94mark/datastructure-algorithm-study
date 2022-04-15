# SideWinder 미로 생성 알고리즘
<img width="306" alt="20220413_150649" src="https://user-images.githubusercontent.com/90877724/163111057-e742f455-bf21-49c7-a6aa-0a28aff039cc.png">

## sidewinder 생성 함수 로직
```c#
void GenerateSideWinder()
        {
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

            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                int count = 1;
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                        continue;
                    
                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0) //0 또는 1, 1/2 확률
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        _tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }
```
