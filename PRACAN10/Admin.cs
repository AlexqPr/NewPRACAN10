using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACAN10
{
    internal class Admin : ICrud
    {
        int? ID = null;
        string lg = "";
        string prl = "";
        int? role = null;
        int? searchID = null;
        string searchLOGIN = "";
        string searchPASSWORD = "";
        int? searchROLE = null;
        ConsoleKeyInfo key;
        int mayak = 0;
        int mayak2 = 0;
        int forprimer;
        static List<Members> zapis2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");

        public void Create()
        {
            mayak = 0;
            mayak2 = 0;
            Console.Clear();
            
            Console.Clear();
            Console.WriteLine("Добро пожаловать admin");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("  ID:" );
            Console.WriteLine("  Логин:");
            Console.WriteLine("  Пароль:"  );
            Console.WriteLine("  Роль:"  );
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("|Роли:");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("|1 - Администратор");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("|2 - Менеджер персонала");
            Console.SetCursorPosition(50, 4);
            Console.WriteLine("|3 - Склад менеджер");
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("|4 - Кассир");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("|5 - Бухгалтер");
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("|Чтобы сохранить роль нажмите S");
            Console.SetCursorPosition(50, 8);
            Console.WriteLine("|Чтобы вернуться в предыдущюу менюшку нажмите Backspace");

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
                    Console.SetCursorPosition(8, a);
                    lg = Convert.ToString(Console.ReadLine());
                }
                if (a == 4)
                {
                    Console.SetCursorPosition(9, a);
                    prl = Convert.ToString(Console.ReadLine());
                }
                if (a == 5)
                {
                    Console.SetCursorPosition(7, a);
                    role = Convert.ToInt32(Console.ReadLine());
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
            mayak = 1;
            Console.Clear();
            int positiond = 4;
            List<Members> polz = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
            
            Console.WriteLine("Вход в панель Admin");
           
            List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
            List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Имя  - Admin");
            foreach (var item in dlyav)
            {
                foreach (var item2 in dlyav2)
                {
                    if (item2.ID == item.Account &&  item2.ROLE == 1)
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
            Console.WriteLine("  Логин");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("  Пароль");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("  Роль");
            //Console.WriteLine("  ID" + "\t" + "Логин" + "\t" + "Пароль" + "\t" + "  Роль");
            foreach (Members member in polz)
            {
                Console.SetCursorPosition(5, positiond);
                Console.WriteLine("  " + member.ID);
                Console.SetCursorPosition(20, positiond);
                Console.WriteLine("  " + member.LOGIN);
                Console.SetCursorPosition(35, positiond);
                Console.WriteLine("  " + member.PASSWORD);
                Console.SetCursorPosition(52, positiond);
                Console.WriteLine("  " + member.ROLE);
                /*Console.WriteLine("  " + member.ID +  "\t" + member.LOGIN + "\t" + member.PASSWORD + "   " + member.ROLE);*/
                positiond++;
            }
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|F1 - Добавить запись");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("|F2 - Найти запись");

            int a = polz.Count;


           
            forprimer = Arrows(a + 1,4);
            mayak = 0;
            ReadOnly(forprimer,polz);
            

        }

        public void Update()
        {
            
            if(mayak2 == 1)
            {
                
                Myconv.Myserialize(zapis2, "Пользователи.json");
                Read();
                Environment.Exit(0);

            }
            else
            {
                List<Members> zapis = Myconv.MyDeserialize<List<Members>>("Пользователи.json"); //данный лист нужен для перезаписи значений (запоминает старое и записывает новое)
                Members newperson = new Members();
                newperson.LOGIN = lg;
                newperson.PASSWORD = prl;
                newperson.ROLE = (int)role;
                newperson.ID = (int)ID;

                zapis.Add(newperson);
                Myconv.Myserialize(zapis, "Пользователи.json");
                Read();
                Environment.Exit(0);
            }
            mayak2 = 0;


        }
        public int Arrows(int max,int min)
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
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                    Console.SetCursorPosition(0, position - 1);
                    Console.WriteLine("  ");
                }
                if ((position-2) > max)
                {
                    position--;
                }
                if(position < min)
                {
                    position++;
                }
              
                if (key.Key == ConsoleKey.F1)
                {
                   
                    Create();
                    Environment.Exit(0);
                   

                }
                //if(key.Key == ConsoleKey.Backspace)
                //{
                //    Read();
                //    Environment.Exit(0);
                //}
                if (key.Key == ConsoleKey.Escape && mayak == 1)
                {
                    Program.Main();
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.Escape && mayak == 0)
                {
                    
                    Read();
                    Environment.Exit(0);
                    
                   
                }
                if(key.Key == ConsoleKey.F2)
                {
                    Viobr();
                    Environment.Exit(0);
                }
                if(key.Key == ConsoleKey.S)
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
        public void Viobr()
        {
            mayak = 0;
            Console.Clear();
            Console.WriteLine("Найти по:");
            Console.WriteLine("  ID:");
            Console.WriteLine("  LOGIN:");
            Console.WriteLine("  PASSWORD:");
            Console.WriteLine("  ROLE:");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в предыдущее меню");
            
            int a  = Arrows(2, 1);
            if(a == 1)
            {
                Console.SetCursorPosition(5, a);
                 searchID = Convert.ToInt32(Console.ReadLine());
            }
            if(a == 2)
            {
                Console.SetCursorPosition(8, a);
                 searchLOGIN = Convert.ToString(Console.ReadLine());
            }
            if(a == 3)
            {
                Console.SetCursorPosition(11, a);
                 searchPASSWORD = Convert.ToString(Console.ReadLine());
            }
            if(a == 4)
            {
                Console.SetCursorPosition(7, a);
                 searchROLE = Convert.ToInt32(Console.ReadLine());
            }
            List<Members> polz = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
            int p = 3;
            switch (a)
            {
                case 1:
                    
                    foreach (var item in polz)
                    {
                        
                        if(searchID == item.ID)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по ID");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Логин");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Пароль");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Роль");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.LOGIN);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.PASSWORD);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.ROLE);
                            p++;
                        }
                    }
                    break;
                case 2:
                    foreach(var item in polz)
                    {
                        if(searchLOGIN == item.LOGIN)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по LOGIN");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Логин");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Пароль");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Роль");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.LOGIN);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.PASSWORD);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.ROLE);
                            p++;
                        }
                    }
                    break;
                case 3:
                    foreach(var item in polz)
                    {
                        if(searchPASSWORD == item.PASSWORD)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по PASSWORD");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Логин");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Пароль");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Роль");
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.LOGIN);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.PASSWORD);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.ROLE);
                            p++;
                        }
                    }
                    break;
                case 4:
                    foreach(var item in polz)
                    {
                        if(searchROLE == item.ROLE)
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по ROLE");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.SetCursorPosition(5, 2);
                            Console.WriteLine("  ID");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("  Логин");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("  Пароль");
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("  Роль");
                           
                            Console.SetCursorPosition(5, p);
                            Console.WriteLine("  " + item.ID);
                            Console.SetCursorPosition(20, p);
                            Console.WriteLine("  " + item.LOGIN);
                            Console.SetCursorPosition(35, p);
                            Console.WriteLine("  " + item.PASSWORD);
                            Console.SetCursorPosition(52, p);
                            Console.WriteLine("  " + item.ROLE);
                            p++;
                        }
                    }
                    break;
            }
            key = Console.ReadKey();
            Console.WriteLine("Выйти из данной менюшки  - Escape");
            if(key.Key == ConsoleKey.Escape)
            {

                Read();
                Environment.Exit(0);

            }
           
          
        }
        public void ReadOnly(int forprimer,List<Members> polz)
        {
            mayak = 0;
            mayak2 = 1;
            Console.Clear();
            Members primer = new Members();
            primer = polz[forprimer - 4];
            Console.WriteLine("Дополнительная информация");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"  ID:{primer.ID}");
            Console.WriteLine($"  Логин:{primer.LOGIN}");                   //после нажатия Enter в первом менюпоказывает хар-ки которые можно поменять
            Console.WriteLine($"  Пароль:{primer.PASSWORD}");
            Console.WriteLine($"  Роль:{primer.ROLE}");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("|Операции:---------------------------");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("|S - Сохранить изменения");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("|Escape - Вернуться в  предыдущее меню");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("|Delete - Удалить пользователя");
            lg = primer.LOGIN;
            prl = primer.PASSWORD;
            ID = primer.ID;
            role = primer.ROLE;
            int forchange = Arrows(3, 2);
            while(true)
            {
                switch (forchange)
                {
                    case 2:
                        Console.SetCursorPosition(5, forchange);
                        ID = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.SetCursorPosition(8, forchange);
                        lg = Convert.ToString(Console.ReadLine());
                        break;
                    case 4:
                        Console.SetCursorPosition(9, forchange);
                        prl = Convert.ToString(Console.ReadLine());
                        break;
                    case 5:
                        Console.SetCursorPosition(7, forchange);
                        role = Convert.ToInt32(Console.ReadLine());
                        break;
                }
                foreach(var item in zapis2)
                {
                    if(item.LOGIN == primer.LOGIN)
                    {
                        item.LOGIN = lg;
                        item.ID = (int)ID;
                        item.PASSWORD = prl;
                        item.ROLE = (int)role;
                    }
                  
                }
                 forchange = Arrows(3, 2);
            }
          
           
           

        }
    }
}
