using System.Net.Mail;

namespace PracticeOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            object obj = (object)1; // Boxing
            object obj2 = new object();
            obj2 = 1; //obj2 == obj 같다(구문이)
            a = (int)obj; // Unboxing
            // Boxing Unboxing 은 연산비용이 높기때문에 지양해야한다.

            GamePlayManager gamePlayerManger = new GamePlayManager();

            Console.WriteLine("Press any key to start the game ...");
            Console.ReadKey();
            Console.Clear();
            gamePlayerManger.PlayGame();
        }
       /* enum CharacterClass
        {
            Nothing,
            Warrior,
            Magician
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Warrir(1), Magician(2)");
            Console.Write("Choose your character class : ");
            CharacterClass currentClass = (CharacterClass)Enum.Parse(typeof(CharacterClass), Console.ReadLine()); //Eunm 클래스 : enum 타입 관련 편의 기능들을 가지고 있음.

            Character player = new Warrior("깡통", "깡통");

            switch (currentClass) {
                case CharacterClass.Nothing:
                    break;

                case CharacterClass.Warrior:
                    player = new Warrior("Player", "Warrior");
                    Console.WriteLine(player.Name);
                    Console.WriteLine(player.CharacterClass);
                    Console.WriteLine(player.Hp);
                    break;

                case CharacterClass.Magician:
                    player = new Magician("Player", "Magician");
                    Console.WriteLine(player.Name);
                    Console.WriteLine(player.CharacterClass);
                    Console.WriteLine(player.Hp);
                    break;
            }
            PC pc = (PC)player;
            pc.Attack();
            Random random = new Random();
            double percent = random.NextDouble() * 100;
            Console.WriteLine(percent);
            if (percent < 70)
            {
                Enemy enemy = new Mushroom();
                enemy.Attack(player);
                Console.WriteLine(player.Hp);
            }
        }*/
    }
}
