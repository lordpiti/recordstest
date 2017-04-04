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
            Console.WriteLine("enter provider");
            var provider = Console.ReadLine();
            Console.WriteLine("enter date");
            var dateToCheck = Console.ReadLine();
            args = new string[] { @"C:\testapphaha\testapphaha\InputFiles\input1.txt", @"C:\testapphaha\testapphaha\InputFiles\input2.txt" };

            var recordLicenser = new RecordLicenser(args);

            var dateString = "1st March 2012";
            var theList = recordLicenser.getValidOnes(provider, dateString);

            foreach (var item in theList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }
}
