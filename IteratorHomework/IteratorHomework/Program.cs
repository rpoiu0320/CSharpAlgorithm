using Microsoft.VisualBasic;

namespace IteratorHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IteratorHomework.List<int> list = new IteratorHomework.List<int>();
            IteratorHomework.LinkedList<int> linkedList = new IteratorHomework.LinkedList<int>();

            for (int i = 1; i <= 5; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);

                node = node.Next;
            }
        }
    }
}