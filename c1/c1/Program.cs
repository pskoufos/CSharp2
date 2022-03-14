namespace c1
{
    using System;
    using myTimer;
    using MyDatabases;

    class Program
    {
        internal static int exitCode=0 ; 
        static void Main(string[] args)
        {
          
            do
            {
                DrawMenu();        


            } while (exitCode==0);
            

        }//Main

        private static void Ct_TimeTick(object? sender, TimerEventsArgs e)
        {
            Console.WriteLine("Time tick {0} ...." , e.tick);
        }

        private static void Ct_TimeElapsed(object? sender, EventArgs e)
        {
            Console.WriteLine("Time elapsed ...."); 
        }


        private static void TimerExample() {
            Console.Clear();
            Console.WriteLine("Press a key to start timer");
            ConsoleKeyInfo k = Console.ReadKey(true);
            if (k.KeyChar == '1')
            {
                cMyTimer ct = new cMyTimer();
                ct.TimeElapsed += Ct_TimeElapsed;
                ct.TimeTick += Ct_TimeTick;
                ct.StartTimer(15);
            }
            Console.WriteLine("Wait .....");
            Console.ReadKey();

        }// timer example



        private static void DrawMenu()
        {
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     Main Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------");
            Console.WriteLine("\n");
            Console.WriteLine("1. Delegate Example.");
            Console.WriteLine("2. Timer Example.");
            Console.WriteLine("3. Database Reader Example.");
            Console.WriteLine("4. Database Export XML Example.");
            Console.WriteLine("5. Query Linq Array.");
            Console.WriteLine("9. Exit.");
            Console.Write("\nSelect :");
            ConsoleKeyInfo k = Console.ReadKey(true);

            switch (k.KeyChar) { 
                case '1':   
                    cDelegate c = new cDelegate();
                    c.showDelegate();
                    break;
                case '2':
                    TimerExample(); 
                    break;
                case '3':
                    cBikesDB db = new cBikesDB();
                    db.ShowTblStores();
                    break;
                case '4':
                    cBikesDB db2 = new cBikesDB();
                    db2.TabletoXml();
                    break;
                case '5':
                    Console.Clear();    
                    myLinq.queryStores();
                    Console.ReadKey(true);
                    break;

                case '9':
                    exitCode = 1;
                    break;
                }//key char 

        }//draw menu

    }//programm 


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