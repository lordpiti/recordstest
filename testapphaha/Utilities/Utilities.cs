using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.App.Utilities
{
    public static class Utilities
    {
        /// <summary>
        /// Convert a string with the format "d MMM yyyy" or "d MMMM yyyy" into a DateTime
        /// </summary>
        /// <param name="input">string date input</param>
        /// <returns>datetime with the parsed date</returns>
        public static DateTime parseDate(string input)
        {
            int index = char.IsNumber(input, 1) ? 2 : 1;
            input = input.Substring(0, index) + input.Substring(index + 2);

            DateTime date = new DateTime();

            //According to the input files provided, the allowed dates might have either of these two formats
            var formats =  new string[] { "d MMM yyyy", "d MMMM yyyy" };

            var isValidDate = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture,DateTimeStyles.None, out date);

            return date;
        }
    }
}
