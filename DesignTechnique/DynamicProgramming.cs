using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignTechnique
{
    internal class DynamicProgramming
    {
        /******************************************************
		 * 동적계획법 (Dynamic Programming)
		 * 
		 * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
		 * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
		 * 
		 * 분할정복과 대충 반대대는 개념?
		 ******************************************************/

        // 예) 피보나치 수열
        int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];
            fibonachi[1] = 1;
            fibonachi[2] = 1;

            for (int i = 3; i <= x; i++)
            {
                fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
            }

            return fibonachi[x];
        }

        // 예) 연속 합
        // n개의 정수로 이루어진 임의의 수열에서 연속된  몇 개의 수를 선택해서 구할 수 있는 합 중 가장 큰 합을 구하시오.
        // 단, 수는 한 개 이상 선택

    }
}
