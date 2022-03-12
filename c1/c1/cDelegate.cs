using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1
{
    public   class cDelegate
    {
        internal delegate void myMessage(string input);
        

        public void showDelegate ()
        {
            Console.Clear();
            Console.WriteLine("Delegate .....");
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


            action("\nPress a key to Return....");
            Console.ReadKey();



        }//showDelegate


    } //class 

}// namespace
