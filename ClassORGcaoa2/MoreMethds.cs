using System;
using System.Collections.Generic;
using System.Text;

namespace ClassORGcaoa2
{
    class MoreMethds
    {
        public static void UserStatus()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("(1)New user or (2)Prev?");
            string userInp=Console.ReadLine();

            if (userInp == "1")
            {
                //for later
                //create new folder and new text files
                Console.WriteLine("New Account and database Created");
            }
            if (userInp == "2")
            {
                //recover info from text files
                Collector.GetFromText();
                Console.WriteLine("Welcome Back! Your Classes and Assignemnts have been recovered");
            }

        }
    }
}
