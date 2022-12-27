using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRACAN10
{
    public class Sklad : ICrud
    {
        int mayak = 0;
        int mayak2 = 0;
        int? ID = null;
        string Name;
        double? Price = null;
        int? Count = null;
        string searchName = "";
        int? searchID = null;
        double? searchPrice = null;
        int? searchCount = null;
        int forprimer;
        int a = 0;
        ConsoleKeyInfo key;
        static List<Products> zapis2 = Myconv.MyDeserialize<List<Products>>("Продукты.json");
        public void Create()
        {
            mayak = 1;
            mayak2 = 0;
            Console.Clear();
            Console.WriteLine("Добро пожаловать Склад мэнеджер");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("  ID:");
            Console.WriteLine("  Название:");
            Console.WriteLine("  Цена за штуку:");
            Console.WriteLine("  Кол-во на складе:");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S  - Сохранить запись");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в меню");
            int a = Arrows(3, 2);
            while (true)
            {
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
                    Console.SetCursorPosition(16, a);
                    Price = Convert.ToSingle(Console.ReadLine());
                }
                if (a == 5)
                {
                    Console.SetCursorPosition(19, a);
                    Count = Convert.ToInt32(Console.ReadLine());
                }
                Console.SetCursorPosition(0, a);
                Console.WriteLine("  ");
                a = Arrows(3, 2);

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
            List<Products> read = Myconv.MyDeserialize<List<Products>>("Продукты.json");
            if(read ==  null)
            {
                 a = 0;
                Console.WriteLine("Вход в панель Склада");
                Console.WriteLine("Имя  - Склад");//посмотреть мб просто передавать имя
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.SetCursorPosition(5, 3);
                Console.WriteLine("  ID");
                Console.SetCursorPosition(20, 3);
                Console.WriteLine("  Название");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("  Цена за штуку");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Кол-во на складе");
            }
            else
            {
                 a = read.Count;
                Console.WriteLine("Вход в панель Sklad");

                List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
                List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Имя  - Sklad");
                foreach (var item in dlyav)
                {
                    foreach (var item2 in dlyav2)
                    {
                        if (item2.ID == item.Account && item2.ROLE == 3)
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
                Console.SetCursorPosition(20, 3);
                Console.WriteLine("  Название");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("  Цена за штуку");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Кол-во на складе");
                foreach(var item in read)
                {

                    Console.SetCursorPosition(5, positiond);
                    Console.WriteLine("  " + item.ID);
                    Console.SetCursorPosition(20, positiond);
                    Console.WriteLine("  " + item.Name);
                    Console.SetCursorPosition(35, positiond);
                    Console.WriteLine("  " + item.Price);
                    Console.SetCursorPosition(52, positiond);
                    Console.WriteLine("  " + item.Count);
                    positiond++;
                }
            }
            
            //Console.WriteLine("Вход в панель бухгалтера");
            //Console.WriteLine("Имя  - Склад");//посмотреть мб просто передавать имя
            //Console.WriteLine("--------------------------------------------------------------------------");
            //Console.WriteLine("  ID" + "\t" + "Название" + "\t" + "Цена за штуку" + "\t" + "  Кол-во на складе");
            //foreach (Products member in read)
            //{
            //    Console.WriteLine("  " + member.ID + "\t" + member.Name + "\t" + member.Price + "\t" + member.Count);

            //}
            Console.SetCursorPosition(80, 2);
            Console.WriteLine("|Операции:-----------");
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("|F1 - Добавить запись");
            Console.SetCursorPosition(80, 4);
            Console.WriteLine("|F2 - Найти запись");
            Console.SetCursorPosition(80, 5);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");
            forprimer = Arrows(a + 1, 4);
            ReadOnly(forprimer,read);
            
        }

        public void Update()
        {
            if(mayak2 == 0)
            {
                List<Products> zapis = Myconv.MyDeserialize<List<Products>>("Продукты.json"); //данный лист нужен для перезаписи значений (запоминает старое и записывает новое)
                Products newproduct = new Products();
                newproduct.Price = (double)Price;
                newproduct.Name = Name;
                newproduct.Count = (int)Count;
                newproduct.ID = (int)ID;
                if(zapis == null)
                {
                    List<Products> newzapis = new List<Products>();
                    newzapis.Add(newproduct);
                    Myconv.Myserialize(newzapis, "Продукты.json");
                    Read();
                    Environment.Exit(0);
                }
                else
                {
                    zapis.Add(newproduct);
                    Myconv.Myserialize(zapis, "Продукты.json");
                    Read();
                    Environment.Exit(0);
                }
             
            }
            else
            {
                Myconv.Myserialize(zapis2, "Продукты.json");
                Read();
                Environment.Exit(0);
            }
          

           
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
                if (key.Key == ConsoleKey.F1)
                {
                    Create();
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.Escape  && mayak == 1)
                {
                    Read();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.Escape && mayak == 0)
                {
                    Program.Main();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.F2)
                {
                    Vibor();
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Update();
                    
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.Delete)
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
        public void ReadOnly(int forprimer, List<Products> polz)
        {
            mayak2 = 1;
            mayak = 1;
            Console.Clear();
            Products primer = new Products();
            primer = polz[forprimer - 4];
            Console.WriteLine("Дополнительная информация");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"  ID:{primer.ID}");
            Console.WriteLine($"  Наименование:{primer.Name}");                   //после нажатия Enter в первом меню показывает хар-ки которые можно поменять
            Console.WriteLine($"  Цена за штуку:{primer.Price}");
            Console.WriteLine($"  Кол-во на складе:{primer.Count}");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S - Сохранить изменения");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в  предыдущее меню");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("|Delete - Удалить позицию");
            ID = primer.ID;
            Name = primer.Name;
            Price = primer.Price;
            Count = primer.Count;
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
                        Console.SetCursorPosition(15, forchange);
                        Name = Convert.ToString(Console.ReadLine());
                        break;
                    case 4:
                        Console.SetCursorPosition(16, forchange);
                        Price = Convert.ToSingle(Console.ReadLine());
                        break;
                    case 5:
                        Console.SetCursorPosition(19, forchange);
                        Count = Convert.ToInt32(Console.ReadLine());
                        break;
                }
                foreach (var item in zapis2)
                {
                    if (item.Name == primer.Name)
                    {
                        item.Name = Name;
                        item.ID = (int)ID;
                        item.Price = (double)Price;
                        item.Count = (int)Count;
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
            Console.WriteLine("  Наименование:");
            Console.WriteLine("  Цена:");
            Console.WriteLine("  Кол-во на складе:");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");

            int a = Arrows(2, 1);
            if (a == 1)
            {
                Console.SetCursorPosition(5, a);
                searchID = Convert.ToInt32(Console.ReadLine());
            }
            if (a == 2)
            {
                Console.SetCursorPosition(15, a);
                searchName = Convert.ToString(Console.ReadLine());
            }
            if (a == 3)
            {
                Console.SetCursorPosition(7, a);
                searchPrice = Convert.ToSingle(Console.ReadLine());
            }
            if (a == 4)
            {
                Console.SetCursorPosition(19, a);
                searchCount = Convert.ToInt32(Console.ReadLine());
            }
            List<Products> polz = Myconv.MyDeserialize<List<Products>>("Продукты.json");
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
                            Console.WriteLine("  Наименование");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Цена за штуку");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Кол-во на складе");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Price);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Count);
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
                            Console.WriteLine("Поиск по LOGIN");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Наименование");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Цена за штуку");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Кол-во на складе");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Price);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Count);
                            p++;
                        }
                    }
                    break;
                case 3:
                    foreach (var item in polz)
                    {
                        if (searchPrice == item.Price)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по PASSWORD");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Наименование");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Цена за штуку");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Кол-во на складе");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Price);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Price);
                            p++;
                        }
                    }
                    break;
                case 4:
                    foreach (var item in polz)
                    {
                        if (searchCount == item.Count)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по ROLE");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Наименование");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Цена за штуку");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Кол-во на складе");

                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Price);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Count);
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
