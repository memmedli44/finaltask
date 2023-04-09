using Home_Project.DataModel;
using Home_Project.Infrastuctur;
using Home_Project.Meneger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project.Helpers
{
    [Serializable]
    
   public class DataBase
    {
        
        public AuthorMeneger  Yazar { get; set; }
        public BookMeneger  kitab { get; set; }
    }
}
