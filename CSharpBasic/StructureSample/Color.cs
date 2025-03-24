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


        /*public Color(float red, float green, float blue)
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
        */

        public Color(float r, float g, float b, float a)
        {
            _r = Clamp(r);
            _g = Clamp(g);
            _b = Clamp(b);
            _a = Clamp(a);
        }

        public Color(float r, float g, float b, float a, bool use255Scale)
        {
            float max = use255Scale ? 255f : 1f;
            _r = Clamp(r, 0f, max);
            _g = Clamp(g, 0f, max);
            _b = Clamp(b, 0f, max);
            _a = Clamp(a, 0f, max);
            _use255Scale = use255Scale;
        }


        public bool Use255Scale
        {
            get => _use255Scale;
            set
            {
                if (_use255Scale == value)
                    return;

                if (value)
                    Scale1To255();
                else
                    Scale255To1();

                _use255Scale = value;
            }
        }

        public float R
        {
            get => _r;
            set
            {
                _r = Clamp(value, 0, _use255Scale ? 255f: 1f);
            }
        }

        public float G
        {
            get => _g;
            set
            {
                _g = Clamp(value, 0, _use255Scale ? 255f : 1f);
            }
        }

        public float B
        {
            get => _b;
            set
            {
                _b = Clamp(value, 0, _use255Scale ? 255f : 1f);
            }
        }

        public float A
        {
            get => _a;
            set
            {
                _a = Clamp(value, 0, _use255Scale ? 255f : 1f);
            }
        }

        //public static Color White => new Color() { _r = 1.0f, _g = 1.0f, _b = 1.0f, _a = 1.0f }; //생성자가 없을 때 초기화 방법
        public static Color White => WhiteColor;
        public static Color White255 => WhiteColor255;
        public static Color Black => new Color() { _r = 0.0f, _g = 0.0f, _b = 0.0f, _a = 0.0f }; //생성자가 없을 때 초기화 방법
        public static Color Red => new(1f, 0f, 0f, 1f);

        static readonly Color WhiteColor = new Color(1f, 1f, 1f, 1f);
        static readonly Color WhiteColor255 = new Color() { _r = 255f, _g = 255f, _b = 255f, _a = 255f, _use255Scale = true };

        float _r, _g, _b, _a; // 이 예제에서는 멤버변수가 캡슐화 되어있지만, 구조체는 값을 빠르게 읽고 쓰는 이점때문에 사용하므로
        // 멤버변수를 public 으로 공개해서 캡슐화하지않고 사용하는 경우가 많다.
        bool _use255Scale;
        const float MAX_255_SCALE = 255f;

        /// <summary>
        /// 값 범위 제한
        /// </summary>
        /// <param name="value"> 원본 값 </param>
        /// <param name="min"> 범위 최소 값 </param>
        /// <param name="max"> 범위 최대 값 </param>
        /// <returns> 제한된 값 </returns>
        private float Clamp(float value, float min = 0f, float max = 1f) //중간에 0f만 넣어줄 수는 없다.
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            
            return value;
        }

        private void Scale1To255()
        {
            _r *= MAX_255_SCALE;
            _g *= MAX_255_SCALE;
            _b *= MAX_255_SCALE;
            _a *= MAX_255_SCALE;
        }

        private void Scale255To1()
        {
            _r /= MAX_255_SCALE;
            _g /= MAX_255_SCALE;
            _b /= MAX_255_SCALE;
            _a /= MAX_255_SCALE;
        }

        public static bool operator ==(Color op1, Color op2)
        {
            if(op1._use255Scale != op2._use255Scale) //위에도 _use255Scale이 아니라 Use255Scale 사용 가능 (하지만 밑에는 바꾸면 안된다)
                op2.Use255Scale = op1.Use255Scale;
            
            return (op1._r == op2._r) && (op1._g == op2._g) && (op1._b == op2._b) && (op1._a == op2._a);
        }
            //=> (op1._r == op2._r) && (op1._g == op2._g) && (op1._b == op2._b) && (op1._a == op2._a);

        public static bool operator !=(Color op1, Color op2)
            => !(op1 == op2);

        public static Color operator +(Color op1, Color op2)
        {
            if(op1._use255Scale != op2._use255Scale)
                op2.Use255Scale = op1.Use255Scale;
            
            return new Color(op1._r + op2._r, op1._g + op2._g, op1._b + op2._b, op1._a + op2._a, op1._use255Scale);
        }
            //=> new Color(op1._r + op2._r, op1._g + op2._g, op1._b + op2._b, op1._a + op2._a); //자료형 타입 Color (float와 bool 필드 모두 포함), 구조체 자체도 자료형이다. //int도 사실은 구조체이다. (int32 구조체) 

        public static Color operator -(Color op1, Color op2)
        {
            if(op1._use255Scale != op2._use255Scale)
                op2.Use255Scale = op1.Use255Scale;

            return new Color(op1._r - op2._r, op1._g - op2._g, op1._b - op2._b, op1._a - op2._a, op1._use255Scale);
        }
            //=> new Color(op1._r - op2._r, op1._g - op2._g, op1._b - op2._b, op1._a - op2._a);

        public static Color operator *(Color op1, float op2)
            => new Color(op1._r * op2, op1._g * op2, op1._b * op2, op1._a * op2);

        public static Color operator /(Color op1, float op2)
            => new Color(op1._r / op2, op1._g / op2, op1._b / op2, op1._a / op2);

    }


}
