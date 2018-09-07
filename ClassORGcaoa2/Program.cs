using System;
using System.Collections.Generic;
using System.IO;

namespace ClassORGcaoa2
{
    class Program
    {
        static void Main(string[] args)
        {
            //********************************************************
            //Now i need to ask whether it is a NEW user or OLD user 
            //If New, do NORMAL but CREATE NEW TEXT FILES FOR USER
            //If OLD, get text files, and add info to Lists

            MoreMethds.UserStatus();

            Directory.SetCurrentDirectory(@"C:\Users\andre\source\repos\ClassORGcaoa2");

            //.................NEW..................

            //......................................

            //*********************************************************



            var myOptions = new[] { "(1):Add new Class", "(2):Add new Task", "(3):See ALL my Classes",
                                    "(4)See All my tasks", "(5) See my tasks for a specific Class",
                                     "(6)Show a class' Info", "(7)Show my Class Schedule", "(8)Mark Assigment as Complete",
                                        "(X)Exit  " };


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
                if (userIN == "8")
                {
                    Console.Clear();
                    Collector.ChangeStatus();
                }

                    ToTextFile();
                

                Console.WriteLine(" ");
                
            }

        }
        //##############SAVE TO TEXT FILE######################

        public static void ToTextFile()
        {
            var listC = new List<string>();
            var listT = new List<string>();
            for (int i = 0; i < Collector.myClasses.Count; i++)
            {
                listC.Add(Collector.myClasses[i].ClassID.ToString() + "|"+ Collector.myClasses[i].ClassName.ToString() + "|" +
                    Collector.myClasses[i].Teacher.ToString() + "|" + Collector.myClasses[i].TimeS.ToString() + "|" +
                    Collector.myClasses[i].Days.ToString() + "|" + Collector.myClasses[i].Room.ToString() + "\n" );
            }
            for (int i = 0; i < Collector.myTasks.Count; i++)
            {
                listT.Add(Collector.myTasks[i].TaskName.ToString() + "|"+ Collector.myTasks[i].ForClass.ToString() + "|" 
                    + Collector.myTasks[i].DateAssigned.ToString() + "|" + Collector.myTasks[i].DateDue.ToString() + "|" +
                    Collector.myTasks[i].CompStatus.ToString() + "\n" );

            }

                System.IO.File.WriteAllLines(MoreMethds.DirCList[0]+"\\Classes.txt", listC);
            System.IO.File.WriteAllLines(MoreMethds.DirCList[0]+"\\Assigns.txt", listT);


        }
    }
}
