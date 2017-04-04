using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Records.App.Models;
using Records.App.Concrete;

namespace Records.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter provider");
            var provider = Console.ReadLine();
            Console.WriteLine("Enter date");
            var dateToCheck = Console.ReadLine();
            args = new string[] { @"C:\testapphaha\testapphaha\InputFiles\input1.txt", @"C:\testapphaha\testapphaha\InputFiles\input2.txt" };

            //Create manually the instance of the object to use
            //Since it's very simple for this small app I don't use an Ioc container
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
