using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuer
{
    internal class List<T>
    {
        // 리스트 작동구조 직접 구현

        private const int DefaultCapecity = 4;

        private T[] items;
        private int size;

        public List() 
        {
            this.items = new T[DefaultCapecity];
            this.size = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }
        public void Add(T item)
        {
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();
                items[size++] = item;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0 || index >= size)
            {
                return false;
            }
            else if (index >= 0)
            {
                // 찾은 경우
                RemoveAt(index);
                return true;
            }
            else
            {
                // 못 찾은 경우
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);

        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public T? Find(Predicate<T> match)
        {
            if(match == null) 
                throw new ArgumentNullException("match");

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < size; ++i)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;         // 리스트 크기를 더 크게 지정
            T[] newItems = new T[newCapacity];          // 새 리스트의 크기를 지정 후 생성
            Array.Copy(items, 0, newItems, 0, size);    // 리스트 복사
            // 원본배열, 원본배열의 복사 시작위치, 복사될 배열, 복사될 배열의 시작위치    / 복사개수도 추가 가능
            items = newItems;                           // 원본에 새로 만들어진 리스트를 넣어줌
        }
    }
}
