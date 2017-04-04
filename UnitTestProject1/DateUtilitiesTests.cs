using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testapphaha;
using testapphaha.Utilities;
using testapphaha.Models;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class DateUtilitiesTests
    {
        [TestMethod]
        public void Test_ParseDate_FullMonthDate_ReturnsRightDateTime()
        {
            var stringToParse = "1st June 2012";

            var date = DateUtilities.parseDate(stringToParse);

            var expectedDate = new DateTime(2012,6,1);

            Assert.AreEqual(date,expectedDate);
        }

        [TestMethod]
        public void Test_ParseDate_charsMonthDate_ReturnsRightDateTime()
        {
            var stringToParse = "3rd Mar 2012";

            var date = DateUtilities.parseDate(stringToParse);

            var expectedDate = new DateTime(2012, 3, 3);

            Assert.AreEqual(date, expectedDate);
        }

        [TestMethod]
        public void Test_GetItems_ReturnTestCase1Output()
        {
            var inputFiles = new string[] { @"C:\testapphaha\testapphaha\InputFiles\input1.txt", @"C:\testapphaha\testapphaha\InputFiles\input2.txt" };

            var recordLicenser = new RecordLicenser(inputFiles);

            var expected = new string[] {
                "Monkey Claw|Black Mountain|digital download|1st Feb 2012|",
                "Monkey Claw|Motor Mouth|digital download|1st Mar 2011|",
                "Tinie Tempah|Frisky (Live from SoHo)|digital download|1st Feb 2012|",
                "Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|"
            };

            var outputLines = recordLicenser.getValidOnes("ITunes", "1st March 2012").ToArray();

            CollectionAssert.AreEqual(expected, outputLines);
        }

    }
}
