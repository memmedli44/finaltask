using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project.Helpers
{
  public static partial class Helper
    {
        public static string ReadString(string caption, bool AllowIsNullOrEmpty = false)
        {
            string income;
            l1:

            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = oldcolor;
            income = Console.ReadLine();

            if (AllowIsNullOrEmpty = false || string.IsNullOrWhiteSpace(income)) 
            {
                goto l1;
            }
            return income;
        }
        public static int ReadInt(string caption, int min = 0, int max = 0)
        {
            string income;
        l1:

            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            if (min == max && max == 0)
            {
                Console.Write(caption);

            }
            else
            {
                Console.WriteLine($"{caption} [{min},{max}]");
            }
            Console.ForegroundColor = oldcolor;
            income = Console.ReadLine();

            if (!int.TryParse(income, out int value) || (min != 0 && max != 0 && (value < min && value > max)))
            {
                goto l1;
            }
            return value;
        }
        public static int ReadInteger(string caption, bool checkInterval=false,int minValue=0,int maxValue=2500)
        {
            int value;
            l1:
            Console.WriteLine(caption);
            if (!int.TryParse(Console.ReadLine(),out value))
            {
                goto l1;
            }
            if (!checkInterval && (value < minValue || value>maxValue))
            {
                Console.WriteLine( $"{value} bu intervalda deyil[{minValue},{maxValue}");
                goto l1;
            }
            return value;
        }

            public  static  decimal ReadDecimal (string caption, int min = 0, int max = 0)
            {
                string income;
            l2:

                ConsoleColor oldcolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                if (min == max && max == 0)
                {
                    Console.Write(caption);

                }
                else
                {
                    Console.WriteLine($"{caption} [{min},{max}]");
                }
                Console.ForegroundColor = oldcolor;
                income = Console.ReadLine();

                if (!decimal.TryParse(income, out decimal value) || (min != 0 && max != 0 && (value < min && value > max)))
                {
                    goto l2;
                }
                return value;

              }
        
    }
}
