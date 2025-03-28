using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Subscriber
    {
        public Subscriber(string nickname) ///구독자 생성자
        {
            Nickname = nickname;
        }

        public string Nickname { get; private set; } ///구독자 필드

        public void Notification(Youtuber youtber, Content content) ///알림 함수
        {
            Console.WriteLine($"{Nickname} 에게 알림! {youtber.Nickname} 이(가) {content.Title} 게시함.");
        }
    }
}
