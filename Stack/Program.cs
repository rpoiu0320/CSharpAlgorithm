namespace Stack
{
    internal class Program
    {
        /******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * First in Last Out, Last in First Out
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 * 예) 뒤로가기, ctrl + z, 선행스킬 관계, 미로찾기 백트래킹
		 * 괄호
		 * 속도보다는 접근 방식에 따라 사용함
		 ******************************************************/

		static void Test()
		{
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < 10; i++)
			{
				stack.Push(i);						// 0, 1, 2, 3, 4, 5 ... 9
			}

            Console.WriteLine(stack.Peek());		// 최상단 확인 : 9

            while (stack.Count > 0)
			{
                Console.WriteLine(stack.Pop());		// 9, 8, 7, 6, 5, 4, 3, 2, 1
            }
		}
        static void Main(string[] args)
        {
			Test();
        }
    }
}