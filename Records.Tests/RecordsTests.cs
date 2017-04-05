using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Records.App.Utilities;
using Records.App.Concrete;
using testapphaha.Interfaces;

namespace Records.Tests
{
    [TestClass]
    public class RecordsTests
    {
        private IRecordLicenser _recordLicenser;

        /// <summary>
        /// Initialise the records and licenses in all the relevant tests using the data provided in
        /// the text files
        /// The testing of the file read has been excluded since the path where they are located depend on each machine,
        /// 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            #region Test initialisation from text files

            //In case of needing to test the files reading, uncomment the code below and specify the files path properly
            
            //var inputFiles = new string[] { @"C:\testapphaha\testapphaha\InputFiles\input1.txt", @"C:\testapphaha\testapphaha\InputFiles\input2.txt" };

            //Manual initialisation for this small app, instead of using a proper Ioc container like ninject, unity or structuremap
            //_recordLicenser = new RecordLicenser(inputFiles);

            #endregion

            #region Test initialisation from string arrays with the data from the text files

            var records = new string[] {
            "Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming |1st Feb 2012|",
            "Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|",
            "Tinie Tempah|Till I'm Gone|digital download|1st Aug 2012|",
            "Monkey Claw|Black Mountain|digital download|1st Feb 2012|",
            "Monkey Claw|Iron Horse|digital download, streaming|1st June 2012|",
            "Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|",
            "Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012" };

            var licenses = new string[] {
                "ITunes|digital download",
                "YouTube|streaming"
            };

            _recordLicenser = new RecordLicenser(records, licenses);

            #endregion

        }

        [TestMethod]
        public void Test_ParseDate_FullMonthDate_ReturnsRightDateTime()
        {
            var stringToParse = "1st June 2012";

            var date = Utilities.parseDate(stringToParse);

            var expectedDate = new DateTime(2012,6,1);

            Assert.AreEqual(date,expectedDate);
        }

        [TestMethod]
        public void Test_ParseDate_3charsMonthDate_ReturnsRightDateTime()
        {
            var stringToParse = "3rd Mar 2012";

            var date = Utilities.parseDate(stringToParse);

            var expectedDate = new DateTime(2012, 3, 3);

            Assert.AreEqual(date, expectedDate);
        }

        [TestMethod]
        public void Test_GetItems_ReturnTestCase1Output()
        {
            var expected = new string[] {
                "Monkey Claw|Black Mountain|digital download|1st Feb 2012|",
                "Monkey Claw|Motor Mouth|digital download|1st Mar 2011|",
                "Tinie Tempah|Frisky (Live from SoHo)|digital download|1st Feb 2012|",
                "Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|"
            };

            var outputLines = _recordLicenser.getValidRecords("ITunes", "1st March 2012");

            CollectionAssert.AreEqual(expected, outputLines);
        }

        [TestMethod]
        public void Test_GetItems_ReturnTestCase2Output()
        {
            var expected = new string[] {
                "Monkey Claw|Motor Mouth|streaming|1st Mar 2011|",
                "Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|"
            };

            var outputLines = _recordLicenser.getValidRecords("YouTube", "1st April 2012");

            CollectionAssert.AreEqual(expected, outputLines);
        }

        [TestMethod]
        public void Test_GetItems_ReturnTestCase3Output()
        {
            var expected = new string[] {
                "Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012",
                "Monkey Claw|Iron Horse|streaming|1st June 2012|",
                "Monkey Claw|Motor Mouth|streaming|1st Mar 2011|",
                "Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|"
            };

            var outputLines = _recordLicenser.getValidRecords("YouTube", "27th Dec 2012");

            CollectionAssert.AreEqual(expected, outputLines);
        }

    }
}
