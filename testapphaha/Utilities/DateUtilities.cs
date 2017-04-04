using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapphaha.Utilities
{
    public static class DateUtilities
    {
        public static DateTime parseDate(string input)
        {
            //http://stackoverflow.com/questions/7227756/parsing-non-standard-date-formats-with-datetime-tryparseexact

            int index = char.IsNumber(input, 1) ? 2 : 1;
            input = input.Substring(0, index) + input.Substring(index + 2);

            DateTime date = new DateTime();

            //According to the input files provided, the allowed dates might have either of these two formats
            var formats =  new string[] { "d MMM yyyy", "d MMMM yyyy" };

            //DateTime d = DateTime.ParseExact(input, "d MMM yyyy", CultureInfo.InvariantCulture);
            var isValidDate = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture,DateTimeStyles.None, out date);

            return date;
        }

        //public static string GetDaySuffix(int day)
        //{
        //    switch (day)
        //    {
        //        case 1:
        //        case 21:
        //        case 31:
        //            return "st";
        //        case 2:
        //        case 22:
        //            return "nd";
        //        case 3:
        //        case 23:
        //            return "rd";
        //        default:
        //            return "th";
        //    }
        //}

        //public static string FormatSpecialDateTime(DateTime? dt)
        //{
        //    if (dt == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var dtConcrete = (DateTime)dt;
        //        return string.Format("{0}{1} {2}",
        //                          dtConcrete.Day,
        //                          GetDaySuffix(dtConcrete.Day),
        //                          dtConcrete.ToString("MMM yyyy", CultureInfo.InvariantCulture));
        //    }


        //}
    }
}
