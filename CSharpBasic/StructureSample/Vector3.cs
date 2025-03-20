//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace StructureSample
{
    // 구조체의 장점은, 값타입으로 빠르게 데이터 그룹을 쓰고 읽는것인데
    // 구조체는 16 byte 를 넘어가게되면 참조타입을 전달하는것 보다 성능이 좋지 않다.. (쓸 이유가 없어짐)
    struct Vector3
    {
        // 접근 제한자
        // public    - 외부에서 접근 가능
        // internal  - 동일 어셈블리(코드조각, exe / dll 등 같은 프로그램 단위) 에서 접근 가능
        // protected - 상속자만 접근 가능
        // private   - 외부 접근 불가능

        // 구조체는 기본적으로 내부 데이터를 보호하는 컨셉이기때문에 접근제한자를 명시하지 않으면 private 임.
        public Vector3(float x, float y, float z) //안쓰면 private 있는 거랑 다를 게 없다, FM으로 하면 internal이 맞다 ( 다른 곳에 사용할 일이 없기 때문에)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /*
         * 람다식 표현
         * 컴파일러가 판단할 수 있는 요소를 생략하는 표현방식
         * 생략할거 다 생략한 다음에 '파라미터 => 구현부' 형식으로 작성함. //생략할 수 있는 모든 걸 생략 할 필요는 없다
         */
        public static Vector3 Forward
        {
            get => new Vector3(0f, 0f, 1f);
        }

        public static Vector3 Back => new Vector3(0f, 0f, -1f);

        public static Vector3 Right => new Vector3(1f, 0f, 0f);

        public static Vector3 Left => new Vector3(-1f, 0f, 0f);

        public static Vector3 Up => new Vector3(0f, 1f, 0f);

        public static Vector3 Down => new Vector3(0f, -1f, 0f);

        public static Vector3 Zero => new Vector3(0f, 0f, 0f);

        public static Vector3 One => new Vector3(1f, 1f, 1f);

        public float Magnitude => (float)Math.Sqrt(_x * _x + _y * _y + _z * _z); //길이라고 해야 하나?

        public Vector3 Normalized => new Vector3(_x, _y, _z) / Magnitude; //정규화, 연산자 오버로딩으로 에러가 나지 않음

        // 프로퍼티
        // getter 와 setter 를 간편하게 구현할 수 있는 기능 (캡슐화 용도)
        // get 접근자와 set 접근자를 선택적으로 정의하여 멤버의 직접 접근을 보호할 수 있다.
        // get 혹은 set 에 선택적으로 접근제한자를 추가할 수 있다.

        /*public float id { get; private set; } // 프로퍼터 축약표현

        public float id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
        float _id;*/

        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }

            set
            {
                _z = value;
            }
        }


        float _x, _y, _z; //연산 효율이 중요하니 게임에서는 double보다 float를 사용한다.


        public static float Distance(Vector3 op1, Vector3 op2)
            =>(float)Math.Sqrt((op1._x - op2._x) * (op1._x - op2._x) +
                               (op1._y - op2._y) * (op1._y - op2._y) +
                               (op1._z - op2._z) * (op1._z - op2._z));

        // 캡슐화 - 멤버 를 외부로부터 보호하는 컨셉을 적용하는 과정
        public float GetX()
        {
            return _x;
        }

        public void SetX(float x)
        {
            _x = x;
        }

        public float GetY()
        {
            return _y;
        }

        public void SetY(float y)
        {
            _y = y;
        }

        public float GetZ()
        {
            return _z;
        }

        public void SetZ(float z)
        {
            _z = z;
        }

        public void MoveX(float distance)
        {
            _x += distance;
        }

        // 연산자 오버로딩
        public static Vector3 operator /(Vector3 op1, float op2)
            => new Vector3(op1._x / op2, op1._y / op2, op1._z / op2);

        public static Vector3 operator /(Vector3 op1, int op2)
            => new Vector3(op1._x / op2, op1._y / op2, op1._z / op2);

        public static Vector3 operator *(Vector3 op1, float op2)
            => new Vector3(op1._x * op2, op1._y * op2, op1._z * op2);

        public static Vector3 operator *(Vector3 op1, int op2)
            => new Vector3(op1._x * op2, op1._y * op2, op1._z * op2);

        public static bool operator ==(Vector3 op1, Vector3 op2) //논리형, 아래 != 도 있어야 함)
            => (op1._x == op2._x) && (op1._y == op2._y) && (op1._z == op2._z);

        public static bool operator !=(Vector3 op1, Vector3 op2)
            => !(op1 == op2);
    }
}