using Home_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project.Helpers
{
    public static partial class Helper
    {
        public static T ReadEnum<T>(string caption)
            where T : Enum
        {
            var menus = Enum.GetValues(typeof(T));

            foreach (var item in menus)
            {
              
                Type utype=Enum.GetUnderlyingType(typeof(T));
                var id=Convert.ChangeType(item, utype);
                Console.WriteLine($"{id.ToString().PadLeft(2, '0')}:{item}");
            }
        l1:

            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = oldcolor;
            string income = Console.ReadLine();
            if (!Enum.TryParse(typeof(T), income, out object value)|| !Enum.IsDefined(typeof(T),value))
            {
                goto l1;
            }
            return (T)value;
        }
      
        
    }
}
