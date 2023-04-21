namespace DataStructure
{
    /******************************************************
	 * Queue 구현
	 * 환형(원형)배열
	 * 
	 * Queue를 배열로 구현할 때는 앞을 삭제해도 땡기는 대신
	 * 앞을 가리키는 인덱스를 다음으로 가리킴
	 * 추가 할 때 배열이 가득 찼으면 뒤를 가리키는 인덱스를 맨 앞으로 움직임
	 * 앞과 뒤를 가리키는 놈들이 동시에 같은 것을 가리키면 비어있는 것과 꽉차있는 것의 구분이 어려움
	 * 후단이 전단 바로 앞에 있는 곳을 비워 꽉 차있다고 인식을 하도록 만들어야 함
	 ******************************************************/
    internal class Queue<T>
    {
		private const int DefaultCapacity = 4;	// 배열의 기본값

		private T[] array;						// 배열
		private int head;						// 전단
		private int tail;						// 후단
		public int Count						// 데이터가 몇개 들어있는지
		{
			get
			{
				if (head <= tail)				// 전단이 후단 앞에 있을 때
					return tail - head;
				else							// 전단이 후단 뒤에 있을 때
					return tail - head + array.Length;
			}
		}

		public Queue()
		{
			array = new T[DefaultCapacity + 1];	// 전단 후단이 겹치지 않도록 
			head = 0;
			tail = 0;
		}

		public void Enqueue(T item)				// 데이터 추가
		{
			if (IsFull())						// 배열이 가득 찼을 때
				Grow();							// 크기를 늘려줌

			array[tail] = item;
			MoveNext(ref tail);
		}

		public T Dequeqe()						// 데이터 꺼내기(배열서 제거)
		{
			if (IsEmpty())						// 빈 값 꺼내지 않게 예외처리
				throw new InvalidOperationException();

			T result = array[head];
			MoveNext(ref head);
			return result;
		}

		public T Peek()							// 데이터 출력
		{
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[head];
		}

		private void MoveNext(ref int index)	// 전, 후단 위치이동
		{
			index = (index == array.Length - 1) ? 0 : index + 1;
		}

		private bool IsEmpty()					// 처음 만들 때
		{
			return head == tail;				// 데이터가 없어 전단과 후단이 같은 곳을 가리키고 있음
		}

		private bool IsFull()					// 가득 찼을 때
		{
			if (head > tail)					// 배열 상 전단이 후단 뒤에 있을 때
				return head == tail + 1;
            else                                // 후단이 맨 끝에 있을 때
                return head == 0 && tail == array.Length - 1;	
		}

		private void Grow()						// 배열 크기 늘리기
		{
			int newCapecity = array.Length * 2;
			T[] newArray = new T[newCapecity];
			if (head < tail)					// 전단이 후단 앞에 있을 때
				Array.Copy(array, newArray, Count);
			else								// 전단이 후단 뒤에 있을 때
			{
				Array.Copy(array, head, newArray, 0, array.Length - head);
				Array.Copy(array, 0, newArray, array.Length - head, tail);
				head = 0;
				tail = Count;
			}
			
			array = newArray;
		}

    }
}
