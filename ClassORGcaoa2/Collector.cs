using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Text;

namespace ClassORGcaoa2
{
    class Collector
    {
    
        //_______LISTS______

        public static List<Class> myClasses = new List<Class>();

        public static List<ToDo> myTasks = new List<ToDo>();

        //_________________
        //Create CLASSES
        public static void CreateNewClass()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Class newClass = new Class();
            Console.WriteLine("Enter the Class ID");
            newClass.ClassID = Console.ReadLine();

            Console.WriteLine("Enter the Class Name");
            newClass.ClassName = Console.ReadLine();

            Console.WriteLine("Enter the Class Teacher");
            newClass.Teacher = Console.ReadLine();

            Console.WriteLine("Enter the Class Room num");
            newClass.Room = Console.ReadLine();

            Console.WriteLine("Enter the Days the class is held (M,T,W,TH,F");
            newClass.Days = Console.ReadLine();

            Console.WriteLine("Enter the time the class starts (hh:mm tt)");
            newClass.TimeS = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newClass.ClassID+" "+newClass.ClassName+" has been added to your classes!");

            myClasses.Add(newClass);
            
        }
        
        //DISPLAY---------------------------------
        public static void ShowAClass(string inputC)
        {
            if (myClasses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("You Have no Classes in your Profile, Add them!");
            }

            foreach (Class item in myClasses)
            {
                if (inputC != item.ClassID||inputC != item.ClassName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This class does not exist in your list of classes. Add it!");
                }
                if (inputC == item.ClassID || inputC == item.ClassName)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(item.ClassID);
                    Console.WriteLine(item.ClassName);
                    Console.WriteLine("Room "+item.Room);
                    Console.WriteLine("Teacher "+item.Teacher);
                    Console.WriteLine(item.TimeS);
                    Console.WriteLine("Days: "+item.Days);

                }
                 
            }
            
        }
        public static void ShowALLclasses()
        {

            if (myClasses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("You Have no Classes in your Profile, Add them!");
            }
            foreach (Class item in myClasses)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(" Your Classes:");
                Console.WriteLine("__________________________________________");
                Console.WriteLine(item.ClassID);
                Console.WriteLine(item.ClassName);
                Console.WriteLine("Room " + item.Room);
                Console.WriteLine("Teacher " + item.Teacher);
                Console.WriteLine(item.TimeS);
                Console.WriteLine("Days: " + item.Days);
                Console.WriteLine(" ");
                Console.WriteLine("_____________________ ______________");

            }

        }

        //++++++++++++++++++++TASKS++++++++++++++++++++++

        public static void AddTask()
        {
           
                ToDo newTask = new ToDo();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Name your task");
                newTask.TaskName = Console.ReadLine();

                 Console.WriteLine("For what Class is this Assignment? (class ID)");
                 newTask.ForClass= Console.ReadLine();

            
                newTask.DateAssigned = DateTime.Now;

                Console.WriteLine("When is this Assignment due? (MM/DD/YYYY 00:00 #M");
                string dateDueSTR = Console.ReadLine();
                newTask.DateDue = DateTime.ParseExact(dateDueSTR, "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);

                newTask.CompStatus = false;

                myTasks.Add(newTask);

            Console.WriteLine("Your new task for "+newTask+ " has been Added!" );
            
        }

        public static void ShowAllTasks() {

            Console.WriteLine("Your Current List of ASSIGNMENTS:");
            Console.WriteLine("=============================================");

            if (myTasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have not added any assignments yet!");
            }

            foreach (ToDo thing in myTasks)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Class "+thing.ForClass);
                Console.WriteLine("Assignment: "+thing.TaskName);
                Console.WriteLine("Date Assigned "+thing.DateAssigned);
                Console.WriteLine("Date DUE: "+thing.DateDue);
                if (thing.CompStatus == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incomplete");
                }

                if(thing.CompStatus == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Completed");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------");

            }
           
        }

        public static void ShowClassTask(string inputCT)
        {
            Console.WriteLine("Current Assigments for " + inputCT);
            Console.WriteLine("===========================================");

            foreach (ToDo thing in myTasks)
            {
                
                if (inputCT != thing.ForClass)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There currently NO Assigments for this class");
                }
                if (inputCT == thing.ForClass)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Class " + thing.ForClass);
                    Console.WriteLine("Assignment: " + thing.TaskName);
                    Console.WriteLine("Date Assigned " + thing.DateAssigned);
                    Console.WriteLine("Date DUE: " + thing.DateDue);
                    if (thing.CompStatus == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incomplete");
                    }
                    
                    if (thing.CompStatus == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Completed");
                    }

                }
            }
        }

        public static void ShowSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your Class Schedule");
            Console.WriteLine("===========================================");
            
            if (myClasses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have NO Classes added, ADD them!");
            }
            myClasses = myClasses.OrderByDescending(t => t.TimeS).ToList();

            foreach (Class itemC in myClasses)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(itemC.ClassID);
                Console.WriteLine(itemC.ClassName);
                Console.WriteLine(itemC.Days);
                Console.WriteLine(itemC.TimeS);
                Console.WriteLine("________________________________________________");
            }
        }

        
    }
}

//PROGRAM CANNOT SAVE PREVIOUS INFORMATION ONCE CLOSED...YET