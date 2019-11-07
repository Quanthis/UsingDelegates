using System;
using System.Threading;
using static System.Console;
using System.Numerics;
using System.Diagnostics;

namespace UsingDelegates
{
    class Program
    {
        /*void Method(Thread t)
        {
            Thread t1 = new Thread(() => t);
        }*/

        public delegate void ThreadMaker(int n);

        public static void Silnia(int n)
        {
            BigInteger wynik = 1;
            for (BigInteger i = 1; i < n; i++)
            {
                wynik *= i;
            }
            WriteLine("Już");
        }




        /*public delegate void Del(string s);
        public static void DelMethod(string s)
        {
            WriteLine(s);
        }*/

        static void Main(string[] args)
        {
            /*Del handler = DelMethod;
            handler("print sth");*/

            Stopwatch z1 = new Stopwatch();
            Stopwatch z2 = new Stopwatch();
            Stopwatch z3 = new Stopwatch();
            Stopwatch z4 = new Stopwatch();
            
            ThreadMaker s1 = Silnia;

            Thread t1 = new Thread(() =>
            {
                Silnia(100000);
            });
            
            Thread t2 = new Thread(() =>
            {
                s1(100000);   
            });



            WriteLine("z1 startuje");
            z1.Start();
            t1.Start();
            
            WriteLine("z2 startuje");
            z2.Start();
            t2.Start();

            t1.Join();
            z1.Stop();
            WriteLine("Bez delegata wyliczono w: " + z1.Elapsed);

            t2.Join();
            z2.Stop();
            WriteLine("Z delegatem wyliczono w: " + z2.Elapsed);

            WriteLine("z3 startuje");
            z3.Start();
            Silnia(100000);
            WriteLine("z3: " + z3.Elapsed);

            WriteLine("z4 startuje");                   //+delegat
            z4.Start();
            s1(100000);
            WriteLine("z4: " + z4.Elapsed);

            ReadKey();
        }
    }
}
