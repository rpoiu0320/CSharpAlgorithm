namespace Iterators
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 ******************************************************/
        void Iterators()
        {
            // 모두 데이터를 저장하는 데이터들의 집합임
            // 자료구조들의 작동원리를 모두 알고 있어야만 원하는대로 사용이 가능함
            // 대부분의 자료구조가 반복기를 지원함
            // 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            // 이용 가능한 자료구조는 IEnumerable 인터페이스를 가지고 있음

            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();


            // 반복기 없이 순회
            for (int i = 1; i <=5; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);

                node = node.Next;
            }

            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
            // 즉, 반복기가 있다면 foreach 반복문으로 순회 가능
            foreach (int i in list) { }
            foreach (int i in linkedList) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            foreach (int i in IterFunc()) { }

            // 반복기 직접조작
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) 
                strings.Add(string.Format("{0}데이터", i));

            IEnumerator<string> iter = strings.GetEnumerator();
            iter.MoveNext();    // 다음으로
            Console.WriteLine(iter.Current);    // output : 0데이터
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 1데이터

            iter.Reset();       // 처음으로
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current); // 1, 2, 3, 4, 5
            }
        }

        public void Find(IEnumerable<int> container)
        {
            IEnumerator<int> iter = container.GetEnumerator();

            iter.Reset();
            while (iter.MoveNext())
            {
                if (iter.Current == 10)
                    Console.WriteLine("10 발견");
            }
        }

        IEnumerable<int> IterFunc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static void Main(string[] args)
        {
            Iterator.List<int> list = new Iterator.List<int>();

            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine(i);

            }
                     
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            /*
            Iterator.Reset();
            while (Iterator.MoveNext())
            {
                Console.WriteLine(Iterator.Current);
            }*/
        }
    }
}