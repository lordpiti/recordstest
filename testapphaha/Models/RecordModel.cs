using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapphaha.Utilities;

namespace testapphaha.Models
{
    public class RecordModel
    {
        public RecordModel()
        {

        }

        public RecordModel(string line)
        {
            char delimiter = '|';
            char delimiter2 = ',';

            string[] substrings = line.Split(delimiter);

            Artist = substrings[0];
            Title = substrings[1];
            Usages = substrings[2].Split(delimiter2).ToList();
            StartDate = DateUtilities.parseDate(substrings[3]);
            EndDate = !string.IsNullOrEmpty(substrings[4]) ? (DateTime?)DateUtilities.parseDate(substrings[4]) : null;
            OriginalStringRead = line;
            OriginalStartDate = substrings[3];
            OriginalEndDate = substrings[4];
        }

        public string Artist { get; set; }

        public string Title { get; set; }

        public List<string> Usages { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string OriginalStringRead { get; set; }

        public string OriginalStartDate { get; set; }

        public string OriginalEndDate { get; set; }

        public bool isAllowedDate(DateTime date)
        {
            return (EndDate == null && StartDate < date) || (EndDate != null && (StartDate < date && date < EndDate));
        }

        public bool isAllowedUsage(string usage)
        {
            return Usages.Any(x => usage == x);
        }

        /// <summary>
        /// Override version of the ToString method to output dates in the format like "1st Mar 2017"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}",
                Artist,
                Title,
                string.Join(",", Usages.ToArray()),
                OriginalStartDate,
                OriginalEndDate);
        }
    }
}
