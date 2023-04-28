using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DisignTechniqueHomework
{
    // 10-10+20 을 10-(10+20) 의 꼴로 만들어야 가장 적은 수가 나옴
    internal class Greedy
    {
        List<int> recordIndex = new List<int>();        // 괄호들을 삽입할 인덱스를 기억하는 리스트
        string inPut;
        int minusNum;
        int plusNum;

        int recording;

        public Greedy(string inPut)
        {
            this.recordIndex = recordIndex;
            this.inPut = inPut;                         // 입력값
            this.minusNum = 0;                          // '-' 의 개수
            this.plusNum = 0;                           // '+' 의 개수
            this.recording = 1;                         // 괄호를 삽입할 인덱스의 개수
        }

        public void OperaterDivision()                  // 연산자 구분
        {
            for (int i = 0; i < inPut.Length; i++)
            {
                if (inPut[i] == '-')                    // '-' 일 때
                {
                    recordIndex.Add(i + recording++);   // '(' 를 '-' 의 다음 위치에 넣기 위해 '-' 의 위치를 기록
                    minusNum++;                         // '-' 의 개수 증가
                }

                if ((minusNum > 0 && plusNum > 0 && (inPut[i] == '+' || inPut[i] == '-' ) )|| i == inPut.Length - 1)   // ')' 를 넣을 위치를 찾음
                {
                    recordIndex.Add(i + recording++);   // ')' 를 넣을 위치 기록
                    minusNum--;                         
                    plusNum--;                          // 괄호가 닫힌걸 뜻함
                }

                if (minusNum > 0)                       // 앞에 '-' 가 있을 떄
                {
                    if (inPut[i] == '+')                // '+' 가 있다면
                    {
                        plusNum++;                      // '+' 의 개수 증가
                    }
                }
            }
        }

        public void InsertParentheses()                 // 괄호를 특정 위치에 넣어줌
        {
            int parenthesesCount = recordIndex.Count;

            if (parenthesesCount % 2 == 0)                  // 괄호가 앞 뒤가 맞아야하므로
            {
                for (int i = 0; i < recordIndex.Count; i++)
                {
                    if (parenthesesCount % 2 == 0)                  
                    {
                        inPut = inPut.Insert(recordIndex[i], "(");  // 넣어야 할 괄호가 짝수면 
                        parenthesesCount--;
                    }
                    else
                    {
                        inPut = inPut.Insert(recordIndex[i], ")");  // 넣어야 할 괄호가 홀수면
                        parenthesesCount--;
                    }
                }
            }
        }

        public void OutPut()                               // 출력
        {
            // Console.WriteLine(int.Parse(inPut));        // 이것저것 해봤는데 FormatException 에 계속 막힙니다.
            Console.WriteLine(inPut);
        }
    }
}
