using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueueHomework
{
    // 선입후출
    internal class StackAdapter<T>
    {
        private List<T> container;          // 리스트를 기반으로 해서(어뎁터) 스택 구현
        
        public StackAdapter()               // 생성자서 리스트 생성
        {
            container = new List<T>();
        }

        public void Push(T item)            // 개체를 스택 맨 위에 삽입
        {
            container.Add(item);            // 선입후출을 위해 List의 Add 함수를 사용하여 
        }                                   // 배열의 맨 뒤에 데이터를 넣어줌

        public T Pop()                      // 스택 맨 위에서 개체를 제거하고 반환
        {
            T value = container[container.Count - 1];   // 배열의 맨 뒤에 있는 개체를 저장
            container.RemoveAt(container.Count - 1);    // List의 RemoveAt을 이용하여 개체 제거
            return value;                               // 배열에서 제거된 개체 반환
        }

        public T Peek()                     // 스택 맨 위에서 개체를 제거하지 않고 반환
        {
            T value = container[container.Count - 1];   // 배열의 맨 뒤에 있는 개체를 저장
            return value;                               // 배열의 맨 뒤의 개체 반환
        }

        public void Clear()                 // Stack에서 개체를 모두 제거
        {
            while(container.Count > 0)      // 남은 개체가 없을 때 까지 반복
            {
                container.RemoveAt(container.Count - 1);    // 남은 개체가 없을 때 까지 개체 제거
            }
        }

        public bool Contains(T item)        // 배열에 요소가 있는지 여부를 확인
        {
            if(container.Contains(item))    // 요소가 있으면 
                return true;                // true 반환
            else
                return false;               // 없으면 false 반환
        }

        public T[] ToArray()                // 복사본을 포함하는 새 배열
        {
            T[] output = container.ToArray();   // 배열 복사
            return output;                      // 복사된 배열 반환
        }
    }
}
