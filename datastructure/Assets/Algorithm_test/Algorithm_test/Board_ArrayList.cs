using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class MyList<T>
    {
        const int DEFAULTSize = 1;
        T[] _data = new T[DEFAULTSize];

        public int Count = 0; //사용 중인 데이터 개수
        public int Capacity { get { return _data.Length; } } //예약 데이터 개수

        // O(1) 예외 케이스 : 상수 시간복잡도
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인
            if (Count >= Capacity)
            {
                // 공간을 늘려서 확보
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }

            // 2. 공간 확보 시 공간에 데이터 삽입
            _data[Count] = item;
            Count++;
        }

        // O(1) 상수 시간복잡도
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];
            _data[Count - 1] = default(T);
            Count--;
        }
    }
    class Board_ArrayList
    {
        public int[] _data = new int[25]; // 배열
        public MyList<int> _data2 = new MyList<int>(); //동적 배열
        public LinkedList<int> _data3 = new LinkedList<int>(); //연결 리스트

        public void Initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}