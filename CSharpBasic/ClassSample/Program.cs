namespace ClassSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 클래스 생성자 오버로드를 따로 정의하지 않으면
            // 멤버변수를 초기값대로 초기화하는 public 한 생성자가 기본값으로 사용된다.
            Eagle eagle1 = new Eagle();

            Pigeon pigeon1 = new Pigeon();
        }
    }
}
