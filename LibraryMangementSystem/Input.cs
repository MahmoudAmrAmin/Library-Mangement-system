using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementSystem
{
    public  class Input
    {


        public static int ReadInt ()
        {
            string ? input = Console.ReadLine ();
            int res; 
            return int.TryParse(input, out res) ? res : 0 ;

        }

        public static decimal ReadDecimal()
        {
            string? input = Console.ReadLine();
            decimal res;
            return decimal.TryParse(input, out res) ? res : 0.0m;

        }


        public static double  ReadDouble()
        {
            string? input = Console.ReadLine();
            double res;
            return double.TryParse(input, out res) ? res : 0.0;

        }
    }
}
