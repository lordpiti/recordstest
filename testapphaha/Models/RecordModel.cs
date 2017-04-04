using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Records.App.Models
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
            Usages = substrings[2].Split(delimiter2).Select(x=>x.Trim()).ToList();
            StartDate = Utilities.Utilities.parseDate(substrings[3]);
            EndDate = !string.IsNullOrEmpty(substrings[4]) ? (DateTime?)Utilities.Utilities.parseDate(substrings[4]) : null;
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
            return Usages.Any(x => usage== x);

        }
    }
}
