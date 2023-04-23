namespace StackAndQueueHomework
{
    internal class Program
    {
        /* 1. 스택(어뎁터), 큐(순환배열) 구현
         * ---------------------------------
         * 2. 스택
         * 괄호 검사기
         * 스택 계산기
         * 3. 큐
         * 속도가 빠른 플레이어부터 행동
         * 요세푸스 순열 
         */
        static void Main(string[] args)
        {
            BracketChecker bracketChecker = new BracketChecker();       // 스택오버플로우가 발생합니다.

            bracketChecker.InPut();                 
            bracketChecker.OutPut();
        }
    }
}