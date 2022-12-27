using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACAN10
{
    public class Buhg : ICrud
    {
        int mayak = 0;
        int mayak2 = 0;
        int? ID = null;
        string Name;
        float Summ;
        string Quest;
        string searchName = "";
        int? searchID = null;
        double? searchSumm = null;
        string searchQuest = "";
        DateTime searchData;
        int forprimer;
        DateTime data;
        int a = 0;
        ConsoleKeyInfo key;
        static List<Otchet> zapis2 = Myconv.MyDeserialize<List<Otchet>>("Бабки.json");
        public void Create()
        {
            mayak = 1;
            mayak2 = 0;
            Console.Clear();
            Console.WriteLine("Добро пожаловать Бухгалтер");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("  ID:");
            Console.WriteLine("  Название:");
            Console.WriteLine("  Сумма:");
            Console.WriteLine("  Прибавка?:");
            Console.WriteLine("  Дата:");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S  - Сохранить запись");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в меню");
            int a = Arrows(4, 2);
            while (true)
            {
                data = DateTime.Now;
                if (a == 2)
                {
                    Console.SetCursorPosition(5, a);
                    ID = Convert.ToInt32(Console.ReadLine());
                }
                if (a == 3)
                {
                    Console.SetCursorPosition(11, a);
                    Name = Convert.ToString(Console.ReadLine());
                }
                if (a == 4)
                {
                    Console.SetCursorPosition(8, a);
                    Summ = Convert.ToInt32(Console.ReadLine());
                }
                if (a == 5)
                {
                    Console.SetCursorPosition(12, a);
                    Quest = Convert.ToString(Console.ReadLine());
                }
                if(a == 6)
                {
                    
                    Console.SetCursorPosition(7, a);
                    data = Convert.ToDateTime(Console.ReadLine());
                }
                Console.SetCursorPosition(0, a);
                Console.WriteLine("  ");
                a = Arrows(4, 2);

            }
        }

        public void Delete()
        {
            mayak2 = 1;
            zapis2.RemoveAt(forprimer - 4);
            Update();
        }

        public void Read()
        {
            mayak = 0;
            int positiond = 4;
            Console.Clear();
            List<Otchet> list = Myconv.MyDeserialize<List<Otchet>>("Бабки.json");
            
            double itog = 0;
            if (list == null)
            {
                a = 0;
                Console.WriteLine("Вход в панель Склада");
                Console.WriteLine("Имя  - Склад");//посмотреть мб просто передавать имя
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.SetCursorPosition(5, 3);
                Console.WriteLine("  ID");
                Console.SetCursorPosition(15, 3);
                Console.WriteLine("  Имя");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("  Сумма");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Прибавка?");
                Console.SetCursorPosition(0, a + 4);
                Console.WriteLine("------------------------------------------------------------");
                Console.SetCursorPosition(55, a + 5);
                Console.WriteLine("Итог:" + "0");
            }
            else
            {
                a = list.Count;
                Console.WriteLine("Вход в панель Buhgalter");

                List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
                List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Имя  - Buhgalter");
                foreach (var item in dlyav)
                {
                    foreach (var item2 in dlyav2)
                    {
                        if (item2.ID == item.Account && item2.ROLE == 5)
                        {
                            Console.SetCursorPosition(0, 1);
                            Console.WriteLine($"Имя - {item.Name}");
                        }




                    }
                }
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.SetCursorPosition(5, 3);
                Console.WriteLine("  ID");
                Console.SetCursorPosition(15, 3);
                Console.WriteLine("  Имя");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("  Сумма");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Прибавка?");
                foreach (var item in list)
                {

                    Console.SetCursorPosition(5, positiond);
                    Console.WriteLine("  " + item.ID);
                    Console.SetCursorPosition(15, positiond);
                    Console.WriteLine("  " + item.Name);
                    Console.SetCursorPosition(35, positiond);
                    Console.WriteLine("  " + item.Sum);
                    Console.SetCursorPosition(52, positiond);
                    Console.WriteLine("  " + item.Quest);
                    positiond++;
                }
                foreach (Otchet sum in list)
                {
                    itog = sum.Sum + itog;
                }
            }
           
            
            Console.SetCursorPosition(0, a + 4);
            Console.WriteLine("------------------------------------------------------------");
            Console.SetCursorPosition(55, a + 5);
            Console.WriteLine("Итог:" + itog);
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("|Операции:-----------------------");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("|F1  - Добавить запись");
            Console.SetCursorPosition(70, 4);
            Console.WriteLine("|F2 - Найти запись");
            Console.SetCursorPosition(70, 5);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");

            
            forprimer = Arrows(a + 1, 4);
            ReadOnly(forprimer, list);

        }

        public void Update()
        {
            if(mayak2 == 0)
            {
                List<Otchet> zapis = Myconv.MyDeserialize<List<Otchet>>("Бабки.json"); //данный лист нужен для перезаписи значений (запоминает старое и записывает новое)
                Otchet newproduct = new Otchet();
                newproduct.ID = (int)ID;
                newproduct.Name = Name;
                newproduct.Sum = (double)Summ;
                newproduct.data = data;
                if (Quest == "нет")
                {
                    newproduct.Sum = -Summ;
                }
                else if (Quest == "да")
                {
                    newproduct.Sum = Summ;
                }
                newproduct.Quest = Quest;
                if (zapis == null)
                {
                    List<Otchet> newzapis = new List<Otchet>();
                    newzapis.Add(newproduct);
                    Myconv.Myserialize(newzapis, "Бабки.json");
                    Read();
                    Environment.Exit(0);

                }
                else
                {
                    zapis.Add(newproduct);
                    Myconv.Myserialize(zapis, "Бабки.json");
                    Read();
                    Environment.Exit(0);
                }
            }
            else
            {
                Myconv.Myserialize(zapis2, "Бабки.json");
                Read();
                Environment.Exit(0);
            }
           

            

            //Otchet fortest = new Otchet();
            //fortest.ID = (int)ID;
            //fortest.Name = Name;
            //if(Quest == "да")
            //{
            //    fortest.Sum = Summ;
            //}
            //else if(Quest == "нет")
            //{
            //    fortest.Sum = -Summ;
            //}
            
            //fortest.Quest = Quest;
            //List<Otchet> forkl = new List<Otchet>();
            //forkl.Add(fortest);
            //Myconv.Myserialize(forkl, "Бабки.json");
        }
        public int Arrows(int max, int min)
        {
            int position = min;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;
                    Console.SetCursorPosition(0, position + 1);
                    Console.WriteLine("  ");
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                    Console.SetCursorPosition(0, position - 1);
                    Console.WriteLine("  ");
                }
                if ((position - 2) > max)
                {
                    position--;
                }
                if (position < min)
                {
                    position++;
                }
                if(key.Key == ConsoleKey.F1)
                {
                    Create();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.F2)
                {
                    Vibor();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.Escape && mayak == 0)
                {
                    Program.Main();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.Escape && mayak == 1)
                {
                    Read();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Update();
                    Environment.Exit(0);
                }
                if(key.Key ==  ConsoleKey.Delete)
                {
                    Delete();
                    Environment.Exit(0);
                }
               
                


                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

                key = Console.ReadKey();
            }
            return position;

           








        }
        public void ReadOnly(int forprimer, List<Otchet> polz)
        {
            mayak2 = 1;
            mayak = 1;
            Console.Clear();
            Otchet primer = new Otchet();
            primer = polz[forprimer - 4];
            Console.WriteLine("Дополнительная информация");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"  ID:{primer.ID}");
            Console.WriteLine($"  Название:{primer.Name}");                   //после нажатия Enter в первом меню показывает хар-ки которые можно поменять
            Console.WriteLine($"  Сумма:{primer.Sum}");
            Console.WriteLine($"  Прибавка?:{primer.Quest}");
            Console.WriteLine($"  Дата:{primer.data}");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S - Сохранить изменения");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в  предыдущее меню");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("|Delete - Удалить операцию");
            ID = primer.ID;
            Name = primer.Name;
            Summ = (float)primer.Sum;
            Quest = primer.Quest;
            data = primer.data;
            int forchange = Arrows(3, 2);
            while (true)
            {
                switch (forchange)
                {
                    case 2:
                        Console.SetCursorPosition(5, forchange);
                        ID = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.SetCursorPosition(11, forchange);
                        Name = Convert.ToString(Console.ReadLine());
                        break;
                    case 4:
                        Console.SetCursorPosition(8, forchange);
                        Summ = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 5:
                        Console.SetCursorPosition(12, forchange);
                        Quest = Convert.ToString(Console.ReadLine());
                        if(Quest != primer.Quest)
                        {
                            Summ = -Summ;
                        }
                        break;
                    case 6:
                        Console.SetCursorPosition(7, forchange);
                        data = Convert.ToDateTime(Console.ReadLine());
                        break;
                }
                foreach (var item in zapis2)
                {
                    if (item.Name == primer.Name)
                    {
                        item.Name = Name;
                        item.ID = (int)ID;
                        item.Sum = (float)Summ;
                        item.Quest = Quest;
                        item.data = data;
                    }

                }
                forchange = Arrows(3, 2);
            }
        }
        public void Vibor()
        {
            mayak = 1;

            Console.Clear();
            Console.WriteLine("Найти по:");
            Console.WriteLine("  ID:");
            Console.WriteLine("  Название:");
            Console.WriteLine("  Сумма:");
            Console.WriteLine("  Прибавка:");
            Console.WriteLine("  Дате:");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");

            int a = Arrows(3, 1);
            if (a == 1)
            {
                Console.SetCursorPosition(5, a);
                searchID = Convert.ToInt32(Console.ReadLine());
            }
            if (a == 2)
            {
                Console.SetCursorPosition(12, a);
                searchName = Convert.ToString(Console.ReadLine());
            }
            if (a == 3)
            {
                Console.SetCursorPosition(8, a);
                searchSumm = Convert.ToSingle(Console.ReadLine());
            }
            if (a == 4)
            {
                Console.SetCursorPosition(11, a);
                searchQuest = Convert.ToString(Console.ReadLine());
            }
            if(a == 5)
            {
                Console.SetCursorPosition(7, a);
                searchData = Convert.ToDateTime(Console.ReadLine());
            }
            List<Otchet> polz = Myconv.MyDeserialize<List<Otchet>>("Бабки.json");
            int p = 3;
            switch (a)
            {
                case 1:

                    foreach (var item in polz)
                    {

                        if (searchID == item.ID)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по ID");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Название");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Сумма");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Прибавка");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Sum);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Quest);
                            p++;
                        }
                    }
                    break;
                case 2:
                    foreach (var item in polz)
                    {
                        if (searchName == item.Name)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Названию");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Название");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Сумма");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Прибавка");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Sum);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Quest);
                            p++;
                        }
                    }
                    break;
                case 3:
                    foreach (var item in polz)
                    {
                        if (searchSumm == item.Sum)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Сумме");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Название");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Сумма");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Прибавка");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Sum);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Quest);
                            p++;
                        }
                    }
                    break;
                case 4:
                    foreach (var item in polz)
                    {
                        if (searchQuest == item.Quest)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Прибавке");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Название");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Сумма");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Прибавка");

                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Sum);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Quest);
                            p++;
                        }
                    }
                    break;
                case 5:
                    foreach(var item in polz)
                    {
                        if(searchData ==  item.data)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Дате");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Название");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Сумма");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Прибавка");

                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Sum);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Quest);
                            p++;
                        }
                        
                    }
                   break;
            }
            key = Console.ReadKey();
            Console.WriteLine("Выйти из данной менюшки  - Escape");
            if (key.Key == ConsoleKey.Escape)
            {

                Read();
                Environment.Exit(0);

            }
        }
    }
}
