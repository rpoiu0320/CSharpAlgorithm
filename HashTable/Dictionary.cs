using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey> // 키 값을 비교하기 위해
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public TKey key;
            public TValue value;
            public int hashCode;
            public State state;
        }

        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }

        // 탐색
        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. key가 일치하는 데이터가 나올 때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3-1. 동일한 키값을 찾았을때 반환하기
                    if (key.Equals(table[index].key))
                    {
                        return table[index].value;
                    }
                    // 3-2. 동일한 키값을 못찾고 비어있는 공간을 만났을 때
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    // 3-3. 다음 index로 이동
                    index = ++index % table.Length;
                }
                throw new InvalidOperationException();
            }
            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. key가 일치하는 데이터가 나올 때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3. 동일한 키값을 찾았을때 덮어쓰기
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return;
                    }
                    if (table[index].state == Entry.State.None)
                        break;

                    index = ++index % table.Length;
                }
                throw new InvalidOperationException();
            }
        }

        // 추가
        public void Add(TKey key, TValue value)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. 사용중이 아닌 index까지 다음으로 이동
            while(table[index].state == Entry.State.Using)
            {
                // 3-1. 동일한 키값을 찾았을때 오류 (C# Dictionary는 중복을 허용하지 않음
                if (key.Equals(table[index].key))
                    throw new AggregateException();

                // 3-3
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

            // 2. key값과 동일한 데이터를 찾을때까지 index 증가
            while (table[index].state == Entry.State.Using)
            {
                // 3-1. 동일한 키값을 찾았을때 지운상태로 표시
                if (key.Equals(table[index].key))
                {
                    table[index].state = Entry.State.Deleted;
                    return true;
                }
                if (table[index].state == Entry.State.None)
                {
                    break;
                }
                else
                    index = ++index % table.Length;
            }
            throw new InvalidOperationException();
        }
    }
}
