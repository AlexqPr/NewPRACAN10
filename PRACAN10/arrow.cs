using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACAN10
{
    public class arrow
    {
        public int ARROW()
        {
            int position = 2;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");

            ConsoleKeyInfo key = Console.ReadKey();
            while(key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;
                    Console.SetCursorPosition(0, position + 1);
                    Console.WriteLine("  ");



                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                   
                    position++;
                    Console.SetCursorPosition(0, position - 1);
                    Console.WriteLine("  ");


                }
                if (position > 4)
                {
                    position--;
                    Console.SetCursorPosition(0, position);
                }
                if (position < 2)
                {
                    position++;
                    Console.SetCursorPosition(0, position);
                }
                if(key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("ДДо скорой встречи");
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
