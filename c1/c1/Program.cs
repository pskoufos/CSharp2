namespace c1
{
    using System; 

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

            Console.ReadKey();
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