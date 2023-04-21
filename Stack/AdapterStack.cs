using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /******************************************************
	 * 어댑터 패턴 (Adapter)
	 * 
	 * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	 ******************************************************/
    internal class AdapterStack<T>
    {
        private List<T> container;

        public AdapterStack()
        {
            container = new List<T>();
        }

        public void Push(T item)
        {
            container.Add(item);
        }

        public T Pop()
        {
            T value = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return value;
        }
    }


}
