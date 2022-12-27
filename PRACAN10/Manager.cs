using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRACAN10
{
    
    public class Manager : ICrud
    {
        int? ID = null;
        int searchID;
        string searchSecondname;
        string searchName;
        string searchPatronymic;
        DateTime searchDate;
        int searchSeires;
        int searchRole;
        double searchZP;
        int searchAccount;
        string Secondname;
        string Name;
        string Patronymic;
        DateTime Data;
        int? Series = null;
        int? Role = null;
        double ZP;
        int? Account = null;
        string logino;
        int a = 0;
        int forprimer;
        int mayak = 0;
        int mayak2 = 0;
        static List<ForManager> zapis2 = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
        ConsoleKeyInfo key;
        public void Create()
        {
            mayak = 1;
            mayak2 = 0;
            Console.Clear();
            Console.WriteLine("Добро пожаловать Мэнэджер");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("  ID:");
            Console.WriteLine("  Фамилия:");
            Console.WriteLine("  Имя:");
            Console.WriteLine("  Отчество:");
            Console.WriteLine("  День рождения:");
            Console.WriteLine("  Серия и номер паспорта:");
            Console.WriteLine("  Должность:");
            Console.WriteLine("  Зарплата:");
            Console.WriteLine("  Аккаунт сотрудника:");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S  - Сохранить запись");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в меню");

            int a = Arrows(8, 2);
            while (true)
            {
                if (a == 2)
                {
                    Console.SetCursorPosition(5, a);
                    ID = Convert.ToInt32(Console.ReadLine());
                }
                if (a == 3)
                {
                    Console.SetCursorPosition(10, a);
                    Secondname = Convert.ToString(Console.ReadLine());
                }
                if (a == 4)
                {
                    Console.SetCursorPosition(6, a);
                    Name = Convert.ToString(Console.ReadLine());
                }
                if (a == 5)
                {
                    Console.SetCursorPosition(11, a);
                    Patronymic = Convert.ToString(Console.ReadLine());
                }
                if (a == 6)
                {
                    Console.SetCursorPosition(16, a);
                    Data = Convert.ToDateTime(Console.ReadLine());
                }
                if (a == 7)
                {
                    Console.SetCursorPosition(25, a);
                    Series = Convert.ToInt32(Console.ReadLine());
                }
                if (a == 8)
                {
                    Console.SetCursorPosition(12, a);
                    Role = Convert.ToInt32(Console.ReadLine());
                }
                if (a == 9)
                {
                    Console.SetCursorPosition(11, a);
                    ZP = Convert.ToDouble(Console.ReadLine());
                }
                if (a == 10)
                {
                    Console.SetCursorPosition(21, a);
                    Account = Convert.ToInt32(Console.ReadLine());
                }
                Console.SetCursorPosition(0, a);
                Console.WriteLine("  ");
                a = Arrows(8, 2);

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
            Console.Clear();
            int positiond = 4;
            List<ForManager> read = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
            
            if (read == null)
            {
                a = 0;
                Console.WriteLine("Вход в панель Manager");

                List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
                List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Имя  - Manager");
                foreach (var item in dlyav)
                {
                    foreach (var item2 in dlyav2)
                    {
                        if (item2.ID == item.Account && item2.ROLE == 2)
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
                Console.WriteLine("  Фамилия");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("  Имя");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Отчество");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Должность");
                
            }
            else
            {
               
                a = read.Count;
                Console.WriteLine("Вход в панель Manager");

                List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
                List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Имя  - Manager");
                foreach (var item in dlyav)
                {
                    foreach (var item2 in dlyav2)
                    {
                        if (item2.ID == item.Account && item2.ROLE == 2)
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
                Console.WriteLine("  Фамилия");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("  Имя");
                Console.SetCursorPosition(50, 3);
                Console.WriteLine("  Отчество");
                Console.SetCursorPosition(65, 3);
                Console.WriteLine("  Должность");
                foreach (var item in read)
                {

                    Console.SetCursorPosition(5, positiond);
                    Console.WriteLine("  " + item.ID);
                    Console.SetCursorPosition(20, positiond);
                    Console.WriteLine("  " + item.Name);
                    Console.SetCursorPosition(35, positiond);
                    Console.WriteLine("  " + item.Secondname);
                    Console.SetCursorPosition(52, positiond);
                    Console.WriteLine("  " + item.Patronymic);
                    Console.SetCursorPosition(65, positiond);
                    Console.WriteLine("  " + item.Role);
                    positiond++;
                }
            }
            Console.SetCursorPosition(80, 2);
            Console.WriteLine("|Операции:-----------");
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("|F1 - Добавить запись");
            Console.SetCursorPosition(80, 4);
            Console.WriteLine("|F2 - Найти запись");
            Console.SetCursorPosition(80, 5);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");
            forprimer = Arrows(a + 1, 4);
            ReadOnly(forprimer, read);





        }

        public void Update()
        {
            if(mayak2 == 0)
            {
                List<ForManager> zapis = Myconv.MyDeserialize<List<ForManager>>("Привязка.json"); //данный лист нужен для перезаписи значений (запоминает старое и записывает новое)
                ForManager newproduct = new ForManager();
                newproduct.Name = Name;
                newproduct.ID = (int)ID;
                newproduct.Patronymic = Patronymic;
                newproduct.Data = Data;
                newproduct.ZP = ZP;
                newproduct.Account = (int)Account;
                newproduct.Secondname = Secondname;
                newproduct.Role = (int)Role;
                newproduct.Series = (int)Series;
                if (zapis == null)
                {
                    List<ForManager> newzapis = new List<ForManager>();
                    newzapis.Add(newproduct);
                    Myconv.Myserialize(newzapis, "Привязка.json");
                    Read();
                    Environment.Exit(0);
                }
                else
                {
                    zapis.Add(newproduct);
                    Myconv.Myserialize(zapis, "Привязка.json");
                    Read();
                    Environment.Exit(0);
                }
            }
            else
            {
                Myconv.Myserialize(zapis2, "Привязка.json");
                Read();
                Environment.Exit(0);
                mayak2 = 0;
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
                if (key.Key == ConsoleKey.Escape && mayak == 1)
                {
                    Read();
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.Escape && mayak == 0)
                {
                    Program.Main();
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.S)
                {
                    Update();
                   
                    Read();
                    Environment.Exit(0);
                }
                if(key.Key  == ConsoleKey.Delete)
                {
                    Delete();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.F2)
                {
                    Vibor();
                    Environment.Exit(0);
                }




                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

                key = Console.ReadKey();
            }

            return position;



        }
        private void ReadOnly(int forprimer,List<ForManager> polz)
        {
            mayak = 1;
            mayak2 = 1;
            Console.Clear();
            ForManager primer = new ForManager();
            primer = polz[forprimer - 4];
            Console.WriteLine("Дополнительная информация");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"  ID:{primer.ID}");
            Console.WriteLine($"  Имя:{primer.Name}");                   //после нажатия Enter в первом меню показывает хар-ки которые можно поменять
            Console.WriteLine($"  Фамилия:{primer.Secondname}");
            Console.WriteLine($"  Отчество:{primer.Patronymic}");
            Console.WriteLine($"  День рождения:{primer.Data}");
            Console.WriteLine($"  Серия и номер паспорта:{primer.Series}");
            Console.WriteLine($"  Должность:{primer.Role}");
            Console.WriteLine($"  Зарплата:{primer.ZP}");
            Console.WriteLine($"  Аккаунт сотрудника:{primer.Account}");


            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S - Сохранить изменения");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в  предыдущее меню");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("|Delete - Удалить данные");
            ID = primer.ID;
            Name = primer.Name;
            Secondname = primer.Secondname;
            Patronymic = primer.Patronymic;
            Data = primer.Data;
            Series = primer.Series;
            Role = primer.Role;
            ZP = primer.ZP;
            Account = primer.Account;

            int forchange = Arrows(8, 2);
            while (true)
            {
                switch (forchange)
                {
                    case 2:
                        Console.SetCursorPosition(5, forchange);
                        ID = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.SetCursorPosition(6, forchange);
                        Name = Convert.ToString(Console.ReadLine());
                        break;
                    case 4:
                        Console.SetCursorPosition(10, forchange);
                        Secondname = Convert.ToString(Console.ReadLine());
                        break;
                    case 5:
                        Console.SetCursorPosition(11, forchange);
                        Patronymic = Convert.ToString(Console.ReadLine());
                        break;
                    case 6:
                        Console.SetCursorPosition(15, forchange);
                        Data = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case 7:
                        Console.SetCursorPosition(25, forchange);
                        Series = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 8:
                        Console.SetCursorPosition(12, forchange);
                        Role = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 9:
                        Console.SetCursorPosition(11, forchange);
                        ZP = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 10:
                        Console.SetCursorPosition(21, forchange);
                        Account = Convert.ToInt32(Console.ReadLine());
                        break;

                }
                foreach (var item in zapis2)
                {
                    if (item.Name == primer.Name)
                    {
                        item.Name = Name;
                        item.ID = (int)ID;
                        item.Secondname = Secondname;
                        item.Patronymic = Patronymic;
                        item.Data = Data;
                        item.Series = (int)Series;
                        item.ZP = (double)ZP;
                        item.Role = (int)Role;
                        item.Account = (int)Account;
                    }

                }
                forchange = Arrows(8, 2);
            }
        }
        private void Vibor()
        {
            mayak = 1;

            Console.Clear();
            Console.WriteLine("Найти по:");
            Console.WriteLine("  ID:");
            Console.WriteLine("  Фамилия:");
            Console.WriteLine("  Имя:");
            Console.WriteLine("  Отчество:");
            Console.WriteLine("  День рождения:");
            Console.WriteLine("  Серия и номер паспорта:");
            Console.WriteLine("  Должность:");
            Console.WriteLine("  Зарплата:");
            Console.WriteLine("  Аккаунт  сотрудника:");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");

            int a = Arrows(7, 1);
            if (a == 1)
            {
                Console.SetCursorPosition(5, a);
                searchID = Convert.ToInt32(Console.ReadLine());
            }
            if (a == 2)
            {
                Console.SetCursorPosition(15, a);
                searchSecondname = Convert.ToString(Console.ReadLine());
            }
            if (a == 3)
            {
                Console.SetCursorPosition(7, a);
                searchName = Convert.ToString(Console.ReadLine());
            }
            if (a == 4)
            {
                Console.SetCursorPosition(19, a);
                searchPatronymic = Convert.ToString(Console.ReadLine());
            }
            if (a == 5)
            {
                Console.SetCursorPosition(19, a);
                searchDate = Convert.ToDateTime(Console.ReadLine());
            }
            if (a == 6)
            {
                Console.SetCursorPosition(19, a);
                searchSeires = Convert.ToInt32(Console.ReadLine());
            }
            if (a == 7)
            {
                Console.SetCursorPosition(19, a);
                searchRole = Convert.ToInt32(Console.ReadLine());
            }
            if (a == 8)
            {
                Console.SetCursorPosition(19, a);
                searchZP = Convert.ToDouble(Console.ReadLine());
            }
            if (a == 9)
            {
                Console.SetCursorPosition(19, a);
                searchAccount = Convert.ToInt32(Console.ReadLine());
            }
            List<ForManager> polz = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
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
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 2:
                    foreach (var item in polz)
                    {
                        if (searchSecondname == item.Secondname)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Secondname");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 3:
                    foreach (var item in polz)
                    {
                        if (searchName == item.Name)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Name");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 4:
                    foreach (var item in polz)
                    {
                        if (searchPatronymic == item.Patronymic)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Patronymic");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 5:
                    foreach (var item in polz)
                    {
                        if (searchDate == item.Data)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Date");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 6:
                    foreach (var item in polz)
                    {
                        if (searchSeires == item.Series)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Series");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 7:
                    foreach (var item in polz)
                    {
                        if (searchRole == item.Role)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Role");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                    
                case 8:
                    foreach (var item in polz)
                    {
                        if (searchZP == item.ZP)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по ZP");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
                            p++;
                        }
                    }
                    break;
                case 9:
                    foreach (var item in polz)
                    {
                        if (searchAccount == item.Account)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по Account");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Фамилия");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Имя");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Должность");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.Secondname);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.Name);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.Role);
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
