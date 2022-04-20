using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        // 0(1) 상수 시간복잡도
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 방이 없다면, 새로 추가한 첫번째 방이 Head
            if (Head == null)
                Head = newRoom;

            // 기존의 [마지막 방]과 [새로 추가된 방] 연결
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로 추가되는 방]을 [마지막 방]으로 인정 
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        // 0(1) 상수 시간복잡도
        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방의 다음 방]을 [첫번째 방]으로 인정
            if (Head == room)
                Head = Head.Next;

            // [기존의 마지막 방의 이전 방]을 [마지막 방]으로 인정
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }
    class Board_LinkedList
    {
        public int[] _data = new int[25];
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
