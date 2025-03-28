using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Content
    {
        public Content(string title) ///컨텐츠 생성자
        {
            Title = title;
        }

        public string Title { get; private set; } ///컨텐츠 필드
    }
}
