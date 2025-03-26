using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * interface 키워드 :
 * 외부 객체와 상호작용을위한 기능들을 추상화 하기위한 사용자정의 자료형을 정의할때 사용하는 키워드
 * 상호작용이 목적이기때문에 접근제한자는 public 이 기본값이다.
 * "기능"의 추상화이므로 데이터를 포함할수없다 (즉, 멤버변수 같은것은 선언할 수 없다)
 * 다중상속이 가능하다.
 * interface 를 상속받은 interface 도 가능하다
 */
namespace PracticeOOP
{
    interface IDamageable
    {
        int HpMax { get; }

        int Hp { get; }

        void Damage(IAttacker attacker, int amount); //원래 인터페이스끼리 참조하는 것은 좋지 못하지만 간편하게 하기위해 사용함
    }
}
