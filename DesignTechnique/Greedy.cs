using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignTechnique
{
    internal class Greedy
    {
        /******************************************************
		 * 탐욕 알고리즘 (Greedy Algorithm)
		 * 
		 * 문제를 해결하는데 사용되는 근시안(짧은시야)적 방법
		 * 문제를 직면한 당시에 당장 최적인 답을 선택하는 과정을 반복
		 * 단, 반드시 최적의 해를 구해준다는 보장이 없음
		 * 빠르고 직관적
		 * 
		 * Backtracking과 반대라고 해도 무방
		 ******************************************************/
        
        // 예) 대기열 문제 : 컴퓨터서 동시에 처리가 힘드므로 가장 빠른 시간이 걸리는 프로세스부터 실행

        // 예) 자판기 거스름돈
        void CoinMachine(int money)
        {
            int[] coinType = { 500, 100, 50, 10, 5, 1 };

            foreach (int coin in coinType)
            {
                while (money <= coin)
                {
                    Console.WriteLine("{0} 코인 배출", coin);
                    money -= coin;
                }
            }
        }

    }
}
