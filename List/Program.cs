namespace List
{
    internal class Program
    {
        /******************************************************
		 * 배열 (Array)       기술문제    (스택영역)
		 * 
		 * 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
		 * 초기화때 정한 크기가 소멸까지 유지됨 
		 * (Array.resize는 기존 배열을 기준으로 복사하여 다른 크기를 가진 새로운 배열을 생성하는거임, 배열 크기 변경X)
		 * 
		 * 배열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능
		 * 
		 * 메모리구조상으로 이해하기
		 ******************************************************/

        // <배열의 사용>     
        void Array()    // 
        {
            int[] intArray = new int[100];

            // 인덱스를 통한 접근
            intArray[0] = 10;
            int value = intArray[0];
        }

        // <배열의 시간복잡도>          (선형탐색)
        // 접근		탐색
        // O(1)		O(N)

        // int 배열 20번째 자료 접근 : 20번째 자료의 주소 == 배열의 주소  + int의 자료형의 크기 * 19


        // 데이터가 n개 있을 때 탐색 
        public int Find(int[] intArray, int data)
        {
            for(int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == data)
                    return i;
            }
            return -1;
        }


        /******************************************************
		 * 동적배열 (Dynamic Array)     (힙영역)
		 * 
		 * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		 * 배열요소의 갯수를 특정할 수 없는 경우 사용, 크기를 정하지 않고 생성
		 * 
		 * 처음 생성할 때 크게 만들어 두고 요소를 추가할 때 마다 수정, 동적할당 더 찾아보기
		 * List는 length가 없음, count를 사용해야함
		 ******************************************************/

        // <List의 사용> (System.Collections.Generic 이게 있어야 사용 가능)
        void List()     // (선형탐색)
        {
            List<string> a;
            List<int> b;    
            // 등등

            List<string> list = new List<string>();     

            // 배열 요소 삽입
            list.Add("0번 데이터");
            list.Add("1번 데이터");
            list.Add("2번 데이터");

            // 배열 요소 삭제                 삭제하면 뒤에 있는 데이터를 빈자리로 당김, 배열의 크기도 줄어듬
            list.Remove("1번 데이터");

            // 배열 요소 접근
            list[0] = "데이터0";
            string value = list[0];

            // 배열 요소 탐색
            string? findValue = list.Find(x => x.Contains('2'));
            int findIndex = list.FindIndex(x => x.Contains('0'));
        }

        // <List의 시간복잡도>                (선형탐색)
        // 접근		탐색		삽입		삭제
        // O(1)		O(n)	O(n)	O(n)


        static void Main(string[] args)
        {
            /* List<string> list = new List<string>();

            // list.Capacity    여유공간 확인

            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");

            string value;
            value = list[0];
            value = list[1];
            value = list[2];
            value = list[3];
            value = list[4];

            list[0] = "5번 데이터";
            list[1] = "4번 데이터";
            list[2] = "3번 데이터";
            list[3] = "2번 데이터";
            list[4] = "1번 데이터";

            list.Remove("3번 데이터");
            list.Remove("2번 데이터");

            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1')); */

            DataStructuer.List<string> list = new DataStructuer.List<string>();

            list.Add("1번 데이터");     // 추가
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");

            list.Remove("2번 데이터");  // 삭제
            list.RemoveAt(2);

            list[0] = "첫번째 데이터";    // 접근
            string str = list[0];

            for(int i  = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            string? findValue = list.Find(x => x.Contains('4'));    // 탐색
            int findIndex = list.FindIndex(x => x.Contains('1'));

        } 

        /* Array, ArrayList, List 각 특징들
         * 
         * <Array>
         * 고정된 배열 크기를 가짐 (선언 시 크기를 지정, 삭제 및 추가와 같은 변형 불가)
         * 같은 타입만 저장 가능 (type safe하다)
         * 다차원 배열 입력이 가능
         * 
         * <ArrayList>
         * 고정되지 않는, 추가 및 삭제의 변형이 가능한 객체 타입 (가변 객체)
         * 제네릭 타입으로서 서로 다른 타입의 데이터를 저장 가능, 따라서 데이터를 가져올 때 박싱 및 언박싱 발생 (type - safe하지 못하다)
         * 
         * <List>
         * 고정되지 않는, 추가 및 삭제의 변형이 가능한 객체 타입 (가변 객체)
         * ArrayList의 단점을 보완, 컴파일시 배열의 타입추론을 함
         * 즉 같은 타입만 저장 가능, 박싱 및 언박싱 미발생
         * 
         */
    }
}