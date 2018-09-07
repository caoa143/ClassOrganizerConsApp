using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Text;
using System.IO;



//DateTime dt = DateTime.Parse("6/22/2009 07:00:00 AM");

//dt.ToString("HH:mm"); // 07:00 // 24 hour clock // hour is always 2 digits
//dt.ToString("hh:mm tt");

namespace ClassORGcaoa2
{
    class Collector
    {

        //METHOD FOR OLD USERS*********************
        public static void GetFromText()
        {
            string path = MoreMethds.DirCList[0];
            string[] logFile = File.ReadAllLines(path + "\\Classes.txt");

           

            foreach (var classString in logFile)
            {
                var tempClass = new Class();
                var tempArr = classString.Split('|');

                if (tempArr.Length > 2)
                {
                    tempClass.ClassID = tempArr[0]; tempClass.ClassName = tempArr[1]; tempClass.Teacher = tempArr[2];
                    tempClass.TimeS = DateTime.Parse(tempArr[3]); ;
                    tempClass.Days = tempArr[4]; tempClass.Room = tempArr[5];
                    myClasses.Add(tempClass);
                }

            }


            string[] logFile2 = File.ReadAllLines(path + "\\Assigns.txt");
            foreach (var TaskString in logFile2)
            {
                var tempTasks = new ToDo();
                var tempArr2 = TaskString.Split('|');
                if (tempArr2.Length > 2)
                {
                    tempTasks.TaskName = tempArr2[0]; tempTasks.ForClass = tempArr2[1];
                    tempTasks.DateAssigned = DateTime.Parse(tempArr2[2]);
                    tempTasks.DateDue = DateTime.Parse(tempArr2[3]);
                    if (tempArr2[4] == "Completed")
                    {
                        tempTasks.CompStatus = true;
                    }
                    if (tempArr2[4] == "Incomplete")
                    {
                        tempTasks.CompStatus = false;
                    }

                    myTasks.Add(tempTasks);
                }
            }

            myClasses = myClasses.OrderByDescending(t => t.TimeS).ToList();
        }



        //*****************************************

        //METHOD FOR NEW USERS ^^^^^^^^^^^^^^^^^^^^^^^^

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

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

            Console.WriteLine("Enter the time the class starts (h:mm tt)");
            string timeSTR = Console.ReadLine();
            newClass.TimeS = DateTime.ParseExact(timeSTR, "h:mm tt", CultureInfo.InvariantCulture);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newClass.ClassID + " " + newClass.ClassName + " has been added to your classes!");

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

                if (inputC == item.ClassID || inputC == item.ClassName)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(item.ClassID);
                    Console.WriteLine(item.ClassName);
                    Console.WriteLine("Room " + item.Room);
                    Console.WriteLine("Teacher " + item.Teacher);
                    Console.WriteLine(item.TimeS);
                    Console.WriteLine("Days: " + item.Days);

                }
                else if (inputC != item.ClassID || inputC != item.ClassName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This class does not exist in your list of classes. Add it!");
                }

            }

        }
        public static void ShowALLclasses()
        {
            Console.ForegroundColor = ConsoleColor.White;


            if (myClasses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("You Have no Classes in your Profile, Add them!");
            }
            Console.WriteLine(" Your Classes:");

            myClasses = myClasses.OrderBy(t => t.TimeS).ToList();
            foreach (Class item in myClasses)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("__________________________________________");
                Console.WriteLine(item.ClassID);
                Console.WriteLine(item.ClassName);
                Console.WriteLine("Room " + item.Room);
                Console.WriteLine("Teacher " + item.Teacher);
                Console.WriteLine(item.TimeS.ToString("h:mm tt"));
                Console.WriteLine("Days: " + item.Days);
                Console.WriteLine(" ");
                Console.WriteLine("__________________________________________");

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
            newTask.ForClass = Console.ReadLine();


            newTask.DateAssigned = DateTime.Now;

            Console.WriteLine("When is this Assignment due? (MM/DD/YYYY 00:00 #M");
            string dateDueSTR = Console.ReadLine();
            newTask.DateDue = DateTime.Parse(dateDueSTR);

            newTask.CompStatus = false;

            myTasks.Add(newTask);

            Console.WriteLine("Your new task for " + newTask.ForClass + " has been Added!");

        }

        public static void ShowAllTasks()
        {

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

        public static void ChangeStatus()
        {
            ShowAllTasks();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter Which Assigment you would like to mark as COMPLETE");
            string uInputTask = Console.ReadLine();

            foreach (ToDo tasks in myTasks)
            {
                if (uInputTask == tasks.TaskName)
                {
                    tasks.CompStatus = true;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("The status for " + uInputTask + " has been marked as COMPLETE");

        }

    }
}


