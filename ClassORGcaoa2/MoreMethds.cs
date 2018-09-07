using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassORGcaoa2
{
    class MoreMethds
    {
        public static List<string> DirCList = new List<string>();
        public static List<string> DirNewList = new List<string>();



        public static void UserStatus()
        {
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("(1)New user or (2)Prev?");
                string userInp = Console.ReadLine();
                
                if (userInp == "1")
                {
                    Console.WriteLine("Enter your user Name");
                    string newUser = Console.ReadLine();
                    string dir = @"C:\Users\andre\source\repos\ClassORGcaoa2\Users\" + newUser;

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                        
                    }



                    DirCList.Add(dir);

                    string pathC = dir + "\\Classes.txt";
                    if (!File.Exists(pathC))
                    {
                        File.Create(pathC).Close();
                      //  DirNewList.Add(pathC);
                        //method to extract DIR
                    }

                    string pathA = dir + "\\Assigns.txt";
                    if (!File.Exists(pathA))
                    {
                        File.Create(pathA).Close() ;
                      //  DirNewList.Add(pathA);
                        //method to extract DIR


                    }



                    Console.WriteLine("New Account and database Created");

                }
                if (userInp == "2")
                {
                   
                    
                    bool catchbool= false;
                    do
                    {
                        Console.WriteLine(" Enter your User Name!");
                        string oldUser = Console.ReadLine();
                        // Directory.SetCurrentDirectory(@"C:\Users\andre\source\repos\ClassORGcaoa2\Users\"+oldUser); //Why???

                        string DirSend = @"C:\Users\andre\source\repos\ClassORGcaoa2\Users\" + oldUser;
                        DirCList.Add(DirSend);
                        catchbool = false;
                        try
                        {
                            Collector.GetFromText();

                        }
                        catch
                        {
                            catchbool = true;
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("THAT USER DOES NOT EXIST");

                            DirCList.RemoveAt(0);

                            Console.ForegroundColor = ConsoleColor.White;

                        }
                    } while (catchbool);

                    Console.WriteLine("Welcome Back! Your Classes and Assignemnts have been recovered");
                }

            }
        }
    }
}
