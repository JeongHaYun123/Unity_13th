using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureSample
{
    //11111111 = 128 + 64 + 32 + 16 + 8 + 4 + 2 + 1 = 255 //byte를 써서 255까지 표현 가능
    struct Color32
    {
        public Color32(byte r, byte g, byte b, byte a)
        {
            R = r; G = g; B = b; A = a;
        }


        public byte R, G, B, A;
    }
}
