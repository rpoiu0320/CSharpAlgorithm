using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorHomework
{
    // 반복기 (Enumerator(Iterator))

    /* 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
     * 
     * 모두 데이터를 저장하는 데이터들의 집합임
     * 자료구조들의 작동원리를 모두 알고 있어야만 원하는대로 사용이 가능함
     * 대부분의 자료구조가 반복기를 지원함
     * 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
     * 이용 가능한 자료구조는 IEnumerable 인터페이스를 가지고 있음
     * 
     *  반복기를 이용한 순회
     * foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
     * 즉, 반복기가 있다면 foreach 반복문으로 순회 가능
     * 반복할 때 배열을 건드리면 안됌, 배열을 추가, 삭제하면 새로운 배열이 생성되기에 반복기가 가리키는 배열과 달라지게됨
     */
    internal class IteratorPreparation
    {
    }
}
