namespace StructureSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3; // 그냥 값타임 변수는 리터럴상수나 다른 변수 대입해서 초기화 하면 됨.
            Vector3 velocity = new Vector3(3, 5, 2); // 구조체 변수는 구조체 생성자를 통해서 초기화 로직을 수행해야함.(다른 구조체 변수 대입도 됨)
            velocity.SetX(velocity.GetX() + 1f);
            //position.MoveX(1f);
            velocity.X += 1;

            //Vector3 forward = new Vector3(0, 0, 1); //앞쪽 방향 벡터 계속 정의하기 귀찮으니 이럴 때 쓰는 스택
            //Vector3 forward = Vector3.Forward;

            Console.WriteLine($"Magnitude : {velocity.Magnitude}");

            //Console.WriteLine($"{velocity.Normalized.X}");

            Vector3 target1Position = new Vector3(5f, 2f, 3.2f);
            Vector3 target2Position = new Vector3(-5f, 3.4f, 1.2f);
            target1Position = target2Position;
            target1Position += Vector3.Forward;
            target1Position += new Vector3(0f, 0f, 1f);

            if (target1Position.X == target2Position.X)
            {
                Console.WriteLine("target1 과 target2 가 동일한 위치에 있음");
            }

            Console.WriteLine($"distance : {Vector3.Distance(target1Position, target2Position)}"); //두 점? 사이 거리

            // 3/24 Vector3Extensions.cs
            //확장 함수
            target1Position.Dot(target2Position); // 앞에 this를 붙였기에 사용 가능
            float dot = Vector3Extensions.Dot(target1Position, target2Position);


            // Color


            Console.WriteLine("첫 번째 RGB 값을 입력하세요. ( 0.0 ~ 255.0 )");
            Console.Write("R : ");
            float r1 = float.Parse(Console.ReadLine());
            Console.Write("G : ");
            float g1 = float.Parse(Console.ReadLine());
            Console.Write("B : ");
            float b1 = float.Parse(Console.ReadLine());

            Color target1Color = new Color(r1, g1, b1);

            Console.WriteLine("두 번째 RGB 값을 입력하세요. ( 0.0 ~ 255.0 )");
            Console.Write("R : ");
            float r2 = float.Parse(Console.ReadLine());
            Console.Write("G : ");
            float g2 = float.Parse(Console.ReadLine());
            Console.Write("B : ");
            float b2 = float.Parse(Console.ReadLine());

            Color target2Color = new Color(r2, g2, b2);

            Color target3Color = new Color(0, 0, 0);
            Color target4Color = new Color(0, 0, 0);

            int active = 1;
            int noramloption = 0;
            int menu = 1;
            int menu2 = 1;
            int menu3 = 1;
            int menu4 = 1;
            float number = 1;

            while (active == 1)
            {
                Console.Clear();
                if (noramloption == 1)
                {
                    if (target1Color.red == 0 && target1Color.green == 0 && target1Color.blue == 0)
                    {
                        Console.WriteLine($"현재 RGB 값 : {target1Color.red}, {target1Color.green}, {target1Color.blue}   //    {target2Color.Normalized.red}, {target2Color.Normalized.green}, {target2Color.Normalized.blue}");

                    }
                    else if (target2Color.red == 0 && target2Color.green == 0 && target2Color.blue == 0)
                    {
                        Console.WriteLine($"현재 RGB 값 : {target1Color.Normalized.red}, {target1Color.Normalized.green}, {target1Color.Normalized.blue}   //    {target2Color.red}, {target2Color.green}, {target2Color.blue}");
                    }
                    else
                    {
                        Console.WriteLine($"현재 RGB 값 : {target1Color.Normalized.red}, {target1Color.Normalized.green}, {target1Color.Normalized.blue}   //    {target2Color.Normalized.red}, {target2Color.Normalized.green}, {target2Color.Normalized.blue}");
                    }
                }
                else
                {
                    Console.WriteLine($"현재 RGB 값 : {target1Color.red}, {target1Color.green}, {target1Color.blue}   //    {target2Color.red}, {target2Color.green}, {target2Color.blue}");
                }
                Console.WriteLine("1 : RGB 재 입력, 2 : 연산, 3 : 색상 프리셋 제공, 4 : 정규화 여부, 5 : 종료");
                Console.Write("원하는 메뉴를 입력해 주세요 : ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("첫 번째 RGB 값을 입력하세요. ( 0.0 ~ 255.0 )");
                        Console.Write("R : ");
                        r1 = float.Parse(Console.ReadLine());
                        Console.Write("G : ");
                        g1 = float.Parse(Console.ReadLine());
                        Console.Write("B : ");
                        b1 = float.Parse(Console.ReadLine());

                        target1Color = new Color(r1, g1, b1);

                        Console.WriteLine("두 번째 RGB 값을 입력하세요. ( 0.0 ~ 255.0 )");
                        Console.Write("R : ");
                        r2 = float.Parse(Console.ReadLine());
                        Console.Write("G : ");
                        g2 = float.Parse(Console.ReadLine());
                        Console.Write("B : ");
                        b2 = float.Parse(Console.ReadLine());

                        target2Color = new Color(r2, g2, b2);

                        break;
                    case 2: // 미완성
                        Console.Clear();
                        Console.WriteLine("1 : 두 RGB의 연산, 2 : 실수와 연산");
                        Console.Write("원하는 메뉴를 입력해 주세요 : ");
                        menu2 = int.Parse(Console.ReadLine());
                        if(menu2 == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("1 : 비교 연산, 2 : 덧셈 연산, 3 : 뺄셈 연산");
                            Console.Write("원하는 메뉴를 입력해 주세요 : ");
                            menu3 = int.Parse(Console.ReadLine());
                            switch (menu3)
                            {
                                case 1:
                                    Console.Clear();
                                    if(target1Color == target2Color)
                                    {
                                        Console.WriteLine("두 RGB의 값은 같습니다");
                                        Thread.Sleep(5000);
                                    }
                                    else
                                    {
                                        Console.WriteLine("두 RGB의 값은 다릅니다");
                                        Thread.Sleep(5000);
                                    }
                                        break;
                                case 2:
                                    Console.Clear();
                                    target3Color = target1Color + target2Color;
                                    Console.WriteLine($"두 RGB의 합은 {target3Color.red}, {target3Color.green}, {target3Color.blue} 입니다.");
                                    Console.WriteLine("1 : 첫 번째 RGB에 저장, 2 : 두 번째 RGB에 저장, 3 : 두 개의 RGB에 저장, 4 : 취소");
                                    Console.Write("원하는 메뉴를 입력해 주세요 : ");
                                    menu4 = int.Parse(Console.ReadLine());
                                    if(menu4 == 1)
                                    {
                                        target1Color = target3Color;
                                    }
                                    else if(menu4 == 2)
                                    {
                                        target2Color = target3Color;
                                    }
                                    else if(menu4 == 3)
                                    {
                                        target1Color = target3Color;
                                        target2Color = target3Color;
                                    }
                                    else if(menu4 == 4)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                        Thread.Sleep(2000);
                                    }

                                        break;
                                case 3:
                                    Console.Clear();
                                    target3Color = target1Color - target2Color;
                                    Console.WriteLine($"두 RGB의 뺼셈은 {target3Color.red}, {target3Color.green}, {target3Color.blue} 입니다.");
                                    Console.WriteLine("1 : 첫 번째 RGB에 저장, 2 : 두 번째 RGB에 저장, 3 : 두 개의 RGB에 저장, 4 : 취소");
                                    Console.Write("원하는 메뉴를 입력해 주세요 : ");
                                    menu4 = int.Parse(Console.ReadLine());
                                    if (menu4 == 1)
                                    {
                                        target1Color = target3Color;
                                    }
                                    else if (menu4 == 2)
                                    {
                                        target2Color = target3Color;
                                    }
                                    else if (menu4 == 3)
                                    {
                                        target1Color = target3Color;
                                        target2Color = target3Color;
                                    }
                                    else if (menu4 == 4)
                                    {
                                    }
                                    else
                                    {
                                        Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                        Thread.Sleep(2000);
                                    }

                                    break;
                            }
                        }
                        else if(menu2 == 2)
                        {
                            Console.Clear();
                            Console.Write("실수를 입력해 주세요 : ");
                            number = float.Parse(Console.ReadLine());
                            Console.WriteLine("1 : 나눗셈, 2 : 곱셈, 3 : 취소");
                            Console.Write("원하는 메뉴를 입력해주세요 : ");
                            menu3 = int.Parse(Console.ReadLine());
                            if(menu3 == 1)
                            {
                                Console.Clear();
                                target3Color = target1Color / number;
                                target4Color = target2Color / number;
                                Console.WriteLine($"{number}을 나눈 RGB 값입니다");
                                Console.WriteLine($"첫 번째 RGB : {target3Color.red}, {target3Color.green}, {target3Color.blue}");
                                Console.WriteLine($"두 번째 RGB : {target4Color.red}, {target4Color.green}, {target4Color.blue}");
                                Console.WriteLine("1 : 첫 번째 RGB에 저장, 2 : 두 번째 RGB에 저장, 3 : 두 개의 RGB에 저장, 4 : 취소");
                                Console.Write("원하는 메뉴를 입력해주세요 : ");
                                menu4 = int.Parse(Console.ReadLine());
                                switch(menu4)
                                {
                                    case 1:
                                        target1Color = target3Color;
                                        Console.WriteLine("첫 번째 RGB에 저장이 완료되었습니다.");
                                        Thread.Sleep(5000);
                                        break;
                                    case 2:
                                        target2Color = target4Color;
                                        Console.WriteLine("두 번째 RGB에 저장이 완료되었습니다.");
                                        Thread.Sleep(5000);
                                        break;
                                    case 3:
                                        target1Color = target3Color;
                                        target2Color = target4Color;
                                        Console.WriteLine("두 개의 RGB에 저장이 완료되었습니다.");
                                        Thread.Sleep(5000);
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            }
                            else if(menu3 == 2)
                            {
                                Console.Clear();
                                target3Color = target1Color * number;
                                target4Color = target2Color * number;
                                Console.WriteLine($"{number}을 곱한 RGB 값입니다");
                                Console.WriteLine($"첫 번째 RGB : {target3Color.red}, {target3Color.green}, {target3Color.blue}");
                                Console.WriteLine($"두 번째 RGB : {target4Color.red}, {target4Color.green}, {target4Color.blue}");
                                Console.WriteLine("1 : 첫 번째 RGB에 저장, 2 : 두 번째 RGB에 저장, 3 : 두 개의 RGB에 저장, 4 : 취소");
                                Console.Write("원하는 메뉴를 입력해주세요 : ");
                                menu4 = int.Parse(Console.ReadLine());
                                switch (menu4)
                                {
                                    case 1:
                                        target1Color = target3Color;
                                        Console.WriteLine("첫 번째 RGB에 저장이 완료되었습니다.");
                                        Thread.Sleep(5000);
                                        break;
                                    case 2:
                                        target2Color = target4Color;
                                        Console.WriteLine("두 번째 RGB에 저장이 완료되었습니다.");
                                        Thread.Sleep(5000);
                                        break;
                                    case 3:
                                        target1Color = target3Color;
                                        target2Color = target4Color;
                                        Console.WriteLine("두 개의 RGB에 저장이 완료되었습니다.");
                                        Thread.Sleep(5000);
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            }
                            else if(menu3 == 3)
                            {

                            }
                            else
                            {
                                Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                Thread.Sleep(2000);
                            }  
                        }
                        else
                        {
                            Console.WriteLine("잘못된 값을 입력하셨습니다.");
                            Thread.Sleep(2000);
                        }
                            break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("1 : 첫 번째 RGB, 2 : 두 번째 RGB");
                        Console.Write("색상을 적용 할 RGB를 선택해 주세요 : "); //흰색, 검은색, 파란색, 빨간색, 녹색
                        menu2 = int.Parse(Console.ReadLine());

                        if(menu2 != 1 && menu2 != 2)
                        {
                            Console.WriteLine("잘못된 값을 입력하셨습니다.");
                            Thread.Sleep(2000);
                            break;
                        }

                        Console.WriteLine("1 : 흰색, 2 : 검은색, 3 : 파란색, 4 : 빨간색, 5 : 녹색");
                        Console.Write("적용 할 색상을 선택해 주세요 : ");
                        menu3 = int.Parse(Console.ReadLine());
                        if (menu2 == 1)
                        {
                            switch (menu3)
                            {
                                case 1:
                                    target1Color = new Color(0f, 0f, 0f);
                                    break;
                                case 2:
                                    target1Color = new Color(255f, 255f, 255f);
                                    break;
                                case 3:
                                    target1Color = new Color(0f, 0f, 255f);
                                    break;
                                case 4:
                                    target1Color = new Color(255f, 0f, 0f);
                                    break;
                                case 5:
                                    target1Color = new Color(0f, 255f, 0f);
                                    break;
                                default:
                                    Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                    Thread.Sleep(2000);
                                    break;
                            }
                        }
                        else if (menu2 == 2)
                        {
                            switch (menu3)
                            {
                                case 1:
                                    target2Color = new Color(0f, 0f, 0f);
                                    break;
                                case 2:
                                    target2Color = new Color(255f, 255f, 255f);
                                    break;
                                case 3:
                                    target2Color = new Color(0f, 0f, 255f);
                                    break;
                                case 4:
                                    target2Color = new Color(255f, 0f, 0f);
                                    break;
                                case 5:
                                    target2Color = new Color(0f, 255f, 0f);
                                    break;
                                default:
                                    Console.WriteLine("잘못된 값을 입력하셨습니다.");
                                    Thread.Sleep(2000);
                                    break;
                            }
                        }
                            break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"현재 정규화 여부는 {noramloption} 입니다.");
                        Console.WriteLine("0 : 종료, 활성화 : 1");
                        Console.Write("원하는 메뉴를 입력해 주세요 :");
                        int noramlcheck = int.Parse(Console.ReadLine());
                        if (noramlcheck != 0 && noramlcheck != 1)
                        {
                            Console.WriteLine("잘못된 값을 입력하셨습니다.");
                            Thread.Sleep(2000);
                            break;
                        }

                        noramloption = noramlcheck;
                        break;
                    case 5:
                        active = 0;
                        break;
                    default:
                        Console.WriteLine("잘못된 값을 입력하셨습니다.");
                        Thread.Sleep(2000);
                        break;
                }

            }
        }
    }
}
