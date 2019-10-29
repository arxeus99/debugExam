using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string work;
            //int i, t, ttl; As the code is written right now I must intialize those ints to work properly
            int hoursWorked = 0;
            var ents = new List<TimeSheetEntry>();
            Console.Write("Enter what you did: ");
            work = Console.ReadLine();
            Console.Write("How long did you do it for: ");
            bool done = false;
            //t = int.Parse(Console.ReadLine()); If we do it like this the user can write any other thing that is not a number and the application will crush
            do
            {
                try
                {
                    hoursWorked = int.Parse(Console.ReadLine());
                    done = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number");
                }
            } while (done == false);
            //TimeSheetEntry ent = new TimeSheetEntry() If we allways use the same variable to add in the list it will always change
            /*ent.HoursWorked = hoursWorked;
            ent.WorkDone = work;*/
            ents.Add(new TimeSheetEntry(work, hoursWorked));
            Console.Write("Do you want to enter more time:");
            //bool cont = bool.Parse(Console.ReadLine()); It only will work if the user only writes true or false
            string decision = Console.ReadLine();
            bool cont = false;
            done = false;
            while(done == false)
            {
                switch (decision)//I think a good solution is to read what the users introduces as a string a depending on what it writes set the boolean as true or false
                {
                    case "yes":
                    case "Yes":
                    case "YES":
                        cont = true;
                        done = true;
                        break;

                    case "no":
                    case "No":
                    case "NO":
                        cont = false;
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please write yes or no"); //We have to check if the user doesnt write any of the options
                        decision = Console.ReadLine();
                        break;
                }
            }
            

            //if we put a do while it will always do it at least one time and the user can say no the first time
            while(cont == true)
            {
                Console.Write("Enter what you did: ");
                work = Console.ReadLine();
                Console.Write("How long did you do it for: ");
                done = false;
                //t = int.Parse(Console.ReadLine()); If we do it like this the user can write any other thing that is not a number and the application will crush
                do
                {
                    try
                    {
                        hoursWorked = int.Parse(Console.ReadLine());
                        done = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid number");
                    }
                } while (done == false);
                /*ent.HoursWorked = hoursWorked;
                ent.WorkDone = work;*/
                ents.Add(new TimeSheetEntry(work, hoursWorked));
                Console.Write("Do you want to enter more time:");
                //cont = bool.Parse(Console.ReadLine()); The same mistake as before
                decision = Console.ReadLine();
                done = false;
                while (done == false)
                {
                    switch (decision)//I think a good solution is to read what the users introduces as a string a depending on what it writes set the boolean as true or false
                    {
                        case "yes":
                            cont = true;
                            done = true;
                            break;

                        case "no":
                            cont = false;
                            done = true;
                            break;
                        default:
                            Console.WriteLine("Please write yes or no"); //We have to check if the user doesnt write any of the options
                            decision = Console.ReadLine();
                            break;
                    }
                }
            }
            hoursWorked = 0; 
            /*for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.Contains("Acme"))
                {
                    ttl += i;
                }
            }*/ //I dont understand this so I will do it to work as the well done

            foreach(TimeSheetEntry ts in ents)
            {
                if (ts.WorkDone.Contains("Acme") || ts.WorkDone.Contains("acme") || ts.WorkDone.Contains("ACME"))
                {
                    hoursWorked = hoursWorked + ts.HoursWorked; //We search for every work done for Acme and we count how many hours we've work for them
                }
            }
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + hoursWorked * 150 + " for the hours worked.");
            hoursWorked = 0; // we reset the count
            foreach (TimeSheetEntry ts in ents)
            {
                if (ts.WorkDone.Contains("ABC") || ts.WorkDone.Contains("abc") || ts.WorkDone.Contains("Abc"))
                {
                    hoursWorked = hoursWorked + ts.HoursWorked; //We search for every work done for ABC and we count how many hours we've work for them
                }
            }
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + hoursWorked * 125 + " for the hours worked.");
            /*for (i = 0; i < ents.Count; i++)
            {
                ttl += ents[i].HoursWorked;
            }*/ //Im not sure if this for works properly so I will do it again
            hoursWorked = 0; //Now we want to count all the hours no matter wich company we've worked for
            foreach (TimeSheetEntry ts in ents)
            {
                hoursWorked = hoursWorked + ts.HoursWorked;
            }
            //In the next if else I understand that if the user works more than 40 hours he will get 15$ for each hour, if he works less than 40 he will get 10$ per hour instead
            if (hoursWorked > 40)
            {
                Console.WriteLine("You will get paid $" + hoursWorked * 15 + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + hoursWorked * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }
    }

    public class TimeSheetEntry
    {
        public string WorkDone;
        public int HoursWorked;
        //I've created a constructor so we dont have to use a variable to insert in the list
        public TimeSheetEntry(string w, int h)
        {
            WorkDone = w;
            HoursWorked = h;
        }
    }
}
