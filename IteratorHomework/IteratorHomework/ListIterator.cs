using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorHomework
{
    internal class List<T> : IEnumerable<T>
    {
        private const int DefaultCapecity = 5;      // 리스트의 전체 요소 수
        public int newCapecity = DefaultCapecity;

        private T[] items;                          // 배열 생성
        private int size;                           // 현 배열의 최대 크기

        public List()
        {
            this.items = new T[DefaultCapecity];    // 리스트 생성
            this.size = 0;
        }
        public int Capacity { get { return items.Length; } }    // 전체 요소 수 출력 시 사용
        public int Count { get { return size; } }   // 리스트의 크기 출력 시 사용

        public T this[int index]                    // 인덱서 구현
        {
            get
            {
                if (index < 0 || index >= size)     // 지정된 범위 벗어나면 오류 표시
                    throw new IndexOutOfRangeException();
                
                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;               // 인덱스 반환 
            }
        }

        public void Add(T item)                     // 개체를 List<T>의 끝 부분에 추가
        {
            if (size >= items.Length)               // 새로 값을 넣을 자리가 없을 때
            {
                Grow();                             // 리스트의 최대 크기 변경
                items[size++] = item;
            }
            else
                items[size++] = item;
        }

        public void Grow()
        {
            newCapecity += DefaultCapecity;             // 최대 크기 증가
            T[] newItems = new T[newCapecity];          // 크기가 증가된 배열 생성
            Array.Copy(items, 0, newItems, 0, size);    // 현 리스트의 내용을 새로 만든 배열에 넣어줌
            items = newItems;                           // 현 배열을 새로 만든 배열로 교체
        }

        public bool Remove(T item)                      // 현재 문자열에서 지정한 수의 문자가 삭제되는 새 문자열을 반환
        {
            int index = Array.IndexOf(items, item);

            if (index < 0 || index >= size)             // 지정된 범위 벗어나면 작동안함
                return false;
            else if (index >= size)                     // 멀쩡한 범위면
            {
                RemoveAt(index);                        // 지정된 문자가 있는 위치를 RemoveAt에 넣어서 삭제처리
                return true;
            }
            else
                return false;
        }

        public void RemoveAt(int index)                 // 지정된 인덱스에 있는 요소 제거
        {
            if (index < 0 || index >= size)             // 지정된 범위 벗어나면 오류 표시
                throw new IndexOutOfRangeException();

            size--;                                     // 현 배열의 최대 크기를 줄여주고
            Array.Copy(items, index + 1, items, index, size - index);   // 지정한 인덱스부터 복사하여 지정된 대상 인덱스부터 시작하는 새로운 배열에 붙여 넣음
        }

        public T? Find(Predicate<T> match)            // 지정된 조건자에 정의된 조건과 일치하는 요소를 검색하고 전체 List<T>에서 처음으로 검색한 요소를 반환
        {
            if (match == null)                        // null 처리
                throw new ArgumentNullException("match");

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))                  // 찾는 값과 동일하면 반환
                    return items[i];
            }

            return default(T);                        // 없으면 기본값 반환
        }

        public int FindIndex(Predicate<T> match)
        {
            int startIndex = 0;
            int count = this.size;
            return FindIndexOverlaoding(startIndex, count, match);
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            int count = this.size;
            return FindIndexOverlaoding(startIndex, count, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            return FindIndexOverlaoding(startIndex, count, match);
        }

        public int FindIndexOverlaoding(int startIndex, int count, Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = startIndex; i < count; i++)
            {
                if (match(items[i]))                  // 찾는 값과 동일하면 배열의 위치
                    return i;
            }

            return -1;                                // 없으면 -1 반환
        }

        public IEnumerator<T> GetEnumerator()       // 검색기
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;   // 리스트의 반복기가 가리킬 리스트
            private int index;      // 리스트의 반복기가 가리킬 인덱스
            private T current;      // 인덱스의 값

            public T Current { get { return current; } }    // 인덱스의 값

            internal Enumerator(List<T> list)   // 사용할 리스트를 가져옴
            {
                this.list = list;
                this.index = 0;
                this.current = default(T);      // 기본값으로 설정해서 무슨 형이 오던 대응
            }

            object IEnumerator.Current
            {
                get
                {
                    if(index < 0 || index >= list.Count)  // 예외처리
                        throw new IndexOutOfRangeException();
                    return current;
                }
            }

            public bool MoveNext()  // null 일 때까지 다음 인덱스로 이동할 함수
            {
                if(index < list.Count)
                {
                    current = list[++index];    // null 아니면 데이터 저장 후 인덱스 증가
                    return true;
                }
                else
                {
                    current = default(T);       // null 이면 값 초기화시키고 false 반환
                    return false;
                }
            }

            public void Reset()                 // 반복기 초기화
            {
                index = 0;                      // 찾을 인덱스와 값을 초기화
                current = default(T);
            }

            public void Dispose() { }           // 리소스 해제?
        }
    }
}
