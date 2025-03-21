using System.Reflection.Metadata;

namespace StructureSample
{
    // 아래 과제가 어려울것 같다 싶으신분들은 Vector2 구조체 먼저 만들어보고 이후에 과제 수행 해주세요.

    /// <summary>
    /// RGBA 값을 가짐.
    /// RGBA 는 범위가 0f ~ 255.0f 로 제한됨. //-1 넣으면 0, 500 넣으면 255
    /// 현재 RGBA 값을 0f ~ 1.0f 범위로 조정하는 옵션이 있어야 함 (bool userNormalizedScale)
    ///     : 옵션 키면 RGBA 스케일이 Of ~ 1f, 끄면 0f ~ 255.0f를 외부에 제공해야함. //'외부에 제공해야함' 힌트
    ///     생성자 오버로드 두개 작성해서 하나는 RGBA 초기값만 받고 이 옵션을 끈채로 객체할당. 다른하나는 이 옵션을 생성자에서 파라미터로 받아서 적용
    /// 비교연산자 (같음 , 다름)
    /// 실수와 나누기 연산자, 실수와 곱하기 연산자
    /// Color 끼리 더하기 연산자, Color 끼리 빼기 연산자
    /// 색상 프리셋 제공 (흰색, 검은색, 파란색, 빨간색, 녹색)
    /// </summary>
    struct Color
    {
        // public 프로퍼티는 PASCAL_CASE
        // 함수이름 PASCAL_CASE
        // private 변수이름 _camelCase
        // 지역변수 (및 파라미터) 이름 cameCase
        // 상수 이름 UPPER_SNAKE_CASE
        
        // 코트 섹터 정렬 순서
        // 1. 생성자
        // 2. 프로퍼티
        // 3. 필드
        // 4. 메서드
        // 5. 연산자

        // 필드를 제외하고는 요소별로 한 라인 띄움.
        // 섹터간에 두 라인 띄움.


        public Color(float red, float green, float blue)
        {
            if (red < 0f)
            {
                _red1 = 0f;
                _red2 = 0f;
            }
            else if (red > 255.0f)
            {
                _red1 = 255.0f;
                _red2 = 255.0f;
            }
            else
            {
                _red1 = red;
                _red2 = red;
            }

            if (green < 0f)
            {
                _green1 = 0f;
                _green2 = 0f;
            }
            else if (green > 255.0f)
            {
                _green1 = 255.0f;
                _green2 = 255.0f;
            }
            else
            {
                _green1 = green;
                _green2 = green;
            }

            if (blue < 0f)
            {
                _blue1 = 0f;
                _blue2 = 0f;
            }
            else if (blue > 255.0f)
            {
                _blue1 = 255.0f;
                _blue2 = 255.0f;
            }
            else
            {
                _blue1 = blue;
                _blue2 = blue;
            }

        }


        // 프로퍼티
        // getter 와 setter 를 간편하게 구현할 수 있는 기능 (캡슐화 용도)
        // get 접근자와 set 접근자를 선택적으로 정의하여 멤버의 직접 접근을 보호할 수 있다.
        // get 혹은 set 에 선택적으로 접근제한자를 추가할 수 있다.

        public float red
        {
            get
            {
                return _red1;
            }
        }

        public float green
        {
            get { return _green1;}
        }

        public float blue { get { return _blue1; } }

        public int option {  get;  set; }


        float _red1, _green1, _blue1;

        float _red2, _green2, _blue2;

        int _option;



        //public float Magnitude => (float)Math.Sqrt(_x * _x + _y * _y + _z * _z); //길이라고 해야 하나?


        //public Vector3 Normalized => new Vector3(_x, _y, _z) / Magnitude; //정규화, 연산자 오버로딩으로 에러가 나지 않음
        public bool userNormalizedScale(float red, float green, float blue)
        {
            return true;
        }

        // public float Magnitude => (float)Math.Sqrt(_red1 * _red1 + _green1 * _green1 + _blue1 * _blue1);

        //public Color Normalized => new Color(_red1, _green1, _blue1) / Magnitude;

        public Color Normalized => new Color(_red1, _green1, _blue1) / 255.0f;



        // 비교 연산자

        public static bool operator ==(Color op1, Color op2) //논리형, 아래 != 도 있어야 함)
             => (op1._red1 == op2._red1) && (op1._green1 == op2._green1) && (op1._blue1 == op2._blue1);

        public static bool operator !=(Color op1, Color op2)
            => !(op1 == op2);


        // 실수와 나누기 연산자, 실수와 곱하기 연산자

        public static Color operator /(Color op1, float op2)
            => new Color(op1._red1 / op2, op1._green1 / op2, op1._blue1 / op2);

        public static Color operator *(Color op1, float op2)
            => new Color(op1._red1 * op2, op1._green1 * op2, op1._blue1 * op2);


        // Color 끼리 연산

        public static Color operator +(Color op1, Color op2)
            => new Color(op1._red1 + op2._red1, op1._green1 + op2._green1, op1._blue1 + op2._blue1);

        public static Color operator -(Color op1, Color op2)
            => new Color(op1._red1 - op2._red1, op1._green1 - op2._green1, op1._blue1 - op2._blue1);


    }


}
