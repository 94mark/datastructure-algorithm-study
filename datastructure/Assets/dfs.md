# DFS
## Depth First Search, 깊이 우선 탐색
### Graph
```c#
int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 }
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>(){ 1, 3 },
            new List<int>(){ 0, 2, 3},
            new List<int>(){ 1 },
            new List<int>(){ 0, 1, 4 },
            new List<int>(){ 3, 5 },
            new List<int>(){ 4 }
        };
```
### dfs
```c#
bool[] visited = new bool[6];
        // 1) now부터 방문
        // 2) now와 연결된 정점들을 확인, 미방문 상태 시 방문
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // now 방문

            for(int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0) // 연결되어 있지 않으면 스킵
                    continue;
                if (visited[next]) // 이미 방문했으면 스킵
                    continue;
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // now 방문

            foreach(int next in adj2[now])
            {
                if (visited[next])
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
                if (visited[now] == false)
                    DFS(now);
        }
```
