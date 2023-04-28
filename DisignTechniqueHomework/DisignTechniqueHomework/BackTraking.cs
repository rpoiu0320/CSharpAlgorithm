using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisignTechniqueHomework
{
    // 자연수 N과 M이 주어졌을 때, 아래 조건을 만족하는 길이가 M인 수열을 모두 구하는 프로그램을 작성하시오.
    // 1부터 N까지 자연수 중에서 M개를 고른 수열
    // 같은 수를 여러 번 골라도 된다.
    internal class BackTraking
    {
        int maxNum;
        int length;
        int[] array;
        int index;

        public BackTraking(int maxNum, int length)
        {
            this.maxNum = maxNum;
            this.length = length;
            this.index = 0;
            int[] array = new int[this.length];

            foreach (int item in array)
            {
                array[item] = 1;
            }
        }

        public void Bae()
        {

        }

        public void Calculate()
        {
            if (End())
                return;

            index = length - 1;

            while (true)
            {
                if (array[index] <= maxNum)
                {
                    OutPut();
                    array[index] = array[index] + 1;
                }
                else
                    break;
            }
            Calculate();
        }

        public bool End()
        {
            foreach (int item in array)
            {
                if(!Equals(item, maxNum))
                    return false;
            }
            return true;
        }

        public void OutPut()
        {
            int index = 0;
            foreach(int item in array)
            {
                if(index == length - 1)
                    Console.WriteLine($"{0} ", array[item]);
                Console.Write($"{0} ", array[item]);
                index++;
            }
        }
    }
}
