using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PRACAN10
{
    public class Kassir
    {
        int a = 0;
        ConsoleKeyInfo key;
        int mayak = 0;
        int newCount = 0;
        int mayak2 = 0;
        static List<Forkassa> list = new List<Forkassa>();
        List<int> forcount = new List<int>();
        List<Forkassa> newlist = Myconv.MyDeserialize<List<Forkassa>>("Продукты.json"); //данный лист нужен, чтобы понять максимальные и минимальные значения
        double AllPrice  = 0;
        private void Update()
        {

            int perem = 0;
            
            foreach(var item in list)
            {
                if (perem + 1  > forcount.Count)
                {

                }
                else
                {
                    item.Count = forcount[perem];
                }
               
               
               
                perem++;
            }

            int newperem = 0;

            foreach(var item in newlist)
            {
                try
                {
                    item.Count = item.Count - forcount[newperem];
                    
                }
                catch
                {
                    break;
                }
                finally
                {
                    newperem++;
                }
                



            }
            Otchet forfile = new Otchet();
            List<Otchet> forfile2 = new List<Otchet>();
            forfile.ID = 10;
            forfile.Sum = AllPrice;
            forfile.Quest = "да";
            forfile.Name = "Продажа товаров";
            forfile2 = Myconv.MyDeserialize<List<Otchet>>("Бабки.json");
            forfile2.Add(forfile);
            Myconv.Myserialize(forfile2, "Бабки.json");
            forfile2.Clear();
            forcount.Clear(); //очищение листа с количеством
            AllPrice = 0;
            Myconv.Myserialize(list, "Покупки.json");
            Myconv.Myserialize(newlist, "Продукты.json");
            newlist.Clear();
            list.Clear();
            Read();
            Environment.Exit(0);
        }
        public void Read()
        {
            Console.Clear();
            mayak = 0;
            if(mayak2 == 0)
            {
                list = Myconv.MyDeserialize<List<Forkassa>>("Продукты.json");

                foreach (var item in list)
                {
                    item.Count = 0;
                }
                Myconv.Myserialize(list, "Покупки.json");
            }
            else if(mayak2 == 1)
            {
                list = Myconv.MyDeserialize<List<Forkassa>>("Покупки.json");
            }
         
            
            
            int positiond = 4;
            if (list == null)
            {
                a = 0;
                Console.WriteLine("Вход в панель Kassir");

                List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
                List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Имя  - Kassir");
                foreach (var item in dlyav)
                {
                    foreach (var item2 in dlyav2)
                    {
                        if (item2.ID == item.Account && item2.ROLE == 4)
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
                Console.WriteLine("  Количество");
                Console.SetCursorPosition(0, a + 4);
                Console.WriteLine("------------------------------------------------------------");
                Console.SetCursorPosition(55, a + 5);
                Console.WriteLine("Итог:" + AllPrice);
            }
            else
            {
                a = list.Count;
                Console.WriteLine("Вход в панель Kassir");

                List<ForManager> dlyav = Myconv.MyDeserialize<List<ForManager>>("Привязка.json");
                List<Members> dlyav2 = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Имя  - Kassir");
                foreach (var item in dlyav)
                {
                    foreach (var item2 in dlyav2)
                    {
                        if (item2.ID == item.Account && item2.ROLE == 4)
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
                Console.WriteLine("  Количество:");
                int dlyaCount = 0; //нужна для перебора  моего листа с  новым количеством
                foreach (var item in list)
                {

                    Console.SetCursorPosition(5, positiond);
                    Console.WriteLine("  " + item.ID);
                    Console.SetCursorPosition(20, positiond);
                    Console.WriteLine("  " + item.Name);
                    Console.SetCursorPosition(35, positiond);
                    Console.WriteLine("  " + item.Price);
                    Console.SetCursorPosition(52, positiond);
                    try
                    {
                        Console.WriteLine("  " + forcount[dlyaCount]);
                    }
                    catch
                    {
                        Console.WriteLine("  " + "0");
                    }
                    Console.SetCursorPosition(55, a + 5);
                    Console.WriteLine("Итог:" + AllPrice);

                    positiond++;
                    dlyaCount++;
                }
            }
            Console.SetCursorPosition(80, 2);
            Console.WriteLine("|Операции:-----------");
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("|S - Завершить покупку");
            Console.SetCursorPosition(80, 4);
            Console.WriteLine("|Escape - Вернутсья в меню");
          
            int forprimer = Arrows(a + 1, 4);
            Vibor(forprimer);
           
        }

        public  void Vibor(int forprimer)
        {
            newlist = Myconv.MyDeserialize<List<Forkassa>>("Продукты.json");
            Console.Clear();
            mayak = 1;
            mayak2 = 1;//проверить должен ли быть 1
            newCount = 0;
            Forkassa kassa = new Forkassa();
            
         
            Console.WriteLine("Выбор товара");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("  ID:" + list[forprimer - 4].ID);
            Console.WriteLine("  Имя:" + list[forprimer - 4].Name);
            Console.WriteLine("  Цена за штуку:" + list[forprimer - 4].Price);
            Console.WriteLine("  Количество:");
            Console.SetCursorPosition(80, 2);
            Console.WriteLine("|Операции:-----------");
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("|+ - Добавить товар");
            Console.SetCursorPosition(80, 4);
            Console.WriteLine("|- - Убрать товар");
            Console.SetCursorPosition(80, 5);
            Console.WriteLine("|Escape - Вернуться в меню");


            key = Console.ReadKey(true);
            newCount = 0;
            while (true)
            {
                //Console.SetCursorPosition(20, 20);
                //Console.WriteLine(newlist[forprimer - 4].Count);

                if (key.Key == ConsoleKey.OemPlus)
                {
                    if (newCount + 1 > newlist[forprimer - 4].Count)
                    {
                        newCount--;
                        Console.SetCursorPosition(80, 6);

                        Console.WriteLine("Вы достигли максимального количества");
                    }
                    newCount++;
                    Console.SetCursorPosition(13, 5);
                    Console.WriteLine(newCount);
                }
                else if (key.Key == ConsoleKey.OemMinus)
                {
                    if (newCount - 1 < 0)
                    {
                        Console.SetCursorPosition(80, 6);

                        
                        Console.WriteLine("Ниже нуля быть не может");
                        newCount++;
                    }
                    newCount--;
                    Console.SetCursorPosition(13, 5);
                    Console.WriteLine(newCount);
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    AllPrice = AllPrice + (newCount * newlist[forprimer - 4].Price);
                    newlist[forprimer - 4].Count = newlist[forprimer - 4].Count - newCount;
                    forcount.Add(newCount);
                    Read();
                    Environment.Exit(0);
                }
                




                key = Console.ReadKey(true);
                Console.SetCursorPosition(80, 6);

                Console.WriteLine("                                      ");
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
                if (key.Key == ConsoleKey.Escape && mayak == 0)
                {
                    AllPrice = 0;
                    forcount.Clear(); //очищение листа с количеством
                    Program.Main();
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.Escape && mayak == 1)
                {

                    Read();
                    Environment.Exit(0);


                }
                if (key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Update();
                    Environment.Exit(0);
                }



                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

                key = Console.ReadKey();

            }



            return position;




        }
    }
}
