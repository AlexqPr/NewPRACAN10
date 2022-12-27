using System.Security.Cryptography;

namespace PRACAN10
    

{ //пофиксить отображение пароля
    public class Program
    {
        
        public static void Main()
        {
            Console.Clear();
            
           
          
            arrow strlk = new arrow();
            Avtor menu = new Avtor();
            string login = "";
            string password = "";
            string newa = "";
            List<char> newpassword = new List<char>();            //тут строчки идут для авторизации и замены пароля звездочками
            ConsoleKeyInfo parol;
            menu.Verify(login,password);
            int a = strlk.ARROW();
            while(a != 4)
            {
                newpassword.Clear();
                if (a == 2)
                {
                    Console.SetCursorPosition(8, a);
                    login = Convert.ToString(Console.ReadLine());
                }
                else if  (a == 3)
                {
                    Console.SetCursorPosition(9, a);
                    ConsoleKeyInfo newkey = Console.ReadKey(true);
                    while(newkey.Key != ConsoleKey.Enter)
                    {
                        Console.Write("*");
                        newpassword.Add(newkey.KeyChar);
                        newkey = Console.ReadKey(true);

                        
                        newa = "";
                        foreach (char s in newpassword)
                        {
                            newa = newa + s;                  //newa  = переменная, в которой хранится пароль
                        }
                        
                        
                    }
                    
                    
                }
                Console.Clear();
                menu.Verify(login, newa);
                a = strlk.ARROW();

                
            }



            List<Members> dlyaavt = Myconv.MyDeserialize<List<Members>>("Пользователи.json");
         
           
                foreach (var item in dlyaavt)
                {
                    if (login == item.LOGIN)
                    {
                        if (newa == item.PASSWORD)
                        {
                            switch (item.ROLE)
                            {
                                case 1:
                                    Admin per1 = new Admin();
                                    per1.Read();
                                    break;
                                case 2:
                                    Manager per2 = new Manager();
                                    per2.Read();

                                    break;
                                case 3:
                                    Sklad per3 = new Sklad();
                                    per3.Read();

                                    break;
                                case 4:
                                    Kassir per4 = new Kassir();
                                    per4.Read();

                                    break;
                                case 5:
                                    Buhg per5 = new Buhg();
                                    per5.Read();
                                    break;
                            }
                        }
                    }
                    

                }
            Console.WriteLine("Вы ввели неверные данные");
            Thread.Sleep(1000);
            Main();
                
            
            
            

            
            
                





        }
    }
}