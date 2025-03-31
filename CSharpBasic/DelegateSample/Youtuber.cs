using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Youtuber
    {
        public Youtuber(string nickname) ///유튜버 생성자
        {
            Nickname = nickname;
        }

        public string Nickname { get; private set; } ///유튜버 필드

        public delegate void OnContentUploadedHandler(Youtuber youtuber, Content content); //대리자 정의, 자료형 이름이 OnContent~Handler이다. //Subscriber 에 있는 Notification 함수랑 다를 게 없다. // 대리자 정의 (사용자정의자료형) //delegate
        // event 한정자
        // 현재 타입 외에는 이 대리자에 접근할때 +=, -= 의 L-Value 로만 사용가능하도록 제한하는 한정자 //유튜버는 접근할 수 있다, 멤버 변수의 경우 event를 안 붙이는 경우가 거의 없다.
        public event OnContentUploadedHandler OnContentUploaded; // 대리자 타입 변수 //배열 형식인 듯
        //{
        //    add //재정의 해서 사용 가능
        //    {
        //        Console.WriteLine("구독자 + 1");
        //        _onContentIploaded += value;
        //    }
        //    remove
        //    {
        //        Console.WriteLine("구독자 - 1");
        //        _onContentIploaded -= value;
        //    }
        //}
        //private OnContentUploadedHandler _onContentIploaded;

        private Content[] _contents = new Content[100]; /// 유튜버당 콘텐츠 제한 100
        private int _count; /// 컨텐츠 갯수 카운트

        public void UploadContent(Content content) /// 컨텐츠 업로드
        {
            OnContentUploadedHandler aa = new OnContentUploadedHandler((x, y) => Console.WriteLine()); //인라인 함수, 함수 검색 필요 X, 비용이 싸다

            if (_count >= _contents.Length) /// 컨텐츠 크기 배열보다 카운트가 클 시 예외
                throw new Exception("컨텐츠 업로드 허용량을 초과하였습니다.");

            _contents[_count++] = content; /// 컨텐츠 배열에 컨텐츠 업로드 및 카운트 업
            OnContentUploaded(this, content); // 대리자에 구독된 모든 함수 호출 (구독한 순서대로)
        }

        void somethingTodo(Youtuber x, Content y)
        {
            Console.WriteLine();
        }

        public void Subscribe(OnContentUploadedHandler onContentUploaded)
        {
            OnContentUploaded += onContentUploaded;
        }
    }
}
