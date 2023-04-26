namespace HashTableHomework
{
    internal class Program
    {
        //                       키, 값           키를 비교하기 위해 인터페이스 사용
        public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
        {
            private const int DefaultCapacity = 1000; // Dicionary 의 초기 크기

            private struct Entry    // 키 값 등이 변동되지 않기 위해 구조체 사용
            {
                public enum State { None, Using, Deleted }   // 키가 해당 index에 있는지 확인하기 위한 열겨형

                public TKey key;                            // 키
                public TValue value;                        // 값(데이터)
                public int hashCode;                        // 해싱
                public State state;                         // 열거형
            }

            private Entry[] table;                      // 열거형 선언

            public Dictionary()                         // 생성자
            {
                table = new Entry[DefaultCapacity];     // Hash Talbe 기록할 table 선언
            }

            // 탐색
            public TValue this[TKey key]
            {
                get
                {
                    // 1. key를 index로 해싱
                    int index = Math.Abs(key.GetHashCode() % table.Length);
                    // key가 index와 대응하기 위해 HashCode 생성 후 Length보다 큰 값이 나오지 않도록 Length로 나눠준 후 절댓값으로 해줌
                
                    // 2. key가 일치하는 데이터가 나올 때까지 다음으로 이동
                    while (table[index].state == Entry.State.Using)         // 해당 인덱스에 데이터가 있다면
                    {
                        // 3-1. 동일한 키 값을 찾았을 때 반환하기
                        if (key.Equals(table[index].key))                   // 동일한 키 값으면
                            return table[index].value;                      // 해당 인덱스의 데이터 반환

                        // 3-2. 동일한 키 값을 못찾고 비어있는 공간을 만났을 때
                        if (table[index].state == Entry.State.None)
                            break;                                          // 반복을 끝내고 오류 반환
                        
                        // 3-3. 다음 index로 이동
                        index = ++index % table.Length;
                    }
                    throw new InvalidOperationException();                  // 오류 반환
                }
                set
                {
                    // 1. key를 index로 해싱
                    int index = Math.Abs(key.GetHashCode() % table.Length);
                    // key가 index와 대응하기 위해 HashCode 생성 후 Length보다 큰 값이 나오지 않도록 Length로 나눠준 후 절댓값으로 해줌

                    // 2. key가 일치하는 데이터가 나올 때까지 다음으로 이동
                    while (table[index].state == Entry.State.Using)         // 해당 인덱스에 데이터가 있다면
                    {
                        // 3-1. 동일한 키 값을 찾았을 때 덮어쓰기
                        if (key.Equals(table[index].key))                   // 동일한 키 값으면
                            return;                      // 해당 인덱스의 데이터 반환

                        // 3-2. 동일한 키 값을 못찾고 비어있는 공간을 만났을 때
                        if (table[index].state == Entry.State.None)
                            break;                                          // 반복을 끝내고 오류 반환

                        // 3-3. 다음 index로 이동
                        index = ++index % table.Length;
                    }
                    throw new InvalidOperationException();                  // 오류반환
                }
            }

            // 추가
            public void Add(TKey key, TValue value)
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. 사용중이 아닌 index까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3-1. 동일한 키값을 찾았을때 오류 (C# Dictionary는 중복을 허용하지 않음
                    if (key.Equals(table[index].key))
                        throw new AggregateException();

                    // 3-2. 다음 index로 이동
                    index = ++index % table.Length;
                }
                // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
                table[index].hashCode = key.GetHashCode();
                table[index].key = key;
                table[index].value = value;
                table[index].state = Entry.State.Using;
            }
            
            // 제거
            public bool Remove(TKey key)
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. 지울 키 값과 동일한 키 값을 찾을때까지 index 증가
                while (true)
                {
                    // 3-1. 동일한 키 값을 찾았을때 지운상태로 표시
                    if (key.Equals(table[index].key))
                    {
                        table[index].state = Entry.State.Deleted;
                        return true;
                    }
                    // 3-2. 키 값에 아무것도 없다면 
                    if (table[index].state == Entry.State.None)
                        break;                                              // 아무것도 안하고 정지
                    // 3-3. 다음 인덱스로 이동
                    else
                        index = ++index % table.Length;
                }
                throw new InvalidOperationException();                      // 오류반환
            }


        
        
        
        
        
        
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}