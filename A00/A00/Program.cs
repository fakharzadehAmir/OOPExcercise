using System;

namespace A00
{
    public class Program
    {
        public static  bool IsGreater(int a , int b )
        {
            if (a>b)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsGreater(15,5));
        }
    }
}