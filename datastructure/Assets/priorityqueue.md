# 우선순위 큐 Priority Queue
## priority queue 
```c#
class PriorityQueue
    {
        List<int> _heap = new List<int>();

        public void Push(int data)
        {
            // 힙의 맨 끝에 새로운 데이터 삽입
            _heap.Add(data);

            int now = _heap.Count - 1;
            // 도장깨기 시작
            while(now > 0)
            {
                // 도장깨기 시도
                int next = (now - 1) / 2; //부모 인덱스
                if (_heap[now] < _heap[next])
                    break; // 실패

                // 성공 시 두 값 교체
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치 이동
                now = next;
            }
        }

        public int Pop()
        {
            // 반환할 데이터 저장
            int ret = _heap[0]; //최상위

            // 마지막 데이터를 루트로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역으로 내려가는 도장깨기 시작
            int now = 0;
            while(true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽값이 현재값보다 크면 왼쪽으로 이동
                if (left <= lastIndex && _heap[next] < _heap[left])
                    next = left;
                // 오른쪽값이 현재값(왼쪽 이동 포함 이후 값)보다 크면 오른쪽으로 이동
                if (right <= lastIndex && _heap[next] < _heap[right])
                    next = right;

                // 왼쪽 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                //검사 위치를 이동
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }
```
## 구현
```c#
PriorityQueue q = new PriorityQueue();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while(q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }
```

<img width="214" alt="20220419_181815" src="https://user-images.githubusercontent.com/90877724/163972783-90242c57-ba7f-460a-9c94-b9df5fcf88b2.png">

