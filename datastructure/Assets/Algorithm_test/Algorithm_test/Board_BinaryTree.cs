using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class Board_BinaryTree
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile; // 배열
        public int Size;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size)
        {
            if (size % 2 == 0)
                return;

            Tile = new TileType[size, size];
            Size = size;

            GenerateBinaryTree();
        }

        void GenerateBinaryTree()
        {
            // 일단 길을 다 막는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    // 마지막 출구 막기
                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    // y축 끝에 다다를 경우 무조건 x방향으로 이동 
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    // x축 끝에 다다를 경우 무조건 y방향으로 이동
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0) //0 또는 1, 1/2 확률
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }            

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Console.ForegroundColor = GetTileColor(Tile[y, x]);

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
}
