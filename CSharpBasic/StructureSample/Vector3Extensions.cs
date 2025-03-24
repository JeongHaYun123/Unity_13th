using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureSample
{
    static class Vector3Extensions // 객체를 만들 필요가 없다
    {
        //기능 확장하는 경우에만 거의 사용
        //대부분 사용 안 하는 것이 유지보수에 좋다
        public static float Dot(this Vector3 op1, Vector3 op2)
        {
            return (op1.X * op2.X) + (op1.Y * op2.Y) + (op1.Z * op2.Z);
        }
    }
}
