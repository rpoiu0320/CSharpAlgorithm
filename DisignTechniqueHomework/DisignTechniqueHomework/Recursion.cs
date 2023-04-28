using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DisignTechniqueHomework
{
    // 하노이의 탑
    internal class Recursion
    {
        public static Stack<int>[] stick;
        int moveCount = 0;

        Recursion()
        {
            this.moveCount = 0;
        }
        
        public static void Move(int topCount, int start, int end)
        {
            if (topCount == 1)
            {
                // 그냥 이동
                int node = stick[start].Pop();
                stick[end].Push(node);
                Console.WriteLine($"{start} 스틱에서 {end} 스틱으로 {node} 이동");
                return;
            }
            int other = 3 - start - end;

            Move(topCount - 1, start, other);
            Move(1, start, end);
            Move(topCount - 1, other, end);
        }

        public void MoveCountOutPut()
        {

        }
    }
}
