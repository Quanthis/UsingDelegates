using System;
using System.Threading;
using static System.Console;
using System.Numerics;

namespace UsingDelegates
{
    class Program
    {
        public delegate void ThreadMaker(object ob);
        public static void Silnia(int n)
        {
            BigInteger wynik = 1;
            for (BigInteger i = 1; i < 10000; i++)
            {
                wynik *= i;
            }
        }


        /*public delegate void Del(string s);
        public static void DelMethod(string s)
        {
            WriteLine(s);
        }*/



        public delegate void TDel(int number);
        public static void TMaker(int number)
        {
            Thread t1 = new Thread(() => Silnia(number));
        }

      

        static void Main(string[] args)
        {
            /*Del handler = DelMethod;
            handler("print sth");*/
            TDel del = TDel;
            TDel(10);

        }
    }
}
