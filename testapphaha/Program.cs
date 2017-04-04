using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapphaha.Models;
using testapphaha.Utilities;

namespace testapphaha
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string text = File.ReadAllText(@"D:\Repos\spacehive-datacollection\testapphaha\testapphaha\InputFiles\input1.txt", Encoding.UTF8);

            

            Console.WriteLine("enter provider");
            var provider = Console.ReadLine();
            Console.WriteLine("enter date");
            var dateToCheck = Console.ReadLine();

            var recordLicenser = new RecordLicenser(args);

            var date = DateUtilities.parseDateFullMonth("1st March 2012");
            var theList = recordLicenser.getValidOnes(provider, date);

            foreach (var item in theList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

    }
}
