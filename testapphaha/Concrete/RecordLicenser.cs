using Records.App.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Records.App.Concrete
{
    /// <summary>
    /// Represents the entity which will process information about records and licenses
    /// </summary>
    public class RecordLicenser
    {
        private readonly IEnumerable<RecordModel> recordList;
        private readonly IEnumerable<LicenseModel> licenseList;

        /// <summary>
        /// default constructor
        /// </summary>
        public RecordLicenser()
        {

        }

        /// <summary>
        /// constructor to use the file paths
        /// </summary>
        /// <param name="args"></param>
        public RecordLicenser(string[] args)
        {
            var file1Path = args[0];
            var file2Path = args[1];

            string[] linesRecords = File.ReadAllLines(file1Path, Encoding.UTF8);

            string[] linesLicenses = File.ReadAllLines(file2Path, Encoding.UTF8);

            var relevantLinesRecords = linesRecords.Skip(3);
            var relevantLinesLicenses = linesLicenses.Skip(3);

            recordList = relevantLinesRecords.Select(x => new RecordModel(x));

            licenseList = relevantLinesLicenses.Select(x => new LicenseModel(x));

        }

        /// <summary>
        /// constructor to use with the lists obtained after reading text files with info about records and licenses
        /// </summary>
        /// <param name="relevantLinesRecords">List of strings with all of the records to analise</param>
        /// <param name="relevantLinesLicenses">List of strings with all of the licenses to check</param>
        public RecordLicenser(IEnumerable<string> relevantLinesRecords, IEnumerable<string> relevantLinesLicenses)
        {
            recordList = relevantLinesRecords.Select(x => new RecordModel(x));

            licenseList = relevantLinesLicenses.Select(x => new LicenseModel(x));

        }

        /// <summary>
        /// Return the records allowed for a partner in a specific date
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public string[] getValidRecords(string partner, string dateString)
        {
            var date = Utilities.Utilities.parseDate(dateString);

            var licenceTypeString = licenseList.FirstOrDefault(x => x.Name == partner).Type;

            var result = this.recordList.Where(x => x.isAllowedDate(date) && x.isAllowedUsage(licenceTypeString))
                .OrderBy(x=>x.Artist).ThenBy(x=>x.Title);

            return result.Select(x=> string.Format("{0}|{1}|{2}|{3}|{4}",
                x.Artist,
                x.Title,
                licenceTypeString,
                x.OriginalStartDate,
                x.OriginalEndDate)).ToArray();
        }
    }
}
