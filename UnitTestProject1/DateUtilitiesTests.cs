﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testapphaha;
using testapphaha.Utilities;

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
        public void Test_GetItems()
        {
            var list = new string[] { @"C:\testapphaha\testapphaha\InputFiles\input1.txt", @"C:\testapphaha\testapphaha\InputFiles\input2.txt" }; 

            var hh = new RecordLicenser()
        }

    }
}
