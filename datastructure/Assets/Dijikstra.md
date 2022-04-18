# Dijikstra 다익스트라 알고리즘
## graph
```c#
int[,] adj3 = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 }
        };
```
## 다익스트라 알고리즘
```c#
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
```
