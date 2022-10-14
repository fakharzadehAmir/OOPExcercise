using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static int GetObjectType(object o)
        {
            if (o is string){return 0;}
            if (o is int){return 2;}
            else{return 1;}
        }

        public static bool IdealHusband(FutureHusbandType fht)
        {
            if((int)fht == 3 || (int)fht == 5 || (int)fht == 6) return true;
            else return false;

        }
    }
    
}
