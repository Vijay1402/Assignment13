using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web;
using System.Data.SqlTypes;
using System.Collections;

namespace Assignment13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text to be validated");
            string inputString = Console.ReadLine();
            displayAll(inputString);
            Console.WriteLine("Enter 1 if you would like to use a custom regex expression");
            if(int.Parse(Console.ReadLine()) == 1)
            {
                customRegex(inputString);
            }
            Console.ReadKey();
        }
        static int wordCount(string inputString)
        {
            int count = Regex.Matches(inputString, @"\b\w+\b").Count;
            return count;
        }
        static ArrayList email(string[] words)
        {
            Regex re = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            ArrayList foundEmail = new ArrayList { };
            int flag = 0;
            foreach (string s in words)
            {
                if(re.IsMatch(s))
                {

                    foundEmail.Add(s);
                    flag = 1;
                }
            }
            if (flag==0) Console.WriteLine("No email addresses found");
            return foundEmail;
        }
        static ArrayList mobNum(string[] words)
        {
            Regex re = new Regex(@"^\d{10}$");
            ArrayList foundMobNum = new ArrayList { };
            int flag = 0;
            foreach (string s in words)
            {
                if (re.IsMatch(s))
                {
                    foundMobNum.Add(s);
                    flag = 1;
                }
            }
            if (flag == 0) Console.WriteLine("No mobile numbers found");
            return foundMobNum;
        }
        static void displayAll(string inputString)
        {
            string[] words = inputString.Split(' ');
            Console.WriteLine("No of words present in this text is:: " + wordCount(inputString) + "\n");
            ArrayList dispEmail = email(words);
            Console.WriteLine("Number of email addresses found: " + dispEmail.Count + "\n");
            foreach (string s in dispEmail)
            {
                Console.WriteLine(s);
            }
            ArrayList dispMobNum = mobNum(words);
            Console.WriteLine("Number of mobile numbers found: " + dispMobNum.Count+"\n");
            foreach (string s in dispMobNum)
            {
                Console.WriteLine(s);
            }
        }
        static void customRegex(string inputString)
        {
            string[] words = inputString.Split(' ');
            Console.WriteLine("Enter the regex expression in the correct format");
            string customPattern = Console.ReadLine();
            try
            {
                Regex re = new Regex(@customPattern);
                ArrayList foundMobNum = new ArrayList { };
                int flag = 0;
                foreach (string s in words)
                {
                    if (re.IsMatch(s))
                    {
                        Console.WriteLine(s);
                        flag = 1;
                    }
                }
                if (flag == 0) Console.WriteLine("No matches found");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
