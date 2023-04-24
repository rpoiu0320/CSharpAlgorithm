using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StackAndQueueHomework
{
    // 괄호 검사기
    internal class BracketChecker : StackAdapter<char>      // 스택 구현한거 상속
    {
        private StackAdapter<char> containerBracket;        // 입력값이 저장될 스택들
        private StackAdapter<char> spareInPut;              // 예비는 Pop으로 데이터를 삭제하며 스택을 확인할 때 쓰는 녀석인데 지금 상황에서는 
                                                            // 굳이 원본 스택을 따로 안 살려도 되지만 추가로 동일한 스택을 사용하게 될 수도 있을 것 같아서 따로 지정해 줬습니다.
        public BracketChecker()                             // 생성자 사용
        {
            
        }

        int squareBracketPront = 0;                         // 각각의 괄호들의 갯수를 저장할 변수들입니다.
        int squareBracketBack = 0;
        int bracePront = 0;
        int braceBack = 0;
        int parenthesisPront = 0;
        int parenthesistBack = 0;
        int count = 0;                                      // 데이터의 갯수

        public void InPut()                                 // 수식을 입력받아 스택에 저장합니다.
        {
            Console.Write("수식을 입력해주세요 : ");
            string inPutData = Console.ReadLine();          // 수식을 입력받습니다.  예) (4 + 8) * ({2 + 5} * 2)

            foreach(char item in inPutData)                 // T 형식으로 하면 제 생각대로 구현이 잘 되지 않아서 형을 char로 지정해 줬습니다. 반복기 어떻게 잘 만지면 될 것 같기도 합니다.
            {
                containerBracket.Push(item);                // 스택에 하나씩 넣어줍니다.
                BracketCount(item);                         // 각 괄호들의 갯수를 세어줍니다.
                count++;                                    // 스택의 데이터를 세어줍니다.
            }
            char[] spareInPut = containerBracket.ToArray(); // 만들어진 스택을 복사해줍니다.
        }

        public void BracketCount(char itme)                 // 숫자나 연산자는 제외하고 각 괄호들의 갯수를 세는 함수입니다.
        {
            switch (itme)                                   
            {
                case '[':
                    squareBracketPront++;
                    break;
                case ']':
                    squareBracketBack++;
                    break;
                case '{':
                    bracePront++;
                    break;
                case '}':
                    braceBack++;
                    break;
                case '(':
                    parenthesisPront++;
                    break;
                case ')':
                    parenthesistBack++;
                    break;
                default:
                    break;
            }
        }

        public bool BracketSameCheck()                      // 각각의 괄호들의 열고 닫음이 동일한지 확인하는 함수입니다.
        {
            if (squareBracketPront == squareBracketBack && bracePront == braceBack && parenthesisPront == parenthesistBack)
                return true;
            return false;
        }

        public bool BracketNumCheck()                       // 소괄호 >= 중괄호 >= 대괄호 순이 맞는지 확인하는 함수입니다.
        {                                                   
            if (BracketSameCheck())                         // 앞서 확인한 내용이 틀리면 false 반환
            {
                if (parenthesisPront >= bracePront && bracePront >= squareBracketPront)
                        return true;                        
            }
            return false;                                   
        }

        public bool SequenceCheck()                         // 괄호의 열고 닫음이 제대로 되었는지 확인하는 함수입니다.
        {
            if (!BracketNumCheck())                         // 앞서 확인한 내용이 틀리면 false 반환
                return false;

            int spareCount = count;                         // 스택의 데이터를 가져와줍니다.
            int squareBracketPront = 0;                     // Pop을 하며 하나씩 확인하도록 괄호의 갯수들을 초기화 시킵니다.
            int squareBracketBack = 0;
            int bracePront = 0;
            int braceBack = 0;
            int parenthesisPront = 0;
            int parenthesistBack = 0;

            while (spareCount > 0)                          // 스택의 내용물을 전부 확인하는 반복문
            {
                BracketCount(spareInPut.Pop());             // 스택에 가장 늦게 들어간, 수식의 맨 마지막에 있는 것부터 하나씩 확인해봅니다.
                                                            // 괄호의 순서들이 종합적으로 맞는지 확인해줍니다.
                if(squareBracketPront > squareBracketBack && bracePront > braceBack && parenthesisPront > parenthesistBack)     // 열린 괄호가 닫힌 괄호보다 뒤에 있으면 false
                    return false;                           // false인 예) ") ( ) (", "[ ] ( )"
                spareCount--;                               
            } 
            return true;                                   // 모두 멀쩡하면 true 
        }                                                   // 실행 시 스택오버플로우라 조건이 제대로 설정 되었는지 아리송합니다.

        public void OutPut()
        {
            if (SequenceCheck())
                Console.WriteLine("정상적인 수식입니다.");
            else
                Console.WriteLine("비정상적인 수식입니다.");
        }
    }
}