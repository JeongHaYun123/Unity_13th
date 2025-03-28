namespace DelegateSample
{
    internal class Program
    {
        public delegate int OperationHandler(int a, int b);

        static void Main(string[] args)
        {
            // 대리자는 의존성을 감소 시켜서 유지보수하기 쉽게 만들어 준다.
            Youtuber youtuber1 = new Youtuber("NG"); /// 유튜버 생성
            // 인라인 함수 : 현재 라인에 함수구현 그대로 삽입, C# 에서는 인라인함수를 구현할때 람다식(익명함수) 로 구현함
            youtuber1.Subscribe((youtuber, content) => Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---")); //함수 이름으로 부를 필요가 없음
            youtuber1.OnContentUploaded += (youtuber, content) => Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---");

            Subscriber subscriber1 = new Subscriber("Luke"); /// 구독자 루크 생성
            Subscriber subscriber2 = new Subscriber("Carl"); /// 구독자 칼 생성
            Subscriber subscriber3 = new Subscriber("Cherry"); /// 구독자 체리 생성

            youtuber1.OnContentUploaded += subscriber1.Notification; //해당 함수의 위치 참조하게 해줌 // 알림 함수 구독
            youtuber1.OnContentUploaded += subscriber2.Notification;
            //youtuber1.OnContentUploaded = subscriber3.Notification;

            Content content1 = new Content("에드형과 야생에서 살아남기!!"); /// 컨텐츠 생성
            youtuber1.UploadContent(content1); /// 유튜버1에 컨텐츠 업로드

            youtuber1.OnContentUploaded -= subscriber1.Notification; // 구독 취소 //람다식으로 하면 구독 취소가 안된다.


            Content content2 = new Content("한시즌 1억버는 꽃게잡이 신참 브이로그"); /// 컨텐츠 생성
            youtuber1.UploadContent(content2); /// 유튜버1에 컨텐츠 업로드

            OperationHandler operationHandler = delegate (int a, int b) ///이 형식은 많이 안 쓰기 때문에 별로 안 중요하다
                                                {
                                                    return a + b;
                                                };
        }

        /*static void SomethingUploaded(Youtuber youtuber, Content content) //youtuber1.Subscribe(SomethingUploaded);
        {
            Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---");
        }*/

        // 람다식 표현 방법 :
        // 컴파일러가 판단할수있는 (즉, 굳이 명시하지않아도 기정사실화되어있는 요소) 를 다 지우고 '=>' 기호를 파라미터와 구현부 사이에 추가한다
        // 인라인 함수는, 해당라인에 직접 삽입하므로, 함수를 이름으로 검색할 필요가 없어서 이름 필요없다.
        // 현재 라인에 삽입하기때문에 static 인지 instance 인지는 의미가 없다.
        // 만약 대리자에 구독을 하는경우 이미 파라미터 타입과 반환타입이 정해져있기때문에 파라미터타입과 반환타입을 명시할 필요 없다.
        // 함수 구현부 코드가 한줄 이라면 반드시 그 라인이 return 문이기 때문에 함수의 구현부를 {} 중괄호로 구분할 필요가 없다.
        static void SomethingIploaded(Youtuber youtuber, Content content)
        {
            Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---");
        }
    }
}
