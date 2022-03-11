namespace c1
{
    using System;
    using myTimer;

    public delegate void myMessage(string input);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi i am live....");
            Console.ReadKey();

            myMessage my = classA.displayA;
            my("hi there ...");

            my = classb.displayB;
            my("hi there ...");

            my = (string s) => Console.WriteLine("Lamda expresion  " + s);
            my("hi there ....");


            Action<string> action = (string s) => Console.WriteLine("action expresion  " + s);

            action("hi there...."); 

            Console.ReadKey();

            Console.WriteLine("Press  to start timer");
            ConsoleKeyInfo k = Console.ReadKey(true);

            if (k.KeyChar =='1')
            {
                cMyTimer ct = new cMyTimer();
                ct.TimeElapsed += Ct_TimeElapsed;
                ct.TimeTick += Ct_TimeTick;
                ct.StartTimer(15);
            }
            Console.WriteLine("Wait .....");
            Console.ReadKey();
        }

        private static void Ct_TimeTick(object? sender, TimerEventsArgs e)
        {
            Console.WriteLine("Time tick {0} ...." , e.tick);
        }

        private static void Ct_TimeElapsed(object? sender, EventArgs e)
        {
            Console.WriteLine("Time elapsed ...."); 
        }
    }


    public class classA
    {
        public static void displayA(string message){
            Console.WriteLine("classA --> {0}", message);

        }
        
        
    }

    public class classb
    {
        public static void displayB(string message)
        {
            Console.WriteLine("classB --> {0}", message);

        }


    }



}// namespace 