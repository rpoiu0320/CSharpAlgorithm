using System.Collections.Generic;

namespace Queue
{
    internal class Program
    {
        /******************************************************
		 * 큐 (Queue)
		 * 환형(원형)배열
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * First In First Out
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 * 
		 * 먼저온 데이터 먼저 처리
		 * 예) 파이프라인, 대기열, 편의점 음료진열대
		 * 
		 * 속도보다는 접근 방식에 따라 사용함
		 ******************************************************/

        static void Test()
		{
            System.Collections.Generic.Queue<int> queue = new System.Collections.Generic.Queue<int>();

			for (int i = 0; i < 10; i++)
			{
				queue.Enqueue(i);					// 0, 1, 2 ... 9
			}
				
            Console.WriteLine(queue.Peek());		// 최전방 확인 : 0

            while (queue.Count < 10)
			{
                Console.WriteLine(queue.Dequeue);	// 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            }
		}
        static void Main(string[] args)
        {
            Test();
        }
    }
}