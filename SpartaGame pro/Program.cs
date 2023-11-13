

namespace SpartaGame_pro
{
    internal class Program 
    {
        private static Char player;
        private static Item item1;
        private static Item item2;



        static void CharCreate()
        {
            Console.Clear();
            Console.WriteLine("게임에 사용하실 닉네임을 입력해주세요.");
            Console.Write(">> ");
            
            string userName = Console.ReadLine();
            player = new Char($"{userName}", "전사", 01, 10, 5, 100, 1500);
            item1 = new Item(0, "낡은 검", 2, 0, "쉽게 볼 수 있는 검");
            item2 = new Item(1, "무쇠갑옷", 0, 5, "무쇠로 만들어진 튼튼한 갑옷");
        }


        //메인 마을
        static void MainMenu()
        {
            Console.Clear ();
            Console.WriteLine("스파트타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가지 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CharInfo();
                    break;
                case "2":
                    CharInven();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
        }


        //캐릭터상태보기
        static void CharInfo() 
        {
            int saveAtk = player.Atk;
            int saveDef = player.Def;

            if (item1.ItemWearing == true)
            {
                saveAtk += item1.ItemAtk;
            }
            else if ( item1.ItemWearing == false)
            {
                saveAtk = player.Atk;
            }
            if (item2.ItemWearing == true)
            {
                saveDef += item2.ItemDef;
            }
            else if (item2.ItemWearing == false)
            {
                saveDef = player.Def;
            }

            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.Write($"공격력 : {saveAtk}");
            Console.WriteLine($" {(item1.ItemWearing ? "(+2)" : "")}");
            Console.Write($"방어력 : {saveDef}");
            Console.WriteLine($" {(item2.ItemWearing ? "(+5)" : "")}");
            Console.WriteLine($"체 력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    CharInfo();
                    break;
            }
        }
        
        

    //캐릭터 인벤토리
    static void CharInven() 
        {

            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            Console.Write($"- {(item1.ItemWearing ? "[E]": "")}");
            Console.WriteLine($"{item1.Name}     | 공격력 +{item1.ItemAtk}, | {item1.ItemDetail}");
            Console.Write($"- {(item2.ItemWearing ? "[E]" : "")}");
            Console.WriteLine($"{item2.Name}     | 방어력 +{item2.ItemDef}, | {item2.ItemDetail}");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    MainMenu();
                    break;
                case "1":
                    ItemSetting();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    CharInven();
                    break;

            }

        }

        static void ItemSetting()
        {

            Console.Clear();

            Console.WriteLine("장착 및 해제를 하실 아이템을 선택해주세요.");
            Console.WriteLine();
            Console.Write($"1. - {(item1.ItemWearing ? "[E]" : "")}");
            Console.WriteLine($"{item1.Name}     | 공격력 +{item1.ItemAtk}, | {item1.ItemDetail}");
            Console.Write($"2. - {(item2.ItemWearing ? "[E]" : "")}");
            Console.WriteLine($"{item2.Name}     | 방어력 +{item2.ItemDef}, | {item2.ItemDetail}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">>");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    CharInven();
                    break;
                case "1":
                    if (item1.ItemWearing == false)
                    {
                        item1.ItemWearing = true;
                        Console.WriteLine("장비를 장착했습니다.");
                    }
                    else if (item1.ItemWearing == true)
                    {
                        item1.ItemWearing = false;
                        Console.WriteLine("장비를 해제했습니다.");
                    }
                    break;
                case "2":
                    if (item2.ItemWearing == false)
                    {
                        item2.ItemWearing = true;
                        Console.WriteLine("장비를 장착했습니다.");                        
                    }
                    else if (item2.ItemWearing == true)
                    {
                        item2.ItemWearing = false;
                        Console.WriteLine("장비를 해제했습니다.");                        
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    ItemSetting();
                    break;



            }
            Console.ReadLine();
            CharInven();

        }

        static void Main(string[] args)
        {
            CharCreate();
            MainMenu();
        }
    }

    //캐릭터 정보
    public class Char 
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }
        public int BaseAtk;
        public int BaseDef;

        public Char(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;            
        }
    }

    
    public class Item
    {
        public int ItemId;
        public string Name;
        public int ItemAtk;
        public int ItemDef;
        public string ItemDetail;
        public bool ItemWearing;

        public Item(int itemId, string name, int itemAtk, int itemDef, string itemDetail)
        {
            ItemId = itemId;
            Name = name;
            ItemAtk = itemAtk;
            ItemDef = itemDef;
            ItemDetail = itemDetail;
            ItemWearing = false;
        }
    }

    //[구현 못한 것들]
    
    //아이템 스텟 적용
}