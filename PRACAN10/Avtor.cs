using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACAN10
{
    internal class Avtor
    {
        public void Verify(string login, string parol)
        {
            int a = Console.WindowHeight ;
            Console.SetCursorPosition(a, 0);
            Console.WriteLine("Добро пожаловать в магазин");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("  Логин:" + login);
            Console.WriteLine("  Пароль:" + parol);
            Console.WriteLine("  Авторизоваться");
          
        }
    }
}
