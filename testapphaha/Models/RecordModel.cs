using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Records.App.Models
{
    /// <summary>
    /// Represents the information about a record
    /// </summary>
    public class RecordModel
    {
        public RecordModel()
        {

        }

        public RecordModel(string line)
        {
            const char delimiter = '|';
            const char delimiter2 = ',';

            string[] substrings = line.Split(delimiter);

            Artist = substrings[0];
            Title = substrings[1];
            Usages = substrings[2].Split(delimiter2).Select(x=>x.Trim()).ToList();
            StartDate = Utilities.Utilities.parseDate(substrings[3]);
            EndDate = !string.IsNullOrEmpty(substrings[4]) ? (DateTime?)Utilities.Utilities.parseDate(substrings[4]) : null;
            OriginalStartDate = substrings[3];
            OriginalEndDate = substrings[4];
        }

        public string Artist { get; set; }

        public string Title { get; set; }

        public List<string> Usages { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string OriginalStartDate { get; set; }

        public string OriginalEndDate { get; set; }

        /// <summary>
        /// Check if the record is allowed to be used in a specific date
        /// </summary>
        /// <param name="date">The specific date to be checked for the record</param>
        /// <returns></returns>
        public bool isAllowedDate(DateTime date)
        {
            return (EndDate == null && StartDate < date) || (EndDate != null && (StartDate < date && date < EndDate));
        }

        /// <summary>
        /// Check if the record is allowed for an usage
        /// </summary>
        /// <param name="usage">The specific usage we want to check for that record</param>
        /// <returns></returns>
        public bool isAllowedUsage(string usage)
        {
            return Usages.Any(x => usage== x);

        }
    }
}
