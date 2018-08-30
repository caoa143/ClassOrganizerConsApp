using System;

namespace ClassORGcaoa2
{
    class Program
    {
        static void Main(string[] args)
        {

            var myOptions = new[] { "(1):Add new Class", "(2):Add new Task", "(3):See ALL my Classes",
                                    "(4)See All my tasks", "(5) See my tasks for a specific Class",
                                     "(6)Show a class' Info", "(7)Show my Class Schedule", "(X)Exit  " };


            string userIN = "";
           

            while (userIN != "X")
            {
                Console.WriteLine(" ");


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(String.Join(Environment.NewLine, myOptions));
                userIN = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;



                if (userIN == "1")
                {
                    Console.Clear();
                    Collector.CreateNewClass();
                }


                if (userIN == "2")
                {
                    Console.Clear();
                    Collector.AddTask();
                }

                if (userIN == "3")
                {
                    Console.Clear();
                    Collector.ShowALLclasses();
                }

                if (userIN == "4")
                {
                    Console.Clear();
                    Collector.ShowAllTasks();
                }

                if (userIN == "5")
                {
                    Console.Clear();
                    Console.WriteLine("What class would you like to see?");
                    string classT = Console.ReadLine();
                    Collector.ShowClassTask(classT);
                }

                if (userIN == "6")
                {
                    Console.Clear();
                    Console.WriteLine("What class' Info would you like to see?");
                    string classI = Console.ReadLine();
                    Collector.ShowAClass(classI);
                }
                if (userIN == "7")
                {
                    Console.Clear();
                    //Console.WriteLine("YOUR CLASS SCHEDULE");
                    Console.WriteLine("-------------------------");
                    Collector.ShowSchedule();
                }
                Console.WriteLine(" ");

            }

        }
    }
}
