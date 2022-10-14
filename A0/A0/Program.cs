using System;

namespace A0
{
    public class Program
    {
        public static  int Max(int a , int b )
        {
            if (a>b)
                return a;
            return b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Max(5,15));
        }
    }
}