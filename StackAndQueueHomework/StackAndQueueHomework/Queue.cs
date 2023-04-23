using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueueHomework
{
    // array를 이용해서 Queue 구현
    // 선입선출 (편의점 음료 매대)
    internal class Queue<T>
    {
        private const int DefaultCapacity = 4;      // 배열의 기본값 지정
        private T[] array;                          // 배열 생성
        private int head;                           // 전단을 가리킬 변수
        private int tail;                           // 후단을 가리킬 변수

        public int Count                            // 데이터의 갯수를 새줌
        {
            get                                        //  전단             후단
            {                                          /* |   |   |   |   |   | */
                if (head <= tail)                      // 배열 상 전단이 후단 앞에 있을 때
                    return tail - head;
                else                                   // 배열 상 전단이 후단 뒤에 있을 때
                    return tail - head + array.Length; /* |   |   |   |   |   | */
            }                                          //  후단    전단 
        }

        public Queue()                              // 배열을 사용할 생성자
        {
            array = new T[DefaultCapacity + 1];     // 배열이 가득 찼음을 구분하기 위해서는
                                                    // 생성할 때를 제외하고 전단과 후단이 겹치는 상황을 
                                                    // 만들지 않아야 하므로 전단의 앞 배열을 빈 공간으로 만들어 구분한다.
            head = 0;                               
            tail = 0;                               // 개체가 없으므로 전단과 후단이 같은곳에 있음
        }

        public void MoveNext(ref int index)         // 전단, 후단 인덱스로 이동
        {
            if (index == array.Length - 1)          // 전단 또는 후단이 마지막 인덱스를 가리키고 있으면
                index = 0;                          // 원형배열이기에 0으로 이동
            else
                index++;                            // 아니면 전단 또는 후단을 다음 인덱스로 이동
        }

        public void Enqueue(T item)                 // 개체를 끝 부분에 추가
        {
            if (IsFull())                           // 배열이 가득 찼으면
                Grow();                             // 배열의 크기를 늘려줌

            array[tail] = item;                     // 후단의 위치에 개체를 넣어주고
            MoveNext(ref tail);                     // 후단을 다음 인덱스로 이동
        }

        public T Dequeue()                          // 개체 꺼내기(배열서 제거)
        {
            if (IsEmpty())                           // 배열이 비어있다면
                throw new InvalidOperationException();  // 예외처리

            T result = array[head];                 // 선입선출이기에 전단의 개체를 반환시키기위해 저장해줌
            MoveNext(ref head);                     // 전단을 다음 인덱스로 이동
            return result;                          // Queue서 제거된(배열상에는 남아있긴함) 개체 반환
        }

        public T Peek()                             // 전단에서 개체를 제거하지 않고 반환
        {
            if (IsEmpty())                          // 배열이 비어있다면
                throw new InvalidOperationException();  // 예외처리

            return array[head];                     // 전단이 가리키는 개체 반환
        }

        public void Clear()                         // 개체를 모두 제거
        {
            Array.Clear(array);                     // 배열 내 개체 모두 삭제
            head = 0;                               // 전단과 후단 초기화
            tail = 0;
        }

        private bool IsEmpty()                      // 배열이 비어있음을 구분 (처음 만들 때 등)
        {
            return head == tail;                    // 처음 만들때만 전단과 후단이 0이므로 
        }

        private bool IsFull()                       // 배열이 가득 찼음을 구분
        {
            if (head > tail)                        // 배열 상 전단이 후단 뒤에 있을 때
                return head == tail + 1;            // 후단 + 빈 공간이 전단과 같으면 꽉 찼음을 알 수 있음

            else                                    // 배열 후단 이 맨 뒤에 있을 때
            {                                       // 후단이 맨 뒤에 있고 꽉 찼다는것은 전단이 맨 앞에 있다는 뜻
                                                    /* |   |   |   |   |   | */
                                                    //  전단            후단
                                                    //                 빈공간
                return head == 0 && tail == array.Length - 1;
            }
        }

        private void Grow()                         // 배열이 가득 찼을 때 배열을 늘려줄 함수
        {
            int newCapecity = array.Length * 2;     // 새로 지정할 배열의 크기

            if(head < tail)                         // 배열 상 전단이 후단 앞에 있을 때
                Array.Resize<T>(ref array, newCapecity);    // Resize로 배열의 크기를 늘려줌
            
            else                                    // 배상 상 전단이 후단 뒤에 있을 때
            {
                T[] newArray = new T[newCapecity];  // 크기가 증가된 배열 생성
                Array.Copy(array, head, newArray, 0, array.Length - head);  // 전단에서부터 배열의 마지막까지의 개체를 먼저 넣어줌
                // Array.Copy(복사할 배열, 복사 시작점, 저장될 배열, 저장될 시작점, 저장시작점부터 넣을 개수

                Array.Copy(array, 0, newArray, array.Length - head, tail);  // 이후 배열의 첫번째부터 후단까지의 개체를 넣어줌
                head = 0;                           // 배열 상 첫번째 배열부터 순차적으로 개체가 들어있으므로 전단을 0으로 설정
                tail = Count;                       // 후단을 배열 내 마지막 개채를 가리키도록 설정
                array = newArray;
            }
        }


    }
}
