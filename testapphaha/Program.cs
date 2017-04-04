using System;
using Records.App.Concrete;
using System.Text;
using System.IO;
using System.Linq;

namespace Records.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                Console.WriteLine("Enter provider");
                var partner = Console.ReadLine();
                Console.WriteLine("Enter date");
                var dateToCheck = Console.ReadLine();
                //args = new string[] { @"C:\testapphaha\testapphaha\InputFiles\input1.txt", @"C:\testapphaha\testapphaha\InputFiles\input2.txt" };

                var file1Path = args[0];
                var file2Path = args[1];

                string[] linesRecords = File.ReadAllLines(file1Path, Encoding.UTF8);

                string[] linesLicenses = File.ReadAllLines(file2Path, Encoding.UTF8);

                //Ignore the first three lines of each file, since it's for headers
                var relevantLinesRecords = linesRecords.Skip(3);
                var relevantLinesLicenses = linesLicenses.Skip(3);

                //Create manually the instance of the object to use
                //Since it's very simple for this small app I don't use an Ioc container
                var recordLicenser = new RecordLicenser(relevantLinesRecords, relevantLinesLicenses);

                var validRecords = recordLicenser.getValidRecords(partner, dateToCheck);

                Console.WriteLine("Artist|Title|Usages|StartDate|EndDate");
                foreach (var item in validRecords)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("syntax is '<exe file> <inputfile1> <inputfile2>'");
            }
        }
    }
}
