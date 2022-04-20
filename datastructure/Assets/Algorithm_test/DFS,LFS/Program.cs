using System;
using System.Collections.Generic;

namespace Exercise
{
    class Graph
    {
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

        int[,] adj3 = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 }
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while(true)
            {
                // 가장 가까이에 있는 점 찾기

                // 가장 유력한 후보의 거리와 번호 저장
                int closest = Int32.MaxValue;
                int now = -1;
                for(int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                        continue;
                    // 아직 발견(예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    // 후보 정보 갱신
                    closest = distance[i];
                    now = i;
                }
                // 다음 후보가 없다 -> 종료
                if (now == -1)
                    break;

                // 제일 좋은 후보 방문
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해서
                // 상황에 따라 발견한 최단거리 갱신
                for(int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 정점 스킵
                    if (adj3[now, next] == -1)
                        continue;
                    // 이미 방문한 정점 스킵
                    if (visited[next])
                        continue;

                    // 새로 조사된 정점의 최단거리 계산
                    int nextDist = distance[now] + adj3[now, next];
                    // 만약 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면 정보 갱신
                    if(nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }

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

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while(q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for(int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0) //인접하지 않으면 스킵
                        continue;
                    if (found[next]) // 이미 발견 시 스킵
                        continue;
                    q.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DFS(Depth First Search 깊이 우선 탐색)
            // BFS(Breadth First Search 너비 우선 탐색) - 최단거리 길찾기
            Graph graph = new Graph();
            graph.DFS2(0);
        }
    }
}
